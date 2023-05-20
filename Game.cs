namespace Pathinco
{
    using Microsoft.VisualBasic;
    using SFML.Graphics;
    using SFML.System;
    using SFML.Window;
    public class Game
    {
        private RenderWindow window;
        private Ball ball;
        private Ball ball1;
        private Time time;
        private Map map;
        private BallSpawner ballSpawner;
        public static List<Ball> PhysicalComponents = new List<Ball>();

        public Game()
        {
            window = new RenderWindow(new VideoMode(Config.WindowWidth, Config.WindowHeight), "Moving Circle");
            map = new Map();
          //  ball = new Ball(10, new Vector2f(25, 25), Color.Red, new Vector2f(0, 100),true);
          //  ball1 = new Ball(10, new Vector2f(25, 25), Color.Blue, new Vector2f(600, 0),true);
            window.SetFramerateLimit(60);
            time = new Time();
            ballSpawner = new BallSpawner();
        }
         
        public void GameLoop()
        {
            window.Closed += (sender, e) => window.Close();
         
            while (window.IsOpen)
            {
                window.DispatchEvents();

                HandleInput();

                time.Update();
                float deltaTime = time.DeltaTime;
  
                
                Update(deltaTime);
                ColisiounUpdate();

                Render();
            }
        }
        private void HandleInput()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                ballSpawner.HandleInput(Keyboard.Key.Left);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                ballSpawner.HandleInput(Keyboard.Key.Right);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                ballSpawner.HandleInput(Keyboard.Key.Space);
            }
        }

        private void Update(float  deltaTime)
        {
            map.Update(deltaTime);
            foreach (var ball in PhysicalComponents) 
            {
               ball.Update(deltaTime); 
            }         
        }

        private void ColisiounUpdate()
        {
            foreach (var ball in PhysicalComponents)
            {
                ball.CheckBallCollisions();            
            }                        
        }

        private void Render()
        {
            window.Clear();

            ballSpawner.DrawSpawnPoint(window);

            map.DrawMap(window);
          
            foreach (var ball in PhysicalComponents)
            {
                ball.Draw(window);
            }
           
            window.Display();            
        }      
    }
}

