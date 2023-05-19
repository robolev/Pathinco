using Pathinco;
using SFML.Graphics;
using SFML.System;

namespace Pathinco
{
    public class Map
    {
        public List<Ball> balls;

        float radius = 20f;

        int numRows = 4;
        int numCols = 10;
        int top = 50;

        public Map()
        {
            balls = new List<Ball>();
            CreateMap();
        }

        private void CreateMap()
        {         
            float spacingX = 4 * radius;
            float spacingY = 4 * radius;
        
            int middleRow = numRows / 2;
            int middleCol = numCols / 2;
            
            Vector2f startPosition = new Vector2f(400f - (middleCol * spacingX), 300f - (middleRow * spacingY - top));

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    float posX = startPosition.X + col * spacingX + (row % 2 == 0 ? spacingX / 2 : 0);
                    float posY = startPosition.Y + row * spacingY;
                    Ball ball = new Ball(radius, new Vector2f(0, 0), Color.White, new Vector2f(posX, posY),false); 
                    balls.Add(ball);        
                }
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

