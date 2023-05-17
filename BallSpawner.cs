using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.ComponentModel;

namespace Pathinco
{
    public class BallSpawner
    {
        private Vector2f launchDirection;
        private float launchSpeed;
        private Random random;

        public BallSpawner()
        {
            random = new Random();
            launchDirection = new Vector2f(1f, 0f); 
            launchSpeed = 200f; 
        }

        public void HandleInput(Keyboard.Key key)
        {
            switch (key)
            {
                case Keyboard.Key.Left:
                    RotateLaunchDirection(-0.1f);
                    break;
                case Keyboard.Key.Right:
                    RotateLaunchDirection(0.1f);
                    break;
                case Keyboard.Key.Space:
                    SpawnBall();
                    break;
            }
        }

        private void RotateLaunchDirection(float angle)
        {
            float currentAngle = (float)Math.Atan2(launchDirection.Y, launchDirection.X);
            float newAngle = currentAngle + angle;
            launchDirection = new Vector2f((float)Math.Cos(newAngle), (float)Math.Sin(newAngle));
        }

        private void SpawnBall()
        {
            float angle = (float)(random.NextDouble() * 2 * Math.PI);
            Vector2f direction = new Vector2f((float)Math.Cos(angle), (float)Math.Sin(angle));
            Vector2f velocity = direction * launchSpeed;
            Ball ball = new Ball(20f, new Vector2f(0f, 0f), Color.White, velocity);
            Ball.balls.Add(ball);
        }
    }
}