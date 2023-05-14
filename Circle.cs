namespace Pathinco
{
    using SFML.Graphics;
    using SFML.System;
    public class Circle
    {
       public CircleShape circle = new(50);
       public float Radius { get; }

       public Circle(float radius, Vector2f origin, Color color)
       {
           circle = new CircleShape(radius)
           {
               Origin = origin,
               FillColor = color 
           };
           circle.Radius = 50;
       }
    }
}

