using Assets.Scripts.Abtractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnAudioAudience : SpawnObjectAddressables
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

