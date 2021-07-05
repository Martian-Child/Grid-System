using UnityEngine;

namespace MartianChild.Utility.Unity_Extensions
{
    public static class Vector3Extensions 
    {
        public static void RotateAroundPivot(this ref Vector3 point, Vector3 pivot, Vector3 pivotAngles)
        {
            Vector3 dir = point - pivot; // get point direction relative to pivot
            dir = Quaternion.Euler(pivotAngles) * dir; // rotate it
            point = dir + pivot; // calculate rotated point
        }
        
        public static void Snap(this ref Vector3 v, float snapValue)
        {
            Vector3 snappedVector = new Vector3
            (
                snapValue * Mathf.Round(v.x / snapValue),
                snapValue * Mathf.Round(v.y / snapValue),
                snapValue * Mathf.Round(v.z / snapValue)
            );

            v = snappedVector;
        }
    }
    
    public static class Vector2Extensions 
    {
        public static Vector2 RotateAroundPivot(this Vector2 point, Vector2 pivot, Vector2 pivotAngles)
        {
            Vector2 dir = point - pivot; // get point direction relative to pivot
            dir = Quaternion.Euler(pivotAngles) * dir; // rotate it
            point = dir + pivot; // calculate rotated point
            return point; // return it
        }
    }
}
