using Assets.Scripts.Abtractions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class MoveableSpeedTank : MoveableObject
    {
        public override IEnumerator MoveObject(Vector3 destination, float speedTime)
        {
            Vector3 startPos = transform.position;
            float startTime = Time.time;
            float distance = Vector3.Distance(startPos, destination);
            if (distance > 0)
            {
                while (Time.time - startTime < speedTime)
                {
                    float journeyLength = (Time.time - startTime) * 0.5f;
                    float fracJourney = journeyLength / distance;
                    _movingObject.Move(this, destination, Mathf.SmoothStep(0f, 1f, fracJourney));

                    yield return null;
                }

                transform.position = destination;
            }
        }

        public override IEnumerator ScaleObject(Vector3 toScale, float speedTime)
        {

            float startTime = Time.time;
            float elapsedTime = 0f;

            while (elapsedTime < speedTime)
            {
                _movingObject.Scale(this, toScale, elapsedTime / speedTime);
                elapsedTime = Time.time - startTime;
                yield return null;
            }

            transform.localScale = toScale;
        }
    }
}
