using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace Pathinco
{
    public class Ball : Circle
    {
        public static List<Circle> balls = new List<Circle>();

        public Vector2f Position => circle.Position;
        Vector2f velocity = new Vector2f(10, 0);

        FloatRect bounds = new FloatRect(0, 0, Config.WindowWidth, Config.WindowHeight);

        const float gravity = 0.5f;

        public Ball(float radius, Vector2f origin, Color color, Vector2f position) : base(radius, origin, color)
        {
            circle.Position = position;
            balls.Add(this);
        }

        public static List<Circle> GetCircles()
        {
            return balls;
        }

        public void Update()
        {                       
            velocity.Y += gravity;

            Vector2f newPosition = Position + velocity;

            if (newPosition.X < 0 || newPosition.X > bounds.Width)
            {
                velocity.X = -velocity.X;
            }
            else if(newPosition.Y < 0 || newPosition.Y > bounds.Height)
            {
                velocity.Y = -velocity.Y;
            }
            circle.Position = newPosition;
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(circle);
        }
    }
}