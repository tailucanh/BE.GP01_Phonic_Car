using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using System.Collections;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Assets.Scripts.Concretes.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class PushUpPedestal : SelectCarState
    {
        protected void Awake()
        {
            moveDuration = 0.65f;
            rb = GetComponent<Rigidbody2D>();
            boxCollider = GetComponent<BoxCollider2D>();
            startPosition = transform.position;
            float colliderHeight = boxCollider.bounds.size.y;
            float cameraBottomY = GameHelper.GetCameraBottomBound();
            targetPosition = new Vector3(transform.position.x, cameraBottomY + colliderHeight / 2, 0f);

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