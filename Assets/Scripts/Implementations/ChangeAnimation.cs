using Assets.Scripts.Interfaces;
using Spine.Unity;

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
