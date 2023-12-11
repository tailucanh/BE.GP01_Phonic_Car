using Assets.Scripts.Abtractions;
using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public abstract class SpeedTankState : State
    {
        protected Vector3 targetPosition;
        protected Vector3 startPosition;
        protected MoveableObject moveableObject;
      
        public override void PerformState()
        {
            StartCoroutine(Sequence());
        }
        public abstract IEnumerator Sequence();
        public abstract void PlayEffect();

    }
}
