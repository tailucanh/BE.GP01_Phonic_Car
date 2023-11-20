
using Spine.Unity;

namespace Assets.Scripts.Interfaces
{
    public interface IChangeAnimation
    {
        void SwitchAnimation(SkeletonAnimation skeleton, string animation, bool isLoop);

    }
}
