using Assets.Scripts.Enums;
using Assets.Scripts.Utilities;
using Spine;
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
    public class AnimationWheelBoneState : CarPlayState
    {
        private SkeletonAnimation skeletonAnimation;
        private Bone smallWheelBone;
        private Bone largeWheelBone;
        public float rotationSpeed = 360f;

        private void Awake()
        {
            skeletonAnimation = GetComponent<SkeletonAnimation>();
            if (skeletonAnimation == null)
            {
                Debug.LogError("SkeletonAnimation is not assigned!");
                return;
            }
            smallWheelBone = skeletonAnimation.Skeleton.FindBone(EnumHelper.GetDescription(EnumWheelBone.WheelBoneSmall));
            largeWheelBone = skeletonAnimation.Skeleton.FindBone(EnumHelper.GetDescription(EnumWheelBone.WheelBoneLager)) ;

            if (smallWheelBone == null || largeWheelBone == null)
            {
                Debug.LogError("One or more wheel bones not found!");
            }
        }
      /* private void Start()
        {
            StartCoroutine(Sequence());
        }*/
        private void Update()
        {
            float step = (rotationSpeed * Time.time);
            smallWheelBone.Rotation += step;
            smallWheelBone.X += 0.1f;
        }

        public override IEnumerator Sequence()
        {
            while (true)
            {
                // Điều chỉnh tốc độ quay theo thời gian để có hiệu ứng mượt mà
                float step = (rotationSpeed * Time.time );
                smallWheelBone.Rotation += step;
                smallWheelBone.X += 0.1f;
                Debug.Log(smallWheelBone.Rotation);

                // Chờ một frame tiếp theo
                yield return null;
            }
        }
      
    }
}
