
using Assets.Scripts.Abtractions;
using UnityEngine.AddressableAssets;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnLineEndGame : SpawnObjectAddressables
    {
        [SerializeField] protected AssetLabelReference assetLabelReference;
        private GameObject _spawnedObject;

        public override void SpawnObjectState()
        {
            Addressables.LoadAssetAsync<GameObject>(assetLabelReference).Completed += (operationHandle) => {
                _spawnedObject = Instantiate(operationHandle.Result);
                _spawnedObject.transform.SetParent(gameObject.transform);
                _spawnedObject.AddComponent<MoveableLineEndGame>();
                _spawnedObject.AddComponent<InitializeLineEndGame>();
            };
        }

        public override void DesSpawnObjectState()
        {
            Destroy(_spawnedObject);
        }

    }
}
