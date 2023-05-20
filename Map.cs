using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace Pathinco
{
    public class Map
    {
        private const float Radius = 100f;
        private const float Speed = 50f;
        private const float AngleOffset = (float)(Math.PI / 2f); 

        private List<Ball> balls;
        private Vector2f centerPosition;

        public Map()
        {
            balls = new List<Ball>();
            centerPosition = new Vector2f(400f, 300f);

            CreateMap();
        }

        private void CreateMap()
        {
            int numBalls = 10;
            float angleIncrement = (2f * (float)Math.PI) / numBalls;

            for (int i = 0; i < numBalls; i++)
            {
                float angle = i * angleIncrement + AngleOffset;
                float posX = centerPosition.X + (float)Math.Cos(angle) * Radius;
                float posY = centerPosition.Y + (float)Math.Sin(angle) * Radius;

                Ball ball = new Ball(20f, new Vector2f(0f, 0f), Color.White, new Vector2f(posX, posY), false);
                balls.Add(ball);
                Game.PhysicalComponents.Add(ball);
            }
        }

        public void Update(float deltaTime)
        {
            float angleIncrement = Speed * deltaTime / Radius;

            for (int i = 0; i < balls.Count; i++)
            {
                Ball ball = balls[i];
                Vector2f offset = ball.Position - centerPosition;
                float angle = (float)Math.Atan2(offset.Y, offset.X);
                angle += angleIncrement;
                float posX = centerPosition.X + (float)Math.Cos(angle) * Radius;
                float posY = centerPosition.Y + (float)Math.Sin(angle) * Radius;
                ball.Position = new Vector2f(posX, posY);
            }
        }

        public void DrawMap(RenderWindow window)
        {
            foreach (var ball in balls)
            {
                ball.Draw(window);
            }
        }
    }
}