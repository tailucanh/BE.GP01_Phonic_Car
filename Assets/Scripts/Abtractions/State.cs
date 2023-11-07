using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abtractions
{
    public abstract class State : MonoBehaviour
    {
        public abstract void PerformState();
    }
}
