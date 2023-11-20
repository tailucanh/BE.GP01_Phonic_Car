using System;
using UnityEngine.AddressableAssets;
using UnityEngine;
using Assets.Scripts.Abtractions;
using Spine.Unity;
using Spine;

namespace Assets.Scripts.Concretes.Controller
{
    public class SpawnCountdown : SpawnObjectAddressables
    {
        [SerializeField] protected AssetLabelReference assetLabelReference;
        private GameObject _spawnedObject;
        public override void SpawnObjectState()
        {
            Addressables.LoadAssetAsync<GameObject>(assetLabelReference).Completed += (operationHandle) => {
                _spawnedObject = Instantiate(operationHandle.Result);
                _spawnedObject.transform.SetParent(gameObject.transform);
            };
        }
        public override void DesSpawnObjectState()
        {

        }


    }
}
