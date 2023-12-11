
using Assets.Scripts.Abtractions;
using Spine.Unity;
using Spine;
using UnityEngine.AddressableAssets;
using UnityEngine;
using Assets.Scripts.Utilities;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnReferee : SpawnObjectAddressables
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
            Destroy(gameObject);
        }
       

    }
}
