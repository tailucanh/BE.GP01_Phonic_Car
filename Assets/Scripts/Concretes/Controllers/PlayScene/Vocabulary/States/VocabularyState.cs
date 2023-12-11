using Assets.Scripts.Abtractions;
using Assets.Scripts.Implementations;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{     
    public abstract class VocabularyState : State
    {
        protected Vector3 targetPosition;
        protected Vector3 startPosition;
        protected MoveableObject moveableObject;
        public float MissedTurn { get; set; } = 0;

        public override void PerformState()
        {
            StartCoroutine(Sequence());
        }
        public abstract IEnumerator Sequence();
        public abstract IEnumerator PlayEffect();

    }
}
