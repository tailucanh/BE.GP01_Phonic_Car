
using Assets.Scripts.Abtractions;
using System.Collections;

namespace Assets.Scripts.Concretes.Controllers
{
    public abstract class CarPlayState : State
    {
        public override void PerformState()
        {
            StartCoroutine(Sequence());
        }
        public abstract IEnumerator Sequence();



    }
}
