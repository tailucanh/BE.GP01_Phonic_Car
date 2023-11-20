using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    public class PlayingObjectSfx : IPlayingObjectSfx
    {
        public void PlaySfx(AudioSource target)
        {
            target.Play();
        }

        public void PlaySfx(AudioSource source, AudioClip clip)
        {
            source.PlayOneShot(clip);
        }
    }
}
