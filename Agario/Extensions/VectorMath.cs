using SFML.System;
using SFML.Graphics;

namespace Agario.Extensions
{
    static class VectorMath
    {
        public static float Distance(this Vector2f firstVector, Vector2f secondVector)
        {
            float differenceX = firstVector.X - secondVector.X;
            float differenceY = firstVector.Y - secondVector.Y;

            float distanceToOtherPosition = (float)Math.Sqrt((differenceX * differenceX) + (differenceY * differenceY));
            return distanceToOtherPosition;
        }

        public static float DistanceSquared(this Vector2f firstVector, Vector2f secondVector)
        {
            float differenceX = firstVector.X - secondVector.X;
            float differenceY = firstVector.Y - secondVector.Y;

            float result = (differenceX * differenceX) + (differenceY * differenceY);
            return result;
        }

        public static Vector2f Clamp(Vector2f valueVector, Vector2f minVector, Vector2f maxVector)
        {
            float clampedX = Math.Clamp(valueVector.X, minVector.X, maxVector.X);
            float clampedY = Math.Clamp(valueVector.Y, minVector.Y, maxVector.Y);

            return new Vector2f(clampedX, clampedY);
        }

        public static Vector2f[] GetCorners(this FloatRect rectangle)
        {
            Vector2f leftTopCorner = new Vector2f(rectangle.Left, rectangle.Top);
            Vector2f rightTopCorner = new Vector2f(rectangle.Left + rectangle.Width, rectangle.Top);
            Vector2f leftBottomCorner = new Vector2f(rectangle.Left, rectangle.Top + rectangle.Height);
            Vector2f rightBottomCorner = new Vector2f(rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height);

            return new Vector2f[] { leftTopCorner, rightTopCorner, leftBottomCorner, rightBottomCorner };
        }
    }
}
