using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;

namespace Assets.Scripts.Concretes.Managers
{
    public class SplashSceneManager : Manager
    {
        private SpawnObjectAddressables spawnBackground;
        private SpawnObjectAddressables spawnUI;


        private void Awake() 
        {
            spawnBackground = GetComponentInChildren<SpawnBackgroundSplash>();
            spawnUI = GetComponentInChildren<SpawnUIBackgroundSplash>();
            AdjustObjects();
        }

        public override void AdjustObjects()
        {
            spawnBackground.SpawnObjectState();
            spawnUI.SpawnObjectState();
        }


    }
}
