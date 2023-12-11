using Assets.Scripts.Enums;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using Spine.Unity;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class PlayerCarState : CarState, IPlayerInput
    {
        [SerializeField] protected bool usePlayer;
        private string playerAnimation;
        private readonly float wait1 = 1f;
        private readonly float wait0_5 = 0.5f;
        private float centerX;
        public bool UsePlayer
        {
            get => usePlayer;
            set => usePlayer = value;
        }

        private void Awake()
        {
            skeletonAnimation = GetComponent<SkeletonAnimation>();
            centerX = GameHelper.GetMiddleX();
            changeAnimation = new ChangeAnimation();
            playerAnimation = GameHelper.GetString(EnumPlayerPrefs.CarSelected.ToString());
        }

        public override IEnumerator SequenceState()
        {
            currentCarPosition = transform.position;
            moveableCar = GetComponent<MoveableCarPlay>();
            moveableCar.IsSmoothness = true;
            Vector3 endChange = new(centerX + 1f, currentCarPosition.y, currentCarPosition.z);
            changeAnimation.SwitchAnimation(skeletonAnimation, string.Concat(playerAnimation + "2"), true);
            yield return StartCoroutine(moveableCar.MoveObject(endChange, 3.5f));
            changeAnimation.SwitchAnimation(skeletonAnimation, string.Concat(playerAnimation + "2-1"), true);
            Vector3 backChange = new(currentCarPosition.x, transform.position.y, transform.position.z);
            yield return wait1.Wait();
            changeAnimation.SwitchAnimation(skeletonAnimation, string.Concat(playerAnimation + "1"), true);
            StartCoroutine(moveableCar.MoveObject(backChange, 3.5f));
        }

        public override IEnumerator SequenceEndGame()
        {
            currentCarPosition = transform.position;
            moveableCar = GetComponent<MoveableCarPlay>();
            moveableCar.IsSmoothness = true;
            Vector3 centerPos = new(centerX + 1f, currentCarPosition.y, currentCarPosition.z);
            changeAnimation.SwitchAnimation(skeletonAnimation, string.Concat(playerAnimation + "1-3"), true);
            yield return wait0_5.Wait();
            changeAnimation.SwitchAnimation(skeletonAnimation, string.Concat(playerAnimation + "3"), true);
            yield return StartCoroutine(moveableCar.MoveObject(centerPos, 3.5f));
            Vector3 endPos = new(GameHelper.GetCameraRightBound() + 3f, transform.position.y, transform.position.z);
            yield return wait1.Wait();
            yield return StartCoroutine(moveableCar.MoveObject(endPos, 3.5f));
            changeAnimation.SwitchAnimation(skeletonAnimation, string.Concat(playerAnimation + "1"), true);
        }
    }
}
