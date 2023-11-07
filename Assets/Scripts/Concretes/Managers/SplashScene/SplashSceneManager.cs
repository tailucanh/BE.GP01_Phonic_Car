using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;

namespace Assets.Scripts.Concretes.Managers
{
    public class SplashSceneManager : Manager
    {
        private SpawnBackgroundSplash spawnBackground;
        private SpawnUIBackgroundSplash spawnUI;


        private void Awake() 
        {
            spawnBackground = GetComponentInChildren<SpawnBackgroundSplash>();
            spawnUI = GetComponentInChildren<SpawnUIBackgroundSplash>();
            GetData();
        }

        public override void AdjustObjects()
        {
            throw new System.NotImplementedException();
        }

        public override void GetData()
        {
            spawnBackground.SpawnObjectState();
            spawnUI.SpawnObjectState();
        }

    }
}
