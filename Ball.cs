using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Pathinco
{
    public class Ball : Circle
    {
        public static List<Ball> balls = new List<Ball>();

        public float Elasticity { get; set; } = 0.5f;

        public Vector2f Position
        {
            get => circle.Position;
            set => circle.Position = value;
        }

        private Vector2f velocity;

        public Vector2f Velocity
        {
            get => velocity;
            private set => velocity = value;
        }

        const float gravity = 0.5f;

        public Ball(float radius, Vector2f origin, Color color, Vector2f position) : base(radius, origin, color)
        {
            circle.Position = position;
            Velocity = new Vector2f(100, 100);
            balls.Add(this);
        }

        public static List<Ball> GetCircles()
        {
            return balls;
        }

        public void Update(float deltaTime,Ball ball)
        {
            float speedMultiplier = 1.0f - deltaTime * 0.2f;

            Vector2f updatedVelocity = Velocity * speedMultiplier;

            updatedVelocity.Y += gravity;

            CheckBallCollisions(ball);

            if (circle.Position.X < 0 || circle.Position.X > Config.WindowWidth - (2 * circle.Radius))
            {
                updatedVelocity.X *= -1;
            }
            if (circle.Position.Y < 0 || circle.Position.Y > Config.WindowHeight - (2 * circle.Radius))
            {
                updatedVelocity.Y *= -1;
            }

            Vector2f displacement = updatedVelocity * (deltaTime * 4);
            Vector2f newPosition = circle.Position + displacement;

            circle.Position = newPosition;
            Velocity = updatedVelocity;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(circle);
        }

        public void DeleteBall()
        {
            balls.Remove(this);
        }

        private void CheckBallCollisions(Ball ball)
        {
            foreach (Ball otherBall in balls)
            {
                if (otherBall == ball) continue;

                if (CheckCollision(ball.circle, otherBall.circle))
                {
                    Vector2f collisionNormal = otherBall.Position - ball.Position;

                   
                    float magnitude = MathF.Sqrt(collisionNormal.X * collisionNormal.X + collisionNormal.Y * collisionNormal.Y);

                  
                    collisionNormal /= magnitude;

                    
                    Vector2f relativeVelocity = otherBall.Velocity - ball.Velocity;

                    
                    float relativeSpeed = relativeVelocity.X * collisionNormal.X + relativeVelocity.Y * collisionNormal.Y;

                   
                    if (relativeSpeed > 0)
                        continue;

                   
                    float impulseMagnitude = -(1.0f + Elasticity) * relativeSpeed;

                    
                    Vector2f impulse = impulseMagnitude * collisionNormal;

                    ball.Velocity -= impulse;
                    otherBall.Velocity += impulse;
                }
            }
        }

        private bool CheckCollision(Shape shape1, Shape shape2)
        {
            var rect1 = shape1.GetGlobalBounds();
            var rect2 = shape2.GetGlobalBounds();

            return rect1.Intersects(rect2);
        }
    }
}