
using Assets.Scripts.Abtractions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine;
using Assets.Scripts.Enums;
using Spine.Unity;
using System.Linq;

namespace Assets.Scripts.Concretes.Controllers
{
    internal class SpawnVocabulary : SpawnObjectAddressables
    {
        [SerializeField] protected AssetLabelReference assetLabelVocabulary;
        private List<GameObject> listVocabularies = new List<GameObject>();
        private List<AudioClip> listAudioText = new List<AudioClip>();

        public override void SpawnObjectState()
        {
            Addressables.LoadAssetsAsync<AudioClip>(assetLabelVocabulary, (itemObj) =>
            {
                listAudioText.Add(itemObj);
            });

            Addressables.LoadAssetsAsync<GameObject>(assetLabelVocabulary, (itemObj) =>
            {

            }).Completed += (operationHandle) =>
            {
                List<GameObject> items = operationHandle.Result.ToList();

                for (int i = 0; i < items.Count; i++)
                {
                    GameObject itemObj = items[i];
                    GameObject spawnedObject = Instantiate(itemObj);

                    listVocabularies.Add(spawnedObject);
                    spawnedObject.transform.SetParent(gameObject.transform);

                }
            };
           

        }

        public List<GameObject> GetListVocabulary()
        {
            return listVocabularies;
        }
        public List<AudioClip> GetListAudioes()
        {
            return listAudioText;
        }


        public override void DesSpawnObjectState()
        {
            throw new System.NotImplementedException();
        }
    }
    
}
