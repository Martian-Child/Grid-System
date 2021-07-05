using UnityEngine;

namespace MartianChild.Utility.Physics
{
    public static class Raycaster
    {

        /// <summary>
        /// <para> Shoots a ray from a specified position in a specified direction and returns true if hit else false. </para>
        /// <param name="rayOrigin"> Origin from which to shoot the ray. </param>
        /// <param name="rayDirection"> Direction in which to shoot the ray.</param>
        /// <param name="maxRaycastDist"> Max distance that ray will shoot. </param>
        /// <param name="hit"> To store raycast hit info. </param>
        /// /// <param name="layerMask"> Layermask that can be hit. </param>
        /// </summary>
        public static bool ShootRay(Vector3 rayOrigin, Vector3 rayDirection, float maxRaycastDist, out RaycastHit hit,  int layerMask = ~0)
        {
            Ray ray = new Ray(rayOrigin, rayDirection);
            return UnityEngine.Physics.Raycast(ray, out hit, maxRaycastDist, layerMask);
        }
        
        /// <summary>
        /// <para> Shoots a ray from a specified position in a specified direction and returns the hit. </para>
        /// <param name="rayOrigin"> Origin from which to shoot the ray. </param>
        /// <param name="rayDirection"> Direction in which to shoot the ray. </param>
        /// <param name="maxRaycastDist"> Max distance that ray will shoot. </param>///
        /// <param name="layerMask"> Layermask that can be hit. </param>
        /// </summary>
        public static RaycastHit ShootRay(Vector3 rayOrigin, Vector3 rayDirection, float maxRaycastDist, int layerMask = ~0)
        {
            Ray ray = new Ray(rayOrigin, rayDirection);
            UnityEngine.Physics.Raycast(ray, out RaycastHit hit, maxRaycastDist, layerMask);
            return hit;
        }
        
        /// <summary>
        /// <para> Shoots a ray from a specified position in a specified direction and returns the hit. </para>
        /// <param name="ray"> Ray to shoot. </param>
        /// <param name="maxRaycastDist"> Max distance that ray will reach from mouse. </param>
        /// <param name="layerMask"> Layermask that can be hit. </param>
        /// </summary>
        public static RaycastHit ShootRay(Ray ray, float maxRaycastDist, int layerMask = ~0)
        {
            UnityEngine.Physics.Raycast(ray, out RaycastHit hit, maxRaycastDist, layerMask);
            return hit;
        }
        
        /// <summary>
        /// <para> Shoots a ray from a specified position in a specified direction and returns the mouse position in world space if there is a hit, else returns Vector3 negative infinity. </para>
        /// <param name="rayOrigin"> Origin from which to shoot the ray. </param>
        /// <param name="rayDirection"> Direction in which to shoot the ray.</param>
        /// <param name="maxRaycastDist"> Max distance that ray will shoot.</param> 
        /// <param name="layerMask"> Layermask that can be hit. </param>
        /// </summary>
        public static Vector3 GetPosFromRayHit(Vector3 rayOrigin, Vector3 rayDirection, float maxRaycastDist,  int layerMask = ~0)
        {
            Ray ray = new Ray(rayOrigin, rayDirection);
            return UnityEngine.Physics.Raycast(ray, out RaycastHit hit, maxRaycastDist, layerMask)
                ? hit.point
                : Vector3.negativeInfinity;
        }
        
        /// <summary>
        /// <para> Shoots a ray from a specified gridPosition in a specified direction and returns the mouse position in world space if there is a hit, else returns Vector3 negative infinity. </para>
        /// <param name="ray"> Ray to shoot. </param>
        /// <param name="maxRaycastDist"> Max distance that ray will shoot.</param> 
        /// <param name="layerMask"> Layermask that can be hit. </param>
        /// </summary>
        public static Vector3 GetPosFromRayHit(Ray ray, float maxRaycastDist,  int layerMask = ~0)
        {
            return UnityEngine.Physics.Raycast(ray, out RaycastHit hit, maxRaycastDist, layerMask)
                ? hit.point
                : Vector3.negativeInfinity;
        }

        /// <summary>
        /// <para> Shoots a ray from a specified gridPosition in a specified direction and returns the gameobject hit if there is one, else it returns null. </para>
        /// <param name="rayOrigin"> Origin from which to shoot the ray. </param>
        /// <param name="rayDirection"> Direction in which to shoot the ray.</param>
        /// <param name="maxRaycastDist"> Max distance that ray will shoot.</param> 
        /// <param name="layerMask"> Layermask that can be hit. </param>
        /// </summary>
        public static GameObject GetObjFromRayHit(Vector3 rayOrigin, Vector3 rayDirection, float maxRaycastDist,  int layerMask = ~0)
        {
            Ray ray = new Ray(rayOrigin, rayDirection);
            return UnityEngine.Physics.Raycast(ray, out RaycastHit hit, maxRaycastDist, layerMask)
                ? hit.transform.gameObject
                : null;
        }
        
        /// <summary>
        /// <para> Shoots a ray from a specified gridPosition in a specified direction and returns the gameobject hit if there is one, else it returns null. </para>
        /// <param name="ray"> Ray to shoot. </param>
        /// <param name="maxRaycastDist"> Max distance that ray will shoot.</param>
        /// <param name="layerMask"> Layermask that can be hit. </param>
        /// </summary>
        public static GameObject GetObjFromRayHit(Ray ray, float maxRaycastDist,  int layerMask = ~0)
        {
            return UnityEngine.Physics.Raycast(ray, out RaycastHit hit, maxRaycastDist, layerMask)
                ? hit.transform.gameObject
                : null;
        }
    }
}

