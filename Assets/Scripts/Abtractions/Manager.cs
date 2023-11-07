using Assets.Scripts.Concretes;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Abtractions
{
    public abstract class Manager : Singleton<Manager>
    {
        public abstract void AdjustObjects();
        public abstract void GetData();

    }
}