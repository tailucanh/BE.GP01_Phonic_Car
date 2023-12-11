
using Assets.Scripts.Abtractions;
using Assets.Scripts.Interfaces;
using Spine.Unity;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public abstract class CarState : State
    {

        protected SkeletonAnimation skeletonAnimation;
        protected MoveableObject moveableCar;
        protected Vector3 currentCarPosition;
        protected Vector3 targetPosition;
        protected IChangeAnimation changeAnimation;
       
        public override void PerformState()
        {
            StartCoroutine(SequenceState());
        }

        public abstract IEnumerator SequenceState();
        public abstract IEnumerator SequenceEndGame();

    }
}
