using Assets.Scripts.Abtractions;
using UnityEngine.AddressableAssets;
using UnityEngine;
using Assets.Scripts.Concretes.Managers;

namespace Assets.Scripts.Concretes.Controllers
{
    internal class SpawnHand : SpawnObjectAddressables
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
            Destroy(_spawnedObject);
        }

    }
}
