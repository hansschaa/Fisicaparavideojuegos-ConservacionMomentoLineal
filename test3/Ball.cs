using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using test3.Desktop;

namespace test3
{
    public class Ball : GameObject
    {
        public float radius;
        public Color color;
        public float weigth;
        public BallState ballState;
        public BallType ballType;

        public Ball(Vector2 position, float rotation, Vector2 velocity, Vector2 acceleration, float radius, BallType ballType,Color color) : base(position, rotation, velocity, acceleration)
        {
            this.radius = radius;
            this.color = color;
            this.weigth = 0.21f;
            this.ballState = BallState.STATIC;
            this.ballType = ballType;
        }

        internal void ApplyWindForce()
        {
            //Vector Aparente
            Vector2 velocityAparente = base.velocity - new Vector2((float)(Game1.windArrow.strength * Math.Cos(Game1.windArrow.rotation)),
                                    (float)(Game1.windArrow.strength * Math.Sin(Game1.windArrow.rotation)));

            //Fuerza del viento
            float fuerzaArrastreX = (float)(.5f * Game1.gravity * Math.Pow(velocityAparente.X, 2) * Math.PI * Math.Pow(Game1.ballRadius, 2) * .48f);
            float fuerzaArrastreY = (float)(.5f * Game1.gravity * Math.Pow(velocityAparente.Y, 2) * Math.PI * Math.Pow(Game1.ballRadius, 2) * .48f);

            //Nueva aceleracion tomando en cuenta la fuerza del viento
            float aceleracionX = ((fuerzaArrastreX * velocityAparente.X) / (this.weigth * velocityAparente.X)) * -1;
            float aceleracionY = ((fuerzaArrastreY * velocityAparente.Y) / (this.weigth * velocityAparente.Y)) * -1;

            //Nueva velocidad
            velocity += new Vector2(aceleracionX, aceleracionY) * 0.016f;

            //Aplicar roce cinetico a la pelota
            if (ballState == BallState.MOVING)
                velocity -= new Vector2((float)(Game1.frictionCoefficient * Game1.gravity * Math.Sin(Math.Atan2(velocity.X, velocity.Y))),
                        (float)(Game1.frictionCoefficient * Game1.gravity * Math.Cos(Math.Atan2(velocity.X, velocity.Y))));

            base.position += base.velocity * 0.016f;
        }

        public virtual void Update()
        {
            CheckWindowCollisions();
            /*
            if(ballType == BallType.ENEMY)
            {
                if (MyMath.IsBallCollided(this.position, Game1.targetBall.position))
                {
                    this.ballState = BallState.MOVING;
                    Game1.targetBall.ballState = BallState.MOVING;

                    Game1.targetBall.velocity.X += (float)(base.velocity.X * Math.Cos(Game1.mouseArrow.rotation));
                    Game1.targetBall.velocity.Y += (float)(base.velocity.Y * Math.Sin(Game1.mouseArrow.rotation));
                    base.velocity.X = (float)(base.velocity.X * Math.Cos(Game1.mouseArrow.rotation - 90));
                    base.velocity.Y = (float)(base.velocity.Y * Math.Sin(Game1.mouseArrow.rotation - 90));
                }
            }*/
                

            ApplyWindForce();


            if (MyMath.GetMagnitude(base.velocity) <= 0.001f && ballState == BallState.MOVING)
            {
                ballState = BallState.STATIC;
                Game1.mouseArrow.UpdatePosition();
            }

        }



        public void CheckWindowCollisions()
        {
            if(base.position.X  > Game1.windowWidth ||
              base.position.X  < 0)
            {
                velocity.X *= -1;
            }

            if (base.position.Y  > Game1.windowHeigth ||
             base.position.Y  < 0)
            {
                velocity.Y *= -1;
            }
        }

        public void Draw(SpriteBatch spriteBach)
        {
            Primitive.DrawCircle(spriteBach, new Vector2(MyMath.MetersToPixel(position.X), MyMath.MetersToPixel(position.Y)), MyMath.MetersToPixel(radius), 20, this.color);
            
        }
    }
}
