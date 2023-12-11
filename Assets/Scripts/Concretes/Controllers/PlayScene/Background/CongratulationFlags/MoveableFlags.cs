using Assets.Scripts.Abtractions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class MoveableFlags : MoveableObject
    {
        public override IEnumerator MoveObject(Vector3 destination, float speedTime)
        {
            float elapsedTime = 0f;
            float startTime = Time.time;
            while (elapsedTime < speedTime)
            {
                _movingObject.Move(this, destination, elapsedTime / speedTime);
                elapsedTime = Time.time - startTime;
                yield return null;
            }
            transform.position = destination;
        }

        public override IEnumerator ScaleObject(Vector3 toScale, float speedTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
