namespace Pathinco
{
    using SFML.Graphics;
    using SFML.System;
    using SFML.Window;
    public class Game
    {
        private RenderWindow window;
        private Circle circle;

        public void GameLoop()
        {
            window = new RenderWindow(new VideoMode(800, 600), "Moving Circle");
            window.Closed += (sender, e) => window.Close();

            circle = new Circle(50, new Vector2f(-50, 50), Color.Red);       

            Vector2f position = circle.circle.Position;
            Vector2f velocity = new Vector2f(2, 0); 
            const float gravity = 0.5f; 

            while (window.IsOpen)
            {
                window.DispatchEvents();
                Update(ref position, ref velocity, gravity);
                Render(position);
                Thread.Sleep(30);
            }
        }

        private void Update(ref Vector2f position, ref Vector2f velocity, float gravity)
        {
            velocity.Y += gravity;

            position += velocity;

            if (position.X - circle.circle.Radius < 0)
            {
                position.X = circle.circle.Radius; 
                velocity.X = -velocity.X; 
            }
            else if (position.X + circle.circle.Radius > window.Size.X)
            {
                position.X = window.Size.X - circle.circle.Radius; 
                velocity.X = -velocity.X;
            }

            if (position.Y + circle.circle.Radius > window.Size.Y)
            {
                position.Y = window.Size.Y - circle.circle.Radius; 
                velocity.Y = -velocity.Y; 
            }
        }

        private void Render(Vector2f position)
        {
            window.Clear();
            circle.circle.Position = position;
            foreach (var circle in Circle.GetCircles())
            {
                window.Draw(circle.circle);
            }
            window.Display();
        }
    }
}

