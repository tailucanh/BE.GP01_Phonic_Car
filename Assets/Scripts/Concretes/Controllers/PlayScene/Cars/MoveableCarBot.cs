using Assets.Scripts.Abtractions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    internal class MoveableCarBot : MoveableObject
    {

        public override IEnumerator MoveObject(Vector3 destination, float speedTime)
        {

            float startTime = Time.time;

            while (Time.time - startTime < speedTime)
            {
                float t = (Time.time - startTime) / speedTime;

                transform.position = Vector3.Lerp(transform.position, destination, t);

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
