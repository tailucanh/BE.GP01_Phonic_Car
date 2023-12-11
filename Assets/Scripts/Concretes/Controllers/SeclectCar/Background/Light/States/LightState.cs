using Assets.Scripts.Abtractions;
using System;
using System.Collections;

namespace Assets.Scripts.Concretes.Controllers
{
    public abstract class LightState : State
    {
        private void Start()
        {
            PerformState();
        }

        public override void PerformState()
        {
            StartCoroutine(Sequence());
        }

        public abstract IEnumerator Sequence();

    
    }
}
