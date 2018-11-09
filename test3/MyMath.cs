using System;
using Microsoft.Xna.Framework;

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
    }
}
