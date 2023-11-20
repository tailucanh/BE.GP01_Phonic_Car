using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Setting;
using Spine.Unity;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public class PlayerCarInput : MonoBehaviour, IPlayerInput
    {
        [SerializeField] protected bool _useBot;

        public bool UseBot
        {
            get => _useBot;
            set => _useBot = value;
        }



      
    }
}
