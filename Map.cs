using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;

namespace Pathinco
{
    public class Map
    {
        private const float LargeWheelRadius = 120f;
        private const float SmallWheelRadius = 50f;
        private const float Speed = 50f;
        private const float AngleOffset = (float)(Math.PI / 2f);

        private List<Ball> largeWheelObstacles;
        private List<Ball> smallWheelObstacles;

        private Vector2f wheelCenter;

        public Map()
        {
            largeWheelObstacles = new List<Ball>();
            smallWheelObstacles = new List<Ball>();

            wheelCenter = new Vector2f(400f, 300f);

            CreateLargeWheel();
            CreateSmallWheel();
        }

        private void CreateLargeWheel()
        {
            int numObstacles = 12;
            float angleIncrement = (2f * (float)Math.PI) / numObstacles;

            for (int i = 0; i < numObstacles; i++)
            {
                float angle = i * angleIncrement + AngleOffset;
                float posX = wheelCenter.X + (float)Math.Cos(angle) * LargeWheelRadius;
                float posY = wheelCenter.Y + (float)Math.Sin(angle) * LargeWheelRadius;

                Ball obstacle = new Ball(10f, new Vector2f(0f, 0f), Color.White, new Vector2f(posX, posY), false);
                largeWheelObstacles.Add(obstacle);
                Game.PhysicalComponents.Add(obstacle);
            }
        }

        private void CreateSmallWheel()
        {
            int numObstacles = 8;
            float angleIncrement = (2f * (float)Math.PI) / numObstacles;

            for (int i = 0; i < numObstacles; i++)
            {
                float angle = i * angleIncrement + AngleOffset;
                float posX = wheelCenter.X + (float)Math.Cos(angle) * SmallWheelRadius;
                float posY = wheelCenter.Y + (float)Math.Sin(angle) * SmallWheelRadius;

                Ball obstacle = new Ball(6f, new Vector2f(0f, 0f), Color.White, new Vector2f(posX, posY), false);
                smallWheelObstacles.Add(obstacle);
                Game.PhysicalComponents.Add(obstacle);
            }
        }

        public void Update(float deltaTime)
        {
            float angleIncrement = Speed * deltaTime / LargeWheelRadius;

            foreach (var obstacle in largeWheelObstacles)
            {
                Vector2f offset = obstacle.Position - wheelCenter;
                float angle = (float)Math.Atan2(offset.Y, offset.X);
                angle += angleIncrement;
                float posX = wheelCenter.X + (float)Math.Cos(angle) * LargeWheelRadius;
                float posY = wheelCenter.Y + (float)Math.Sin(angle) * LargeWheelRadius;
                obstacle.Position = new Vector2f(posX, posY);
            }

            angleIncrement = Speed * deltaTime / SmallWheelRadius;

            foreach (var obstacle in smallWheelObstacles)
            {
                Vector2f offset = obstacle.Position - wheelCenter;
                float angle = (float)Math.Atan2(offset.Y, offset.X);
                angle += angleIncrement;
                float posX = wheelCenter.X + (float)Math.Cos(angle) * SmallWheelRadius;
                float posY = wheelCenter.Y + (float)Math.Sin(angle) * SmallWheelRadius;
                obstacle.Position = new Vector2f(posX, posY);
            }
        }

        public void DrawMap(RenderWindow window)
        {
            foreach (var obstacle in largeWheelObstacles)
            {
                obstacle.Draw(window);
            }

            foreach (var obstacle in smallWheelObstacles)
            {
                obstacle.Draw(window);
            }
        }
    }
}





