
using Assets.Scripts.Abtractions;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    public interface IMovingObject
    {
        void Move(MoveableObject _object, Vector3 destination, float speed);
        void Scale(MoveableObject _object, Vector3 toScale, float speed);

    }
}
