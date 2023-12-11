
using Assets.Scripts.Enums;

namespace Assets.Scripts.Interfaces
{
    public interface ICollideHandler
    {
        string StateCollide { get; }
        void SetState(EnumStateVocabulary enumState);
    }
}
