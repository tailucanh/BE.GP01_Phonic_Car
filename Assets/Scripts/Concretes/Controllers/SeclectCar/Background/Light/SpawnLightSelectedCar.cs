using Assets.Scripts.Abtractions;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine;
using Assets.Scripts.Utilities;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnLightSelectedCar : SpawnObjectAddressables
    {
        [SerializeField] protected AssetLabelReference assetLabelReference;
        private GameObject _spawnedObject;

        public override void SpawnObjectState()
        {
            Addressables.LoadAssetAsync<GameObject>(assetLabelReference).Completed += (operationHandle) => {
                _spawnedObject = Instantiate(operationHandle.Result);

                float topCenterPosition =GameHelper.GetCameraTopBound();

                Vector3 setPos =  new(_spawnedObject.transform.position.x,
                    topCenterPosition - ( _spawnedObject.GetComponent<BoxCollider2D>().bounds.size.y / 2),
                    0f);
                _spawnedObject.transform.position = setPos;
                _spawnedObject.transform.SetParent(gameObject.transform);
                _spawnedObject.AddComponent<FadeInLight>();

            };
        }

        public override void DesSpawnObjectState()
        {
            throw new NotImplementedException();
        }
    }
}
