
using UnityEngine.AddressableAssets;
using UnityEngine;
using Assets.Scripts.Utilities;

namespace Assets.Scripts.Concretes.Controllers
{
    internal class SpawnUIBackgroundSplash : SpawnObjectAddressables
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
