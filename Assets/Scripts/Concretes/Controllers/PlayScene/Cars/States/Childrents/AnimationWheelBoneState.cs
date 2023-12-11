using Assets.Scripts.Enums;
using Assets.Scripts.Utilities;
using Spine;
using Spine.Unity;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    [RequireComponent(typeof(SkeletonAnimation))]
    public class AnimationWheelBoneState : CarState
    {
        private Bone smallWheelBone;
        private Bone largeWheelBone;
        public float rotationSpeed = 360f;

        private void Awake()
        {
            if (!TryGetComponent<SkeletonAnimation>(out skeletonAnimation))
            {
                Debug.LogError("SkeletonAnimation is not assigned!");
                return;
            }
            smallWheelBone = skeletonAnimation.Skeleton.FindBone(GameHelper.GetDescription(EnumWheelBone.WheelBoneSmall));
            largeWheelBone = skeletonAnimation.Skeleton.FindBone(GameHelper.GetDescription(EnumWheelBone.WheelBoneLager)) ;

            if (smallWheelBone == null || largeWheelBone == null)
            {
                Debug.LogError("One or more wheel bones not found!");
            }
        }

      
        public override IEnumerator SequenceState()
        {
            while (true)
            {
                if (smallWheelBone != null && largeWheelBone != null)
                {
                    float rotationSpeed = 180f; // Adjust the speed of rotation as needed
                    smallWheelBone.Rotation += Time.deltaTime * rotationSpeed;
                    Debug.Log(smallWheelBone.Rotation);
                }

                yield return null;
            }
        }

        private void RotateBone(Bone bone)
        {
            if (bone != null)
            {
                float rotationAmount = rotationSpeed * Time.deltaTime;
                bone.Rotation += rotationAmount;
                skeletonAnimation.Skeleton.UpdateWorldTransform();
            }
        }
     
        public override IEnumerator SequenceEndGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
