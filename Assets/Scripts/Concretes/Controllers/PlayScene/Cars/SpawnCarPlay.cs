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

        private List<string> animationList = new List<string>
        {
            EnumHelper.GetDescription(EnumSlectCart.PinkCarSelect),
            EnumHelper.GetDescription(EnumSlectCart.OrangeCarSelect),
            EnumHelper.GetDescription(EnumSlectCart.BlueCarSelect)
        };

        public override void SpawnObjectState()
        {
            string playerAnimation = PlayerPrefs.GetString(EnumSlectCart.KeySelected.ToString());
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
                    spawnedObject.AddComponent<PlayerCarInput>();
                
                    listsCar.Add(spawnedObject);
                    spawnedObject.transform.SetParent(gameObject.transform);

                    int randomIndex = Random.Range(0, animationList.Count);
                    string selectedAnimation = animationList[randomIndex];
                    animationList.RemoveAt(randomIndex);
                    spawnedObject.GetComponentInChildren<SkeletonAnimation>().AnimationState
                        .SetAnimation(0, selectedAnimation, true);

                    if (spawnedObject.GetComponentInChildren<SkeletonAnimation>().AnimationName == playerAnimation)
                    {
                        spawnedObject.tag = "Player";
                        spawnedObject.GetComponentInChildren<PlayerCarInput>().UseBot = true;
                        spawnedObject.AddComponent<MoveableCarPlay>();
                        spawnedObject.AddComponent<Rigidbody2D>();
                        spawnedObject.GetComponent<Rigidbody2D>().simulated = false;
                        PlayerPrefs.DeleteKey(EnumSlectCart.KeySelected.ToString());
                    }
                    else
                    {
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
