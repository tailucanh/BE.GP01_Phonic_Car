using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Concretes.Controllers
{
    public abstract class TextTitleState : State
    {
        protected AudioSource _audioSource;

        public AudioSource GetTextTitleAudio()
        {
            return _audioSource;
        }

        private void Start()
        {
            PerformState();
        }
       

        public override void PerformState()
        {
            StartCoroutine(Sequence());
        }

        public abstract IEnumerator Sequence();


    }
}
