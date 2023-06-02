using SFML.System;

namespace Agario
{
    static class VectorMath
    {
        public static float DistanceTo(this Vector2f firstVector, Vector2f secondVector)
        {
            float differenceX = firstVector.X - secondVector.X;
            float differenceY = firstVector.Y - secondVector.Y;

            float distanceToOtherPosition = (float)Math.Sqrt(differenceX * differenceX + differenceY * differenceY);
            return distanceToOtherPosition;
        }

    }
}
