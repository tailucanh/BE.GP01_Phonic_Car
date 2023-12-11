using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class DisableObjectsOutsideCamera : MonoBehaviour
    {
        public Camera mainCamera;

        void Start()
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }

        }
        void Update()
        {
            CheckAndHideObjects();
        }
        void CheckAndHideObjects()
        {
            if (gameObject.TryGetComponent<Renderer>(out var renderer))
            {
                if (!IsObjectInView(renderer))
                {
                    renderer.enabled = false;
                }
            }
           
        }

        bool IsObjectInView(Renderer renderer)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
            return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
        }
    }
}
