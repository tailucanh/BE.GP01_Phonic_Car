using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;

namespace Assets.Scripts.Concretes.Managers
{
    public class TitleSelectCarManager : Manager
    {
        private SpawnTitleSelectCar _sqawmTitleSelectCar;

        public static TitleSelectCarManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _sqawmTitleSelectCar = GetComponentInChildren<SpawnTitleSelectCar>();
        }
        public override void AdjustObjects()
        {
            _sqawmTitleSelectCar.SpawnObjectState();
        }

        public void FadeOutText()
        {
            _sqawmTitleSelectCar.DesSpawnObjectState();
        }

    }
}