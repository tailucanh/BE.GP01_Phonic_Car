using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

namespace Assets.Scripts.Utilities
{
    public abstract class SpawnObjectAddressables : MonoBehaviour
    {
        protected AsyncOperationHandle<GameObject> handle;

        public abstract void SpawnObjectState();
        protected GameObject LoadAssetByLableReference(AssetLabelReference assetLabelReference)
        {
            GameObject _gameObject = null;
            handle = Addressables.LoadAssetAsync<GameObject>(assetLabelReference);
            handle.Completed += 
                (asyncOperationHandle) =>{
                    if(asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        _gameObject = Instantiate(asyncOperationHandle.Result,transform);
                    }
                    else
                    {
                        Debug.LogError("Failed load asset by lable: " + assetLabelReference.ToString());
                    }
                };
            return _gameObject;
        }
       


    }
}
