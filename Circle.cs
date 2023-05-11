namespace Pathinco
{
    using SFML.Graphics;
    using SFML.System;
    class Circle
    {
        CircleShape circle = new CircleShape(50);

        public void SetSizesOfCircle()
        {
            circle.Origin = new Vector2f(50, 50);
        }
        public void SetPositionOfCircle(int x,int y)
        {
            circle.Position += new Vector2f(x, y);
        }
        public void SetColour()
        {
            circle.FillColor = Color.Red;
        }
    }
}

