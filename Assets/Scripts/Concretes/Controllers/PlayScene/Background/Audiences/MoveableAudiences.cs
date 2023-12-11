﻿using Assets.Scripts.Abtractions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class MoveableAudiences : MoveableObject
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
                    float journeyLength = (Time.time - startTime) * 0.4f;
                    float fracJourney = journeyLength / distance;
                    _movingObject.Move(this, destination, Mathf.SmoothStep(0f, 1f, fracJourney));

                    yield return null;
                }
            }

            transform.position = destination;
            if (transform.position == destination)
            {
                transform.position = startPos;
            }
        }

        public override IEnumerator ScaleObject(Vector3 toScale, float speedTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
