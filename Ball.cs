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
        Vector2f velocity = new Vector2f(10, 1);

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

            if (circle.Position.X < bounds.Left || circle.Position.X >  bounds.Width - (2 * circle.Radius))
            {
                velocity.X *= -1; 
            }
            if (circle.Position.Y < bounds.Top || circle.Position.Y >  bounds.Height - (2 * circle.Radius))
            {
                velocity.Y *= -1; 
            }

            Vector2f displacement = velocity;
            Vector2f newPosition = circle.Position + displacement;

            circle.Position = newPosition;
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(circle);
        }
    }
}