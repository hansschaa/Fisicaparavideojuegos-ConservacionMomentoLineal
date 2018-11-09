using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace test3
{
    public class GameObject
    {

        public Vector2 position;
        public float rotation;
        public Vector2 velocity;
        public Vector2 acceleration;

        public GameObject(Vector2 position, float rotation, Vector2 velocity, Vector2 acceleration)
        {
            this.position = position;
            this.rotation = rotation;
            this.velocity = velocity;
            this.acceleration = acceleration;
        }
    }
}
