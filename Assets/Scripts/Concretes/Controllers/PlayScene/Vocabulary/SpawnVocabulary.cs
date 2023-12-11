using Assets.Scripts.Abtractions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Utilities;
using Assets.Scripts.Enums;

namespace Assets.Scripts.Concretes.Controllers
{
    internal class SpawnVocabulary : SpawnObjectAddressables
    {
        [SerializeField] protected List<AssetLabelReference> listLabels;
        private List<GameObject> listVocabularies = new();
        private List<AudioClip> listAudioText = new();
        private int leverSelected = 0;

        public override void SpawnObjectState()
        {
            leverSelected = GameHelper.GetInt(EnumPlayerPrefs.VocabularyLever.ToString());

            Addressables.LoadAssetsAsync<AudioClip>(listLabels[leverSelected], (itemObj) =>
            {
                listAudioText.Add(itemObj);
            });

            Addressables.LoadAssetsAsync<GameObject>(listLabels[leverSelected], (itemObj) =>
            {

            }).Completed += (operationHandle) =>
            {
                List<GameObject> items = operationHandle.Result.ToList();

                for (int i = 0; i < items.Count; i++)
                {
                    GameObject itemObj = items[i];
                    GameObject spawnedObject = Instantiate(itemObj);
                    spawnedObject.AddComponent<MoveableVocabularyItem>();
                    spawnedObject.AddComponent<ColliderVocabularyState>();
                    spawnedObject.AddComponent<MissedVocabularyState>();

                    GameObject childObject = spawnedObject.transform.GetChild(0).gameObject;
                    childObject.AddComponent<FadeInVocabulary>();
          
                    listVocabularies.Add(spawnedObject);
                    spawnedObject.transform.SetParent(gameObject.transform);
                    childObject.GetComponent<VocabularyState>().PerformState();
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
