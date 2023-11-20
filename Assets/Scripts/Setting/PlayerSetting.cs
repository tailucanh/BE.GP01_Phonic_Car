using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Setting
{
    [CreateAssetMenu(fileName = "New Player Settings", menuName = "Player Settings")]
    public class PlayerSettings : ScriptableObject
    {
        public bool UseBot => _useBot;

        [SerializeField]
        private bool _useBot;
    }
}
