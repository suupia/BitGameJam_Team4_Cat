using UnityEngine;

namespace Koki
{
    public static class KokiUtility
    {
        public static float Angle360(Vector2 from, Vector2 to)
        {
            float angle = Vector2.Angle(from, to); // Angle in [0,180]
            Vector3 cross = Vector3.Cross(from, to);

            // Did we wrap around?
            if (cross.z > 0)
            {
                angle = 360f - angle; // Angle in [0,360]
            }

            return angle;
        }
    }
}