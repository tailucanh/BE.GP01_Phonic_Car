using UnityEngine.AddressableAssets;
using UnityEngine;
using Assets.Scripts.Abtractions;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.Utilities;
using Spine.Unity;
using System.Linq;
using System.Collections;
using Assets.Scripts.Concretes.Managers;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnBoxSelectCar : SpawnObjectAddressables
    {
        [SerializeField] protected AssetLabelReference assetLabelReference;
        private List<GameObject> listBoxsCar = new List<GameObject>();
        private List<string> animationList = new List<string>
        {
            GameHelper.GetDescription(EnumSlectCart.PinkCar),
            GameHelper.GetDescription(EnumSlectCart.OrangeCar),
            GameHelper.GetDescription(EnumSlectCart.BlueCar)
        };
        private AudioSource _audioSource;
        private float wait0_5 = 0.5f;

        public override void SpawnObjectState()
        {
            Addressables.LoadAssetsAsync<GameObject>(assetLabelReference, (itemObj) =>
            {
              
            }).Completed += (operationHandle) => {

                List<GameObject> items = operationHandle.Result.ToList();
                SpawnObjectsWithDelay(items, 0.2f);
            };
        }
        private void SpawnObjectsWithDelay(List<GameObject> items, float delay)
        {
            StartCoroutine(SpawnObjects(items, delay));
        }
        private IEnumerator SpawnObjects(List<GameObject> items, float delay)
        {
            for (int i = 0; i < items.Count; i++)
            {
                GameObject itemObj = items[i];
                GameObject spawnedObject = Instantiate(itemObj);
                spawnedObject.AddComponent<MoveableCarSelect>();
                listBoxsCar.Add(spawnedObject);
                _audioSource = spawnedObject.GetComponent<AudioSource>();
                GameHelper.AddComponentsToChildrenWithTag(spawnedObject, "Car", typeof(PushUpCar));
                GameHelper.AddComponentsToChildrenWithTag(spawnedObject, "Car", typeof(ScaleObjectCollision));
                GameHelper.AddComponentsToChildrenWithTag(spawnedObject, "Pedestal", typeof(PushUpPedestal));
              
                spawnedObject.transform.SetParent(gameObject.transform);
                int randomIndex = Random.Range(0, animationList.Count);
                string selectedAnimation = animationList[randomIndex];
                animationList.RemoveAt(randomIndex);
                spawnedObject.GetComponentInChildren<SkeletonAnimation>().AnimationState
                    .SetAnimation(0, selectedAnimation, true);
              
                yield return delay.Wait();
                AudioSelectCarManager.Instance.PlaySfx(_audioSource);
                GameHelper.AddComponentsToChildrenWithTag(spawnedObject, "Car", typeof(ClickableCarObject));
            }
            yield return wait0_5.Wait();
            TitleSelectCarManager.Instance.AdjustObjects();
        }

      
        public List<GameObject> GetListBoxsCar()
        {
            return listBoxsCar;
        }
        public override void DesSpawnObjectState()
        {
            Addressables.Release(listBoxsCar);
        }
    }
}
