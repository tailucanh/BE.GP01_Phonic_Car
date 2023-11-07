using Assets.Scripts.Concretes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public abstract class SpawnObjectAssetbundle : Singleton<SpawnObjectAssetbundle>

    {
        public void LoadAssetBundle(AssetBundle assetBundle, String keyPath)
        {
             assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, Path.Combine("AssetBundles", keyPath)));

            if (assetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                return;
            }

           /*Demo:  var backgroundPrefab = assetBundle.LoadAsset<GameObject>("BackgroundSelectCar");
            if (backgroundPrefab == null)
            {
                Debug.Log("Failed to load BackgroundPrefab by AssetBundle!");
                return;
            }
            _selectCarManager = Instantiate(backgroundPrefab);
            _selectCarManager.transform.SetParent(transform);*/
        }
    }
}
