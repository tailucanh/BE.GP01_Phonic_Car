using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Abtractions
{
    public abstract class MoveableObject : MonoBehaviour
    {
        protected IMovingObject _movingObject;
        public bool IsSmoothness { get; set; }
        private void Awake()
        {
            _movingObject = new MovingObject();
        }
     
        public abstract IEnumerator MoveObject(Vector3 destination, float speedTime);
        public abstract IEnumerator ScaleObject(Vector3 toScale, float speedTime);
  
      

    }
}
