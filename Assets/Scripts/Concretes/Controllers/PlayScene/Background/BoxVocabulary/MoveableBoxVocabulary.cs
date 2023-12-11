
using Assets.Scripts.Abtractions;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class MoveableBoxVocabulary : MoveableObject
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

        public override IEnumerator ScaleObject(Vector3 toScale, float scaleDuration)
        {

            float startTime = Time.time;
            float elapsedTime = 0f;

            while (elapsedTime < scaleDuration)
            {
                _movingObject.Scale(this, toScale, elapsedTime / scaleDuration);
                elapsedTime = Time.time - startTime;
                yield return null;
            }

            transform.localScale = toScale;

        }
    }
}
