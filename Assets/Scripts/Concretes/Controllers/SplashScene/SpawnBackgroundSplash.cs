using Assets.Scripts.Utilities;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnBackgroundSplash : SpawnObjectAddressables
    {
        [SerializeField] protected AssetLabelReference AssetLabelReference;

        public override void SpawnObjectState()
        {
            LoadAssetByLableReference(AssetLabelReference);
        }

        private void OnDestroy()
        {
            Addressables.Release(this.handle);
        }

    }
}