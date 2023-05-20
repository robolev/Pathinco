using SFML.Graphics;
using SFML.System;

namespace Pathinco
{
    public class Ball : Circle
    {
        public float Elasticity { get; set; } = 0.5f;

        public Vector2f Position
        {
            get => circle.Position;
            set => circle.Position = value;
        }

        private Vector2f velocity;

        private bool movable;

        public float Radius { get; }
        public Vector2f Origin { get; set; }

        public Vector2f Velocity
        {
            get => velocity;
            private set => velocity = value;
        }

        public Vector2f collisionNormal;

        public  float magnitude;

        const float gravity = 0.5f;

        public CollisiounCheck collisioun = new CollisiounCheck();

        public Ball(float radius, Vector2f origin, Color color, Vector2f position,bool movable) : base(radius, origin, color)
        {
            circle.Position = position;
            Velocity = new Vector2f(100, 100);

            this.movable = movable;
        }

        public void Update(float deltaTime)
        {
            if (!movable)
                  return;

            Vector2f updatedVelocity = CalculateUpdatedVelocity(deltaTime);

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

        private Vector2f CalculateUpdatedVelocity(float deltaTime)
        {
            float speedMultiplier = 1.0f - deltaTime * 2f;

            Vector2f updatedVelocity = Velocity * speedMultiplier;
            updatedVelocity.Y += gravity;

            return updatedVelocity;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(circle);
        }

        public void CheckBallCollisions()
        {
            foreach (Ball otherBall in Game.PhysicalComponents)
            {
                if (otherBall == this) continue;

                if (collisioun.CheckCollision(this.circle, otherBall.circle))
                {
                    CalculateCollisionNormal(otherBall);
                    CalculateMagnitude(collisionNormal);

                    collisionNormal /= magnitude;
                    
                    Vector2f relativeVelocity = otherBall.Velocity - this.Velocity;
                    
                    float relativeSpeed = relativeVelocity.X * collisionNormal.X + relativeVelocity.Y * collisionNormal.Y;
                   
                    if (relativeSpeed > 0)
                        continue;
                   
                    float impulseMagnitude = -(1.0f + Elasticity) * relativeSpeed;
                    
                    Vector2f impulse = impulseMagnitude * collisionNormal;

                    this.Velocity -= impulse;
                    otherBall.Velocity += impulse;
                }
            }
        }
        private void CalculateCollisionNormal(Ball otherBall)
        {
            collisionNormal = otherBall.Position - this.Position;
        }

        private void CalculateMagnitude(Vector2f vector)
        {
            magnitude =  MathF.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }
    }
}