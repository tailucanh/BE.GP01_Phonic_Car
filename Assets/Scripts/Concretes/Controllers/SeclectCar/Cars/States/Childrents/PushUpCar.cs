using Assets.Scripts.Utilities;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PushUpCar : SelectCarState
    {
        private void Awake()
        {
            moveDuration = 0.5f;
            rb = GetComponent<Rigidbody2D>();
            startPosition = transform.position;
            float cameraCenterY = GameHelper.GetMiddleY();
            targetPosition = new Vector3(transform.position.x, cameraCenterY - 0.8f, 0f);
        }
        public override IEnumerator Sequence()
        {
            rb.simulated = false;
            float startTime = Time.time;
            while (elapsedTime < moveDuration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
                elapsedTime = Time.time - startTime;
                yield return null;
            }
            transform.position = targetPosition;
            rb.simulated = true;
        }

    }
}
