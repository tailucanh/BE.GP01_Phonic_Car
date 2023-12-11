using Assets.Scripts.Abtractions;
using UnityEngine.AddressableAssets;
using UnityEngine;

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
                _spawnedObject.transform.SetParent(gameObject.transform, false);
            };
        }
     

        public override void DesSpawnObjectState()
        {
            Destroy(_spawnedObject);
        }

    }
}
