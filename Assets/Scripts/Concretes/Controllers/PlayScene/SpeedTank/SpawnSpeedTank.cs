using Assets.Scripts.Abtractions;
using UnityEngine.AddressableAssets;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Concretes.Controllers
{
    internal class SpawnSpeedTank : SpawnObjectAddressables
    {
        [SerializeField] protected AssetLabelReference assetLabelSpeedTank;
        private List<GameObject> listSpeedTank = new();

        public override void SpawnObjectState()
        {
            Addressables.LoadAssetsAsync<GameObject>(assetLabelSpeedTank, (itemObj) =>
            {

            }).Completed += (operationHandle) =>
            {
                List<GameObject> items = operationHandle.Result.ToList();

                for (int i = 0; i < items.Count; i++)
                {
                    GameObject itemObj = items[i];
                    GameObject spawnedObject = Instantiate(itemObj);
                    spawnedObject.AddComponent<ColliderSpeedTankState>();
                    spawnedObject.AddComponent<MoveableSpeedTank>();
                    listSpeedTank.Add(spawnedObject);
                    spawnedObject.transform.SetParent(gameObject.transform);


                }
            };
        }

        public List<GameObject> GetListSpeedTank()
        {
            return listSpeedTank;
        }

        public override void DesSpawnObjectState()
        {

        }

    }
}