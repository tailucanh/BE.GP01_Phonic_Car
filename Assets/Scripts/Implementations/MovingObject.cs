using Assets.Scripts.Abtractions;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    public class MovingObject : IMovingObject
    {
        public void Move(MoveableObject _object, Vector3 destination, float speed)
        {
            Vector3 current = _object.transform.position;
            _object.transform.position = Vector3.Lerp(current, destination, speed);
        }



        public void Scale(MoveableObject _object, Vector3 toScale, float speed)
        {
            Vector3 currentScale = _object.transform.localScale;
            _object.transform.localScale = Vector3.Lerp(currentScale, toScale, speed);
        }
    }
}
