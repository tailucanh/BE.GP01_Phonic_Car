using Assets.Scripts.Abtractions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class MoveableVocabularyItem : MoveableObject
    {

        public override IEnumerator MoveObject(Vector3 destination, float speedTime)
        {
            Vector3 startPos = transform.position;
            float startTime = Time.time;
            float distance = Vector3.Distance(startPos, destination);
            if(distance > 0)
            {
                while (Time.time - startTime < speedTime)
                {
                    float journeyLength = (Time.time - startTime) * (IsSmoothness ? 0.5f : 2.5f);
                    float fracJourney = journeyLength / distance;
                    _movingObject.Move(this, destination, Mathf.SmoothStep(0f, 1f, fracJourney));

                    yield return null;
                }

                transform.position = destination;
                // Iff
             /*   if(transform.position == destination && IsSmoothness)
                {
                    transform.position = startPos;
                }*/
            }
        }

        public override IEnumerator ScaleObject(Vector3 toScale, float scaleDuration)
        {
            Vector3 defaultScale = transform.localScale;

            float startTime = Time.time;
            float elapsedTime = 0f;
            while (elapsedTime < scaleDuration)
            {
                _movingObject.Scale(this, toScale, elapsedTime / scaleDuration);
                elapsedTime = Time.time - startTime;
                yield return null;
            }

            transform.localScale = toScale;

            yield return new WaitForSeconds(0.05f);

            startTime = Time.time;
            elapsedTime = 0f;

            while (elapsedTime < scaleDuration)
            {
                _movingObject.Scale(this, defaultScale, elapsedTime / scaleDuration);
                elapsedTime = Time.time - startTime;
                yield return null;
            }

            transform.localScale = defaultScale;

         
        }
    }
}
