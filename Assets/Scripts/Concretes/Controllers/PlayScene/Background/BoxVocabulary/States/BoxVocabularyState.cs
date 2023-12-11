
using Assets.Scripts.Abtractions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public abstract class BoxVocabularyState : State
    {
        protected float moveDuration;
        protected Vector3 targetPosition;
        protected BoxCollider2D boxCollider;
        protected MoveableObject moveableObject;

        public override void PerformState()
        {
            StartCoroutine(Sequence());
        }
        public abstract IEnumerator Sequence();

    }
}
