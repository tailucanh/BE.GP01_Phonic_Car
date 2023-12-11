
using Assets.Scripts.Utilities;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class PushCenterBoxVocabulary : BoxVocabularyState
    {
        private void Awake()
        {
            moveDuration = 2.5f;
            targetPosition = new(GameHelper.GetMiddleX(), GameHelper.GetMiddleY(), transform.position.z);
        }

        public override IEnumerator Sequence()
        {
            moveableObject = GetComponent<MoveableBoxVocabulary>();
            Vector3 toScale = new(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z);
            StartCoroutine(moveableObject.MoveObject(targetPosition, moveDuration));
            StartCoroutine(moveableObject.ScaleObject(toScale, moveDuration));
            yield return null;
        }
    }
}
