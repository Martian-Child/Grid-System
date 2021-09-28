using MartianChild.Utility.Physics;
using UnityEngine;

namespace MartianChild.Utility.Mouse
{
    public static class MouseCaster
    {
        /// <summary>
        /// <para> Shoots a ray from mouse to world and returns the hit. </para>
        /// <param name="maxRaycastDist"> max distance that ray will reach from mouse. </param>
        /// <param name="camera"> camera from which to get mouse gridPosition from. </param>
        /// <param name="layerMask"> layers allowed to be hit. </param>
        /// </summary>
        public static RaycastHit ShootRayFromMouseToWorld(Camera camera, float maxRaycastDist, int layerMask = ~0)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            return Raycaster.ShootRay(ray, maxRaycastDist, layerMask);
        }
        
        /// <summary>
        /// <para> Shoots a ray from mouse to world and returns the mouse gridPosition in world space if there is a hit, else returns Vector3 negative infinity. </para>
        /// <param name="maxRaycastDist"> max distance that ray will reach from mouse. </param>
        /// <param name="layerMask"> layers allowed to be hit. </param>
        /// </summary>
        public static Vector3 GetWorldPosUnderMouse(Camera camera, float maxRaycastDist, int layerMask = ~0)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            return Raycaster.GetPosFromRayHit(ray, maxRaycastDist, layerMask);
        }

        /// <summary>
        /// <para> Shoots a ray from mouse to world and returns the gameobject under the mouse if there is one, else it returns null. </para>
        /// <param name="maxRaycastDist"> max distance that ray will reach from mouse. </param>
        /// <param name="layerMask"> layers allowed to be hit. </param>
        /// </summary>
        public static GameObject GetObjUnderMouse(Camera camera, float maxRaycastDist, int layerMask = ~0)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            return Raycaster.GetObjFromRayHit(ray, maxRaycastDist, layerMask);
        }
    }
}
  