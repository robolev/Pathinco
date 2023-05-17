namespace Pathinco
{
    using SFML.Graphics;
    using SFML.System;
    using SFML.Window;
    public class Game
    {
        private RenderWindow window;
        private Ball ball;
        private Ball ball1;
        private Time time;

        public Game()
        {
            window = new RenderWindow(new VideoMode(Config.WindowWidth, Config.WindowHeight), "Moving Circle");
            ball = new Ball(50, new Vector2f(25, 25), Color.Red, new Vector2f(100, 100));
            ball1 = new Ball(50, new Vector2f(25, 25), Color.Blue, new Vector2f(600, 0));
            window.SetFramerateLimit(60);
            time = new Time();
        }

        public void GameLoop()
        {
            window.Closed += (sender, e) => window.Close();
            while (window.IsOpen)
            {
                window.DispatchEvents();

                time.Update();
                float deltaTime = time.DeltaTime;

                ball.Update(deltaTime,ball);
                ball1.Update(deltaTime,ball1);

                Render();
            }
        }

        private void Render()
        {
            window.Clear();

            foreach (var ball in Ball.GetCircles())
            {
                ball.Draw(window);
            }

            window.Display();
        }
    }
}

