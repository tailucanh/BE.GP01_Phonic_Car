using Assets.Scripts.Abtractions;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnBackgroundSplash : SpawnObjectAddressables
    {
        [SerializeField] protected AssetReferenceGameObject assetReferenceGameObject;
        private GameObject spawnedGameObject;

        public override void SpawnObjectState()
        {
            assetReferenceGameObject.InstantiateAsync().Completed += (asyncOperation)
                => spawnedGameObject = asyncOperation.Result;

        }
        public override void DesSpawnObjectState()
        {
            assetReferenceGameObject.ReleaseInstance(spawnedGameObject);
        }


    }
}