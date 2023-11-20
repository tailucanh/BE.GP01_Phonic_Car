
using Assets.Scripts.Abtractions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnAudioSpeech : SpawnObjectAddressables
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
            throw new System.NotImplementedException();
        }
    }
}
