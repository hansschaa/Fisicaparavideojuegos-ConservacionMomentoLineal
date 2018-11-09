using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace test3
{
    public class WindArrow : Arrow
    {
        public Random rnd;
        float timer = 5;

        public WindArrow(Vector2 position, float rotation, Vector2 velocity, Vector2 acceleration, Texture2D texture) : base(position, rotation, velocity, acceleration, texture)
        {
            rnd = new Random();
            SetStrengthAndAngle();
        }

        public void Draw(SpriteBatch spriteBach)
        {
            spriteBach.Draw(base.texture, base.position, null, Color.White, base.rotation, origin, scaleFactor, SpriteEffects.None, 0);
        }

        public void SetStrengthAndAngle()
        {
            base.strength = (float) MyMath.GetRandomNumber(rnd, 0.001f, 0.002f);
            base.rotation = (float)MyMath.GetRandomNumber(rnd, 0, 360);
            base.scaleFactor = MyMath.TreeRule(2, 0.002f, strength);

            Console.WriteLine("***SetStrengthAndAngle***");
            Console.WriteLine("Rotation: " + base.rotation);
            Console.WriteLine("Strength: " + base.strength);
            Console.WriteLine("ScaleFactor: " + base.scaleFactor);


        }

        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timer -= elapsed;
            if (timer < 0)
            {
                SetStrengthAndAngle();
        
                timer = 5;  
            }

        }
    }
}
