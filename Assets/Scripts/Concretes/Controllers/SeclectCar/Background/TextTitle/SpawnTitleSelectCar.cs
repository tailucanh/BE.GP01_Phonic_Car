using UnityEngine.AddressableAssets;
using UnityEngine;
using Assets.Scripts.Abtractions;

namespace Assets.Scripts.Concretes.Controllers
{
    internal class SpawnTitleSelectCar : SpawnObjectAddressables
    {
        [SerializeField] protected AssetLabelReference assetLabelReference;
        private GameObject _spawnedObject;
        public override void SpawnObjectState()
        {
            Addressables.LoadAssetAsync<GameObject>(assetLabelReference).Completed += (operationHandle) => {
                 _spawnedObject = Instantiate(operationHandle.Result);

                _spawnedObject.transform.SetParent(gameObject.transform);
                _spawnedObject.AddComponent<ScaleText>();
            };
        }
        public override void DesSpawnObjectState()
        {
            Destroy(_spawnedObject, 0.25f);

        }

    }
}
