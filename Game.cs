namespace Pathinco
{
    using SFML.Graphics;
    using SFML.System;
    using SFML.Window;
    public class Game
    {
        private RenderWindow window;
        private Ball ball;

        public Game()
        {
            window = new RenderWindow(new VideoMode(Config.WindowWidth, Config.WindowHeight), "Moving Circle");
            ball = new Ball(50, new Vector2f(25, 25), Color.Red, new Vector2f(100, 100));
            window.SetFramerateLimit(60);
        }

        public void GameLoop()
        {
            window.Closed += (sender, e) => window.Close();
            while (window.IsOpen)
            {
                window.DispatchEvents();               
                ball.Update();
                Render();
            }
        }

        private void Render()
        {
            window.Clear();

            foreach (var circle in Ball.GetCircles())
            {
                ball.Draw(window);
            }

            window.Display();
        }
    }
}

