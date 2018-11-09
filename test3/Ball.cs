using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using test3.Desktop;

namespace test3
{
    public class Ball : GameObject
    {
        public int radius;
        public Color color;
        public int weigth;

        public Ball(Vector2 position, float rotation, Vector2 velocity, Vector2 acceleration, int radius, Color color) : base(position, rotation, velocity, acceleration)
        {
            this.radius = radius;
            this.color = color;
            this.weigth = 210;
        }

        public virtual void Update()
        {
            CheckWindowCollisions();
        }

        public void CheckWindowCollisions()
        {
            if(base.position.X + velocity.X > Game1.windowWidth ||
              base.position.X + velocity.X < 0)
            {
                velocity.X *= -1;
            }

            if (base.position.Y + velocity.Y > Game1.windowHeigth ||
             base.position.Y + velocity.Y < 0)
            {
                velocity.Y *= -1;
            }
        }

        public void Draw(SpriteBatch spriteBach)
        {
            Primitive.DrawCircle(spriteBach, base.position, radius, 20, this.color);
        }
    }
}
