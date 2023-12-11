using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Enums;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using Spine.Unity;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Concretes.Controllers
{ 
    public class BotCarState : CarState, IPlayerInput, ISpeedable
    {
        [SerializeField] protected bool usePlayer;
        float targetX;
        public bool UsePlayer
        {
            get => usePlayer;
            set => usePlayer = value;
        }
        public float Speed { get; set; }

        public void SetSpeed(float value)
        {
            Speed = value;
        }

        private void Awake()
        {
            currentCarPosition = transform.position;
            changeAnimation = new ChangeAnimation();
            targetX = GameHelper.GetCameraRightBound();
            targetPosition = new(targetX + 3f, transform.position.y, transform.position.z);
        }


        public override IEnumerator SequenceState()
        {
            skeletonAnimation = GetComponent<SkeletonAnimation>();
            moveableCar = GetComponent<MoveableCarBot>();
            changeAnimation.SwitchAnimation(skeletonAnimation, GameHelper.ReplaceLastThreeChar(skeletonAnimation.AnimationName, "1"), true);
            StartCoroutine(moveableCar.MoveObject(targetPosition, Speed));
            yield return null;
        }

        public override IEnumerator SequenceEndGame()
        {
            skeletonAnimation = GetComponent<SkeletonAnimation>();
            moveableCar = GetComponent<MoveableCarBot>();
            targetPosition = new(targetX + 3f, transform.position.y, transform.position.z);
            StartCoroutine(moveableCar.MoveObject(targetPosition, Speed));
            yield return null;
        }
    }
}

