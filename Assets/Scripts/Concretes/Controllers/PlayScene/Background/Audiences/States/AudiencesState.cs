using Assets.Scripts.Abtractions;
using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using Spine.Unity;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public abstract class AudiencesState : State
    {
        protected Vector3 targetPosition;
        protected MoveableObject moveableObject;
        protected SkeletonAnimation skeletonAnimation;
        protected IChangeAnimation changeAnimation;

        public override void PerformState()
        {
            StartCoroutine(Sequence());
        }
        public abstract IEnumerator Sequence();
        public abstract void ChangeAnimation(EnumAniAudience enumAni);

    }
}