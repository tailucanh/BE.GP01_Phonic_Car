using Assets.Scripts.Abtractions;
using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public abstract class FlagsState : State
    {
        [SerializeField] protected float moveDuration;
        protected Vector3 targetPosition;
        protected Vector3 startPosition;
        protected BoxCollider2D boxCollider;
        protected MoveableObject moveableObject;

        private void Start()
        {
            PerformState();
        }
        public override void PerformState()
        {
            StartCoroutine(Sequence());
        }
        public abstract IEnumerator Sequence();

    }
}
