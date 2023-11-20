using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;

namespace Assets.Scripts.Concretes.Managers
{
    public class LightSelectedCarManager : Manager
    {
        private SpawnLightSelectedCar _sqawmLightSelectedCar;
        public static LightSelectedCarManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _sqawmLightSelectedCar = GetComponentInChildren<SpawnLightSelectedCar>();
        }
        
        public override void AdjustObjects()
        {
            _sqawmLightSelectedCar.SpawnObjectState();
        }

    }
}
