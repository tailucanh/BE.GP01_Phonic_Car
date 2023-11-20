
using UnityEngine.AddressableAssets;
using UnityEngine;
using Assets.Scripts.Utilities;
using System;
using Assets.Scripts.Abtractions;

namespace Assets.Scripts.Concretes.Controllers
{
    internal class SpawnUIBackgroundSplash : SpawnObjectAddressables
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
