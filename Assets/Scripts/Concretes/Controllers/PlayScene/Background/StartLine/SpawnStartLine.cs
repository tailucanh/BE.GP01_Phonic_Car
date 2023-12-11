
using Assets.Scripts.Abtractions;
using UnityEngine.AddressableAssets;
using UnityEngine;
using Assets.Scripts.Utilities;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnStartLine : SpawnObjectAddressables
    {
        [SerializeField] protected AssetLabelReference assetLabelReference;
        private GameObject _spawnedObject;

        public override void SpawnObjectState()
        {
            Addressables.LoadAssetAsync<GameObject>(assetLabelReference).Completed += (operationHandle) => {
                _spawnedObject = Instantiate(operationHandle.Result);
                _spawnedObject.transform.SetParent(gameObject.transform);
                _spawnedObject.AddComponent<DisableObjectsOutsideCamera>();
            };
        }

        public override void DesSpawnObjectState()
        {
            Destroy(_spawnedObject);
        }

    }
}
