using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SpawnParallaxBackground : SpawnObjectAddressables
{
    [SerializeField] protected GameObject back1;
    [SerializeField] protected GameObject back2;
    private float speedNormal = 3.5f;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void SpawnObjectState()
    {

        MoveBackground(back1, speedNormal);
        MoveBackground(back2, speedNormal);
    }

    protected void MoveBackground(GameObject background, float speed)
    {
        Vector3 currentPosition = background.transform.position;
        Vector3 newPosition = new Vector3(currentPosition.x - speed * Time.deltaTime, currentPosition.y, currentPosition.z);

        background.transform.position = newPosition;

        SpriteRenderer spriteRenderer = background.GetComponent<SpriteRenderer>();
        float backgroundWidth = spriteRenderer.bounds.size.x;

        if (currentPosition.x + backgroundWidth / 2f < Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect)
        {
            float offset = backgroundWidth * 1.8f; 
            background.transform.position = new Vector3(currentPosition.x + offset, currentPosition.y, currentPosition.z);
        }
    }

    public void StartAudioBackground()
    {
        AudioPlayManager.Instance.PlaySfx(audioSource);
    }
    public void StopAudioBackground()
    {
        AudioPlayManager.Instance.StopSfx(audioSource);
    }


    public override void DesSpawnObjectState()
    {
        throw new System.NotImplementedException();
    }
}
