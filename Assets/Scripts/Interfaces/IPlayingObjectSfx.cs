using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface  IPlayingObjectSfx
    {
        void PlaySfx(AudioSource target);
        void PlaySfx(AudioSource source, AudioClip clip);
    }
}
