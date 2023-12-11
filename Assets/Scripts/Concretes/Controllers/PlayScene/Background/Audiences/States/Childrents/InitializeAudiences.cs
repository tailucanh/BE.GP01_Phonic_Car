using Assets.Scripts.Enums;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using Spine.Unity;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class InitializeAudiences : AudiencesState, ISpeedable
    {
        public float Speed { get; set; }

        public void SetSpeed(float value)
        {
            Speed = value;
        }
        private void Awake()
        {
            changeAnimation = new ChangeAnimation();
        }


        public override IEnumerator Sequence()
        {
            moveableObject = GetComponent<MoveableAudiences>();
            targetPosition = new Vector3(GameHelper.GetCameraLeftBound() - 7.5f, transform.position.y, transform.position.z);
            StartCoroutine(moveableObject.MoveObject(targetPosition, Speed));
            yield return null;
        }

        public override void ChangeAnimation(EnumAniAudience enumAni)
        {
            foreach (var itemAni in GetComponentsInChildren<SkeletonAnimation>())
            {
                skeletonAnimation = itemAni.GetComponent<SkeletonAnimation>();
                int index = skeletonAnimation.AnimationName.IndexOf('-');
                if (index != -1 && index + 2 < skeletonAnimation.AnimationName.Length)
                {
                    string substring = skeletonAnimation.AnimationName.Substring(index + 2).Trim();
                    if(substring.Length > 3)
                    {
                        changeAnimation.SwitchAnimation(skeletonAnimation, GameHelper.ReplaceLastFiveChar(skeletonAnimation.AnimationName, enumAni.ToString()), true);

                    }else
                    {
                        changeAnimation.SwitchAnimation(skeletonAnimation, GameHelper.ReplaceLastThreeChar(skeletonAnimation.AnimationName, enumAni.ToString()), true);

                    }

                }

            }

        }

       
    }
}