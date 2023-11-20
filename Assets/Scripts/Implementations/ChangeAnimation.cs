using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using Spine.Unity;
using System;

namespace Assets.Scripts.Implementations
{
    public class ChangeAnimation : IChangeAnimation
    {
        public void SwitchAnimation(SkeletonAnimation skeleton, string animation, bool isLoop)
        {
            skeleton.AnimationState.SetAnimation(0, animation, isLoop);
        }
    }
}
