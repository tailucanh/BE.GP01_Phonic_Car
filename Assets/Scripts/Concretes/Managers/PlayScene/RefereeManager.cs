﻿using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using Spine.Unity;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    public class RefereeManager : Manager
    {
        private SpawnReferee _spawnReferee;
        public static RefereeManager Instance { get; private set; }
        private IChangeAnimation changeAnimation;
        private GameObject refereeObject;
        private SkeletonAnimation skeletonAnimation;
        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _spawnReferee = GetComponentInChildren<SpawnReferee>();
            changeAnimation = new ChangeAnimation();
            AdjustObjects();
        }
        public override void AdjustObjects()
        {
            _spawnReferee.SpawnObjectState();
            refereeObject = _spawnReferee.gameObject;
        }

        public void ChangeAnimation(EnumAniReferee aniReferee)
        {
            skeletonAnimation = refereeObject.GetComponentInChildren<SkeletonAnimation>();
            if (skeletonAnimation != null)
            {
                changeAnimation.SwitchAnimation(skeletonAnimation, GameHelper.GetDescription(aniReferee), false);
            }
        }

    }
}
