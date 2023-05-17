namespace Pathinco
{
    using SFML.Graphics;
    using SFML.System;
    public class Circle
    {
       public CircleShape circle = new();

       public Circle(float radius, Vector2f origin, Color color)
       {
           circle = new CircleShape(radius)
           {
               Origin = origin,
               FillColor = color 
           };
       }
    }
}

