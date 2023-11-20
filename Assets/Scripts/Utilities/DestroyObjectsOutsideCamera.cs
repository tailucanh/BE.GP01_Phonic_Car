using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class DestroyObjectsOutsideCamera : MonoBehaviour
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
            Renderer renderer = gameObject.GetComponent<Renderer>();
            if (renderer != null)
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
