namespace Pathinco
{
    using SFML.Graphics;
    using SFML.System;
    public class Circle
    {
       public CircleShape circle = new(50);
       public float Radius { get; }

       public static List<Circle> circles = new List<Circle>();
       public Circle(float radius, Vector2f origin, Color color)
       {
           circle = new CircleShape(radius)
           {
               Origin = origin,
               FillColor = color 
           };
           circle.Radius = 50;
           circles.Add(this);
       }
        public static void SetPositionOfCircle(int index, Vector2f position)
        {
            if (index >= 0 && index < circles.Count)
            {
                circles[index].circle.Position += position;
            }
        }
        public static List<Circle> GetCircles()
        {
            return circles;
        }
    }
}

