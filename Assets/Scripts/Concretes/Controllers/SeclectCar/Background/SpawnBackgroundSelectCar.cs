using Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine;
using Assets.Scripts.Abtractions;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnBackgroundSelectCar : SpawnObjectAddressables
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
