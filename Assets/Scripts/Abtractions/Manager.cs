using Assets.Scripts.Concretes;
using Assets.Scripts.Concretes.Managers;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Abtractions
{
    public abstract class Manager : MonoBehaviour
    {
        public abstract void AdjustObjects();
        public WaitForSeconds GetDelaySecond(float time)
        {
            return new WaitForSeconds(time);
        }
        public WaitWhile GetDelayWhile(Func<bool> predicate)
        {
             return new WaitWhile(predicate);
        }

    }
}