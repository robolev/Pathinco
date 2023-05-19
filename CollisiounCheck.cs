using SFML.Graphics;

namespace Pathinco
{
    public class CollisiounCheck
    {
        public bool CheckCollision(Shape shape1, Shape shape2)
        {
            var rect1 = shape1.GetGlobalBounds();
            var rect2 = shape2.GetGlobalBounds();

            return rect1.Intersects(rect2);
        }
    }
}
