
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers.PlayScene
{
    public class PushUpBoxVocabulary : BoxVocabularyState
    {
        private void Awake()
        {
            moveDuration = 1f;
            startPosition = transform.position;
            boxCollider = GetComponent<BoxCollider2D>();
            mainCamera = Camera.main;
            float colliderHeight = boxCollider.bounds.size.y;
            float cameraBottomY = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0f, mainCamera.nearClipPlane)).y;
            targetPosition = new Vector3(transform.position.x, cameraBottomY + colliderHeight / 2 - 0.35f, 0f);
        }
        public override IEnumerator Sequence()
        {
            float startTime = Time.time;
            while (elapsedTime < moveDuration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
                elapsedTime = Time.time - startTime;
                yield return null;
            }
            transform.position = targetPosition;
        }

    }
}
