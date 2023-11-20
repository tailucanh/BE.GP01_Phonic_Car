using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controller;
using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Enums;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using Spine.Unity;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class AnimationReferee : MonoBehaviour
    {
        private SkeletonAnimation skeletonAnimation;
        private IChangeAnimation changeAnimation;
        public static AnimationReferee Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
        }
        public void ChangeAnimationGo()
        {
            changeAnimation = new ChangeAnimation();
            skeletonAnimation = GetComponent<SkeletonAnimation>();
            if (skeletonAnimation != null)
            {
                changeAnimation.SwitchAnimation(skeletonAnimation,EnumHelper.GetDescription(EnumAniReferee.Go), false);
            }
          
        }

       

     
    }
}
