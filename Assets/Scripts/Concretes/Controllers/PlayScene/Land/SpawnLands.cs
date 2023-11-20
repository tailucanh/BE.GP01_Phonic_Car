using Assets.Scripts.Abtractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class SpawnLands : SpawnObjectAddressables
    {

        private List<GameObject> listsLand = new List<GameObject>();
        public override void SpawnObjectState()
        {
            Transform parentTransform = transform;
            foreach (Transform childTransform in parentTransform)
            {
                BoxCollider2D boxCollider = childTransform.GetComponent<BoxCollider2D>();
                if (boxCollider != null)
                {
                    listsLand.Add(childTransform.gameObject);
                    boxCollider.enabled = false;
                }
            }
        }

        public List<GameObject> GetListLand()
        {
            return listsLand;
        }

        public override void DesSpawnObjectState()
        {
            throw new NotImplementedException();
        }

    }
}
