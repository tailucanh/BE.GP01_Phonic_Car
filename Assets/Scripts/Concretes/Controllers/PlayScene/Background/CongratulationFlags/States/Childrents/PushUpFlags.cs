using Assets.Scripts.Utilities;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class PushUpFlags : FlagsState
    {
        private readonly float wait1_5 = 1.5f;
        private void Awake()
        {
            moveDuration = 2f;
            boxCollider = GetComponent<BoxCollider2D>();
            float colliderHeight = boxCollider.bounds.size.y;
            float cameraBottomY = GameHelper.GetCameraBottomBound();
            targetPosition = new Vector3(transform.position.x, cameraBottomY + colliderHeight / 2 - 0.2f, 0f);
        }
        public override IEnumerator Sequence()
        {
            startPosition = transform.position;
            moveableObject = GetComponent<MoveableFlags>();
            yield return StartCoroutine(moveableObject.MoveObject(targetPosition, moveDuration));
            yield return wait1_5.Wait();
            StartCoroutine(moveableObject.MoveObject(startPosition, moveDuration));
        }

       
    }
}
