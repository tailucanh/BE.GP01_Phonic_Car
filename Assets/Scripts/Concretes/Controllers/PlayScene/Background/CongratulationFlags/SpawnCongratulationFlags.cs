using Assets.Scripts.Abtractions;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnCongratulationFlags : SpawnObjectAddressables
    {
        [SerializeField] protected AssetLabelReference assetLabelReference;
        private GameObject _spawnedObject;

        public override void SpawnObjectState()
        {
            Addressables.LoadAssetAsync<GameObject>(assetLabelReference).Completed += (operationHandle) => {
                _spawnedObject = Instantiate(operationHandle.Result);
                _spawnedObject.transform.SetParent(gameObject.transform);
                _spawnedObject.AddComponent<PushUpFlags>();
                _spawnedObject.AddComponent<MoveableFlags>();
            };
        }

        public override void DesSpawnObjectState()
        {
            Destroy(_spawnedObject);
        }

    }
}
