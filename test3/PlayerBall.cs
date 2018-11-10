using System;
using Microsoft.Xna.Framework;
using test3.Desktop;

namespace test3
{
    public class PlayerBall : Ball
    {
        public PlayerBall(Vector2 position, float rotation, Vector2 velocity, Vector2 acceleration, float radius, BallType ballType, Color color) : base(position, rotation, velocity, acceleration, radius, ballType, color)
        {
        }

        override
        public void Update()
        {
            base.CheckWindowCollisions();
            base.ApplyWindForce();

            if(MyMath.IsBallCollided(base.position, Game1.targetBall.position))
            {
                Game1.targetBall.ballState = BallState.MOVING;
                this.ballState = BallState.MOVING;
                /*
                float collisionAngle = (float)Math.Atan2(position.Y - Game1.targetBall.position.Y, position.X - Game1.targetBall.position.X);
                Game1.targetBall.velocity.X = ((float)(MyMath.GetMagnitude(base.velocity) * Math.Cos(collisionAngle)));
                Game1.targetBall.velocity.Y = ((float)(MyMath.GetMagnitude(base.velocity) * Math.Cos(MathHelper.ToRadians(90) + collisionAngle)));
                base.velocity.X = (float)(MyMath.GetMagnitude(base.velocity) * Math.Sin(MathHelper.ToRadians(90) + collisionAngle));
                base.velocity.Y = (float)(MyMath.GetMagnitude(base.velocity) * Math.Sin(MathHelper.ToRadians(90) + collisionAngle));*/


                Game1.targetBall.velocity.X = (float)(base.velocity.X * Math.Cos(-Game1.mouseArrow.rotation));
                Game1.targetBall.velocity.Y = (float)(base.velocity.Y * Math.Sin(-Game1.mouseArrow.rotation));
                base.velocity.X = (float)(base.velocity.X * Math.Cos(Game1.mouseArrow.rotation - MathHelper.ToRadians(90)));
                base.velocity.Y = (float)(base.velocity.Y * Math.Sin(Game1.mouseArrow.rotation - MathHelper.ToRadians(90)));

                //Console.WriteLine("Colisiono con target");
            }

            if (MyMath.IsBallCollided(base.position, Game1.enemyBall.position))
            {
                Game1.enemyBall.ballState = BallState.MOVING;
                this.ballState = BallState.MOVING;

                /*
                float collisionAngle = (float)Math.Atan2(position.Y - Game1.targetBall.position.Y, position.X - Game1.targetBall.position.X);
                Game1.enemyBall.velocity.X = ((float)(MyMath.GetMagnitude(base.velocity) * Math.Cos(collisionAngle)));
                Game1.enemyBall.velocity.Y = ((float)(MyMath.GetMagnitude(base.velocity) * Math.Cos(MathHelper.ToRadians(90) - collisionAngle)));
                base.velocity.X = (float)(MyMath.GetMagnitude(base.velocity) * Math.Sin(MathHelper.ToRadians(90) - collisionAngle));
                base.velocity.Y = (float)(MyMath.GetMagnitude(base.velocity) * Math.Sin(MathHelper.ToRadians(90) - collisionAngle));*/



                Game1.enemyBall.velocity.X = (float)(base.velocity.X * Math.Cos(-Game1.mouseArrow.rotation));
                Game1.enemyBall.velocity.Y = (float)(base.velocity.Y * Math.Sin(-Game1.mouseArrow.rotation));
                base.velocity.X = (float)(base.velocity.X * Math.Cos(Game1.mouseArrow.rotation - MathHelper.ToRadians(90)));
                base.velocity.Y = (float)(base.velocity.Y * Math.Sin(Game1.mouseArrow.rotation - MathHelper.ToRadians(90)));


                //Console.WriteLine("Colisionó con enemigo");
            }


            if (Game1.enemyBall.ballState == BallState.STATIC && Game1.targetBall.ballState == BallState.STATIC && MyMath.GetMagnitude(base.velocity) <= 0.005f && ballState == BallState.MOVING)
            {
                Console.WriteLine("Parar bola");
                ballState = BallState.STATIC;
                Game1.mouseArrow.UpdatePosition();
            }

        }

        internal void AddTacoVelocity(float rotation, float strength)
        {
            velocity = new Vector2((float)(strength * Math.Cos(rotation)),
                                    (float)(strength * Math.Sin(rotation)));

            base.ballState = BallState.MOVING;
        }
    }
}
