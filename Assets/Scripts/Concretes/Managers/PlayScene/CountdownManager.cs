using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controller;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    public class CountdownManager : Manager
    {
        private SpawnCountdown _sqawmCountdown;
        public static CountdownManager Instance { get; private set; }
        private GameObject countdownObj;
        private IChangeAnimation changeAnimation;
        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _sqawmCountdown = GetComponentInChildren<SpawnCountdown>();
            changeAnimation = new ChangeAnimation();
        }
        public override void AdjustObjects()
        {
            _sqawmCountdown.SpawnObjectState();
             countdownObj = _sqawmCountdown.gameObject;
            if (countdownObj != null)
            {
                SkeletonAnimation skeletonAnimation = countdownObj.GetComponent<SkeletonAnimation>();

                if (skeletonAnimation != null)
                {
                    changeAnimation.SwitchAnimation(skeletonAnimation, "Countdown", false);
                }
            }
        }
        

     


    }
}
