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



        public void SetStrengthAndAngle()
        {
            base.strength = (float) MyMath.GetRandomNumber(rnd, 0.03f, 0.05f);
            base.rotation = (float)MyMath.GetRandomNumber(rnd, 0, 360);
            base.scaleFactor = MyMath.TreeRule(1, 0.03f, strength);
            //base.strength = .05f;


            Console.WriteLine("");
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
