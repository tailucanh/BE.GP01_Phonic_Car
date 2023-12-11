using Assets.Scripts.Abtractions;
using Assets.Scripts.Implementations;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public abstract class SelectCarState : State
    {
        [SerializeField] protected float moveDuration;
        protected Vector3 targetPosition;
        protected Vector3 startPosition;
        protected float elapsedTime = 0f;
        protected Rigidbody2D rb;
        protected BoxCollider2D boxCollider;

        protected void Start()
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
