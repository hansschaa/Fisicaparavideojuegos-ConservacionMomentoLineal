using System;
using Microsoft.Xna.Framework;
using test3.Desktop;

namespace test3
{
    public static class MyMath
    {
        public static float GetMagnitude(Vector2 vector)
        {
            return (float) Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }

        public static double GetRandomNumber(Random random, double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public static float TreeRule(float max,float a ,float x )
        {
            return (x * max) / a;
        }

        public static float MetersToPixel(float meters)
        {
            return meters * 300;
        }

        public static bool IsBallCollided(Vector2 positionBall1 , Vector2 positionBall2)
        {
            return Math.Sqrt(Math.Pow(positionBall1.X - positionBall2.X, 2) + Math.Pow(positionBall1.Y - positionBall2.Y, 2)) <= Game1.ballRadius*2;
        }


    }
}
