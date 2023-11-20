using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Utilities;
using System;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    public class BackgroudSelectCarManager : Manager
    {

        private SpawnObjectAddressables _sqawmBackgroundSelect;

        private void Awake()
        {
            _sqawmBackgroundSelect = GetComponentInChildren<SpawnBackgroundSelectCar>();
            AdjustObjects();
        }
        public override void AdjustObjects()
        {
            _sqawmBackgroundSelect.SpawnObjectState();
        }

      
    }
}
