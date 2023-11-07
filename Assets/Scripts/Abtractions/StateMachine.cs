using Assets.Scripts.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abtractions
{
    public abstract class StateMachine : Singleton<StateMachine>
    {
        [SerializeField] protected GameObject CurrentState;
        public void UpdateState(State state)
        {
            state.PerformState();
        }
        public abstract void HandleStart();

        public State GetCurrentState()
        {
            return CurrentState.GetComponent<State>();
        }
    }
}
