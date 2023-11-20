using System;
using UnityEngine;

namespace Assets.Scripts.Abtractions
{
    public abstract class ClickableObject : MonoBehaviour
    {
        public bool IsClickAble { get; set; }
       
        public abstract void Click();
        public abstract void PlayEffect();

    }
}
