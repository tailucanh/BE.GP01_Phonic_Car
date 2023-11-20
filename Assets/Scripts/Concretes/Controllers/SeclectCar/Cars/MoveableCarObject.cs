using Assets.Scripts.Abtractions;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Concretes.Controllers
{
    public class MoveableCarObject : MoveableObject
    {

        public override IEnumerator MoveObject(Vector3 destination, float speedTime)
        {
            CollisionConversion(false);
            float startTime = Time.time;
            float elapsedTime = 0f;

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
