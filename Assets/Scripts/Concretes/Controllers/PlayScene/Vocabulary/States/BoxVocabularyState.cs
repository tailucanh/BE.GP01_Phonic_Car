using Assets.Scripts.Abtractions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{     
    public abstract class BoxVocabularyState : State
    {
        [SerializeField] protected float moveDuration;
        protected Vector3 targetPosition;
        protected Vector3 startPosition;
        protected float elapsedTime = 0f;
        protected BoxCollider2D boxCollider;
        protected Camera mainCamera;

        public override void PerformState()
        {
            StartCoroutine(Sequence());
        }
        public abstract IEnumerator Sequence();

    }
}
