
using Assets.Scripts.Abtractions;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnAudioSelectedCar : SpawnObjectAddressables
    {
        [SerializeField] protected AssetLabelReference assetLabelListAudio;
        private List<AudioClip> listAudios = new List<AudioClip>();

        public override void SpawnObjectState()
        {
            Addressables.LoadAssetsAsync<AudioClip>(assetLabelListAudio, (itemObj) =>
            {
                listAudios.Add(itemObj);
            });

          
        }

        public List<AudioClip> GetListAudios()
        {
            return listAudios; 
        }
      
        public override void DesSpawnObjectState()
        {
            Addressables.Release(listAudios);
        }
    }
}
