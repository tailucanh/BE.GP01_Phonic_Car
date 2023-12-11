using Assets.Scripts.Abtractions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine;
using Assets.Scripts.Enums;
using Assets.Scripts.Utilities;
using Spine.Unity;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnCarPlay : SpawnObjectAddressables
    {
        [SerializeField] protected AssetLabelReference assetLabelReference;
        private List<GameObject> listsCar = new List<GameObject>();

        private List<string> animationList = new()
        {
            GameHelper.GetDescription(EnumSlectCart.PinkCarSelect),
            GameHelper.GetDescription(EnumSlectCart.OrangeCarSelect),
            GameHelper.GetDescription(EnumSlectCart.BlueCarSelect)
        };

        public override void SpawnObjectState()
        {
            string playerAnimation = GameHelper.GetString(EnumPlayerPrefs.CarSelected.ToString());
            playerAnimation = string.Concat(playerAnimation, "0-1");
            Debug.Log(playerAnimation);
            Addressables.LoadAssetsAsync<GameObject>(assetLabelReference, (itemObj) =>
            {
     
            }).Completed += (operationHandle) =>
            {
               
                List<GameObject> items = operationHandle.Result.ToList();

                for (int i = 0; i < items.Count; i++)
                {
                    GameObject itemObj = items[i];
                    GameObject spawnedObject = Instantiate(itemObj);
                    listsCar.Add(spawnedObject);
                    spawnedObject.transform.SetParent(gameObject.transform);

                    int randomIndex = Random.Range(0, animationList.Count);
                    string selectedAnimation = animationList[randomIndex];
                    animationList.RemoveAt(randomIndex);
                    spawnedObject.GetComponentInChildren<SkeletonAnimation>().AnimationState
                        .SetAnimation(0, string.Concat(selectedAnimation, "0-1"), true);

                    if (spawnedObject.GetComponentInChildren<SkeletonAnimation>().AnimationName == playerAnimation)
                    {
                        spawnedObject.tag = "Player";
                        spawnedObject.AddComponent<PlayerCarState>();
                        spawnedObject.AddComponent<MoveableCarPlay>();
                        spawnedObject.AddComponent<AnimationWheelBoneState>();
                        spawnedObject.GetComponent<PlayerCarState>().UsePlayer = true;
                        spawnedObject.AddComponent<Rigidbody2D>();
                        spawnedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    }
                    else
                    {
                        spawnedObject.AddComponent<BotCarState>();
                        spawnedObject.AddComponent<MoveableCarBot>();
                    }
                }
            };
        }
     
        public List<GameObject> GetListsCar()
        {
            return listsCar;
        }


        public override void DesSpawnObjectState()
        {
            Addressables.Release(listsCar);

        }
    }
}
