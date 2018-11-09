﻿using System;
using Microsoft.Xna.Framework;
using test3.Desktop;

namespace test3
{
    public class PlayerBall : Ball
    {
        public PlayerState playerState;

        public PlayerBall(Vector2 position, float rotation, Vector2 velocity, Vector2 acceleration, int radius, Color color) : base(position, rotation, velocity, acceleration, radius, color)
        {
            playerState = PlayerState.STATIC;
        }

        override
        public void Update()
        {
            base.CheckWindowCollisions();

            if (playerState == PlayerState.MOVING)
            {
                //Apply friction
                //base.velocity = Game1.frictionCoefficient * weigth * Game1.gravity * ;
                //Apply Wind Acceleration
                velocity += new Vector2((float)(Game1.windArrow.strength * Math.Cos(Game1.windArrow.rotation)),
                                        (float)(Game1.windArrow.strength * Math.Sin(Game1.windArrow.rotation)));

                base.position += base.velocity;
            }


            if (MyMath.GetMagnitude(base.velocity) <= 0f && playerState == PlayerState.MOVING)
            {
                playerState = PlayerState.STATIC;
                Game1.mouseArrow.UpdatePosition();
            }
        }

        internal void AddTacoVelocity(float rotation, float strength)
        {
            velocity = new Vector2((float)(strength * Math.Cos(rotation)),
                                    (float)(strength * Math.Sin(rotation)));

            playerState = PlayerState.MOVING;
        }
    }
}