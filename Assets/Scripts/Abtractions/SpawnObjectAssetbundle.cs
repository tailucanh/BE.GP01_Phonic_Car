using System;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Abtractions
{
    public abstract class SpawnObjectAssetbundle : MonoBehaviour

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
