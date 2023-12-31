﻿using Assets.Scripts.Abtractions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class MoveableCarSelect : MoveableObject
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

        protected void CollisionConversion(bool isSimulated)
        {
            Rigidbody2D[] rbs = gameObject.GetComponentsInChildren<Rigidbody2D>();

            foreach (var chilđ in rbs)
            {
                chilđ.simulated = isSimulated;
            }
        }


    }
}
