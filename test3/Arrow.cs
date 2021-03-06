﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace test3
{
    public class Arrow : GameObject
    {
        public Texture2D texture;
        public Vector2 origin;
        public float scaleFactor;
        public float strength;


        public Arrow(Vector2 position, float rotation, Vector2 velocity, Vector2 acceleration, Texture2D texture) : base(position, rotation, velocity, acceleration)
        {
            this.texture = texture;
            scaleFactor = 1;
            origin = new Vector2(0, texture.Height / 2);
        }


        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, new Vector2(MyMath.MetersToPixel(base.position.X), MyMath.MetersToPixel(base.position.Y)), null, Color.White, MathHelper.ToRadians(base.rotation), origin, scaleFactor, SpriteEffects.None, 0);
        }
    }
}
