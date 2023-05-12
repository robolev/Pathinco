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
                Thread.Sleep(50);
            }
        }

        private void Update(ref Vector2f position, ref Vector2f velocity, float gravity)
        {
            velocity.Y += gravity;


            position += velocity;


            if (position.X - circle.circle.Radius < 0 || position.X + circle.circle.Radius > window.Size.X)
            {
                velocity.X = -velocity.X; 
            }

            if (position.Y + circle.circle.Radius > window.Size.Y)
            {
                velocity.Y = -velocity.Y; 
            }
        }

        private void Render(Vector2f position)
        {
            window.Clear();
            circle.circle.Position = position;
            window.Draw(circle.circle);
            window.Display();
        }
    }
}

