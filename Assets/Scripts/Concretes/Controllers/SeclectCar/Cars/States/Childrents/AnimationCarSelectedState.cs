using Assets.Scripts.Interfaces;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    [RequireComponent(typeof(SkeletonAnimation))]
    public class AnimationCarSelectedState : SelectCarState,IAnimationSelect
    {
        private SkeletonAnimation skeletonAnimation;
        private void Awake()
        {
            skeletonAnimation = GetComponent<SkeletonAnimation>();

            if (skeletonAnimation == null)
            {
                Debug.LogError("SkeletonAnimation component not found!");
                return;
            }
        }
        
        public override IEnumerator Sequence()
        {
            GetAnimation();
            yield return null;
        }


        public string GetAnimation()
        {
            return skeletonAnimation.AnimationState.GetCurrent(0).Animation.Name;
        }
    }
}
