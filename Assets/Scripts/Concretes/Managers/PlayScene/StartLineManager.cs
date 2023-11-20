
using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controller;
using Assets.Scripts.Concretes.Controllers;

namespace Assets.Scripts.Concretes.Managers
{
    public class StartLineManager : Manager
    {
        private SpawnStartLine _sqawmStartLine;
        public static StartLineManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _sqawmStartLine = GetComponentInChildren<SpawnStartLine>();
        }
        private void Start()
        {
            AdjustObjects();
        }
        public override void AdjustObjects()
        {
            _sqawmStartLine.SpawnObjectState();
        }

        public void HideStartLine()
        {
            _sqawmStartLine.DesSpawnObjectState();
        }
    }
}
