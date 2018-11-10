using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using test3.Desktop;

namespace test3
{
    public class MouseArrow : Arrow
    {
        MouseState previusState;

        public MouseArrow(Vector2 position, float rotation, Vector2 velocity, Vector2 acceleration, Texture2D texture) : base(position, rotation, velocity, acceleration, texture)
        {

        }

        override
        public void Draw(SpriteBatch spriteBach)
        {
            SetRotationFromMousePosition(Mouse.GetState().Position);
            spriteBach.Draw(this.texture, new Vector2(MyMath.MetersToPixel(base.position.X), MyMath.MetersToPixel(base.position.Y)), null, Color.White,base.rotation, origin, scaleFactor, SpriteEffects.None, 0);
        }

        internal void UpdatePosition()
        {
            this.position = new Vector2(Game1.playerBall.position.X,
                                            Game1.playerBall.position.Y);

            /*
            //Mostrar en el costado derecho superior
            if (Game1.playerBall.position.X <= Game1.windowWidth / 2 && Game1.playerBall.position.Y >= Game1.windowHeigth / 2)


            //Mostrar en el costado izquierdo superior
            else if (Game1.playerBall.position.X >= Game1.windowWidth / 2 && Game1.playerBall.position.Y >= Game1.windowHeigth / 2)
                this.position = new Vector2(Game1.playerBall.position.X - Game1.ballRadius * 3,
                                            Game1.playerBall.position.Y - Game1.ballRadius * 3);


            //Mostrar en el costado izquierdo inferior
            else if (Game1.playerBall.position.X >= Game1.windowWidth / 2 && Game1.playerBall.position.Y <= Game1.windowHeigth / 2)
                this.position = new Vector2(Game1.playerBall.position.X - Game1.ballRadius * 3,
                                            Game1.playerBall.position.Y + Game1.ballRadius * 3);


            //Mostrar en el costado derecho inferior
            else if (Game1.playerBall.position.X <= Game1.windowWidth / 2 && Game1.playerBall.position.Y <= Game1.windowHeigth / 2)
                this.position = new Vector2(Game1.playerBall.position.X + Game1.ballRadius * 3,
                                            Game1.playerBall.position.Y + Game1.ballRadius * 3);*/
        }

        private void SetRotationFromMousePosition(Point mousePosition)
        {
            Vector2 aux = new Vector2(mousePosition.X, mousePosition.Y) - new Vector2(MyMath.MetersToPixel(base.position.X), MyMath.MetersToPixel(base.position.Y));
            rotation = (float)Math.Atan2(aux.Y, aux.X);

            base.rotation = rotation;
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && scaleFactor < 2)
            {
                scaleFactor += 0.01f;
            }

            if (mouseState.LeftButton == ButtonState.Released && previusState.LeftButton == ButtonState.Pressed)
            {
                base.strength = MyMath.TreeRule(.9f, 1, scaleFactor);
                //base.strength = 0.9f;
                Game1.playerBall.AddTacoVelocity(base.rotation,base.strength);
                scaleFactor = 1f;
            }


            previusState = mouseState;
          

        }
    }
}
