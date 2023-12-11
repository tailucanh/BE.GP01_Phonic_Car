using Assets.Scripts.Utilities;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class PushUpBoxVocabulary : BoxVocabularyState
    {
        private void Awake()
        {
            moveDuration = 3f;
            boxCollider = GetComponent<BoxCollider2D>();
            float colliderHeight = boxCollider.bounds.size.y;
            float cameraBottomY = GameHelper.GetCameraBottomBound();
            targetPosition = new Vector3(transform.position.x, cameraBottomY + colliderHeight / 2 - 0.15f, 0f);
        }
        public override IEnumerator Sequence()
        {
            moveableObject = GetComponent<MoveableBoxVocabulary>();
            StartCoroutine(moveableObject.MoveObject(targetPosition, moveDuration));
            yield return null;
        }
    }
}
