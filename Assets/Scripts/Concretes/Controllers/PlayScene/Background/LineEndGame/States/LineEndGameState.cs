
using Assets.Scripts.Abtractions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public abstract class LineEndGameState : State
    {
        [SerializeField] protected float moveDuration;
        protected Vector3 targetPosition;
        protected MoveableObject moveableObject;
      
        public override void PerformState()
        {
            StartCoroutine(Sequence());
        }
        public abstract IEnumerator Sequence();

    }
}
