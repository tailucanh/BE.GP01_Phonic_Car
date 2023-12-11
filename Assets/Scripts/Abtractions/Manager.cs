using UnityEngine;

namespace Assets.Scripts.Abtractions
{
    public abstract class Manager : MonoBehaviour
    {
        protected float wait0_2 = 0.2f;
        protected float wait0_3 = 0.3f;
        protected float wait0_4 = 0.4f;
        protected float wait0_5 = 0.5f;
        protected float wait0_85 = 0.85f;
        protected float wait1 = 1f;
        protected float wait1_5 = 1.5f;
        protected float wait2 = 2f;
        protected float wait2_5 = 2.5f;
        protected float wait3 = 3f;
        protected float wait3_5 = 3.5f;
        protected float wait4 = 4f;
        protected float wait4_5 = 4.5f;
        protected float wait5 = 5f;
        protected float wait5_5 = 5.5f;
        protected float wait6 = 6f;
        protected float wait6_5 = 6.5f;
        public abstract void AdjustObjects();

    }
}