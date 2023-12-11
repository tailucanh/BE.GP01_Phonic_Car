using Assets.Scripts.Utilities;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class MissedVocabularyState : VocabularyState
    {
        private void Start()
        {
            targetPosition = new Vector3(GameHelper.GetCameraLeftBound() - 2f, transform.position.y, transform.position.z);
        }

        public override IEnumerator Sequence()
        {
            moveableObject = GetComponent<MoveableVocabularyItem>();
            moveableObject.IsSmoothness = true;
            Vector3 delayPosition = new(GameHelper.GetCameraRightBound() - 3.5f, transform.position.y, transform.position.z);
            yield return StartCoroutine(moveableObject.MoveObject(delayPosition, 3f));
        }

        public override IEnumerator PlayEffect()
        {
            throw new NotImplementedException();
        }
    }
}
