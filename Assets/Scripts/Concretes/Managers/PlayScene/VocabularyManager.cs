
using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    public class VocabularyManager : Manager
    {
        [SerializeField] protected List<GameObject> listVocabulary;
        [SerializeField] protected List<GameObject> listItemBox;

        [SerializeField] protected List<AudioClip> audioVocabularies;

        private SpawnVocabulary _spawnVocabulary;

        public static VocabularyManager Instance { get; private set; }
        private bool spritesAssigned = false;

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _spawnVocabulary = GetComponentInChildren<SpawnVocabulary>();
        }

        private void Update()
        {
            if (!spritesAssigned && listVocabulary.Count > 0)
            {
                for (int i = 0; i < listVocabulary.Count; i++)
                {
                    SpriteRenderer spriteRenderer = listItemBox[i].GetComponent<SpriteRenderer>();

                    if (spriteRenderer != null)
                    {
                        spriteRenderer.sprite = listVocabulary[i].GetComponent<SpriteRenderer>().sprite;
                    }
                    else
                    {
                        Debug.LogError("SpriteRenderer not found on listItemBox[" + i + "]");
                    }
                }
                spritesAssigned = true;
            }
        }

        public override void AdjustObjects()
        {
            _spawnVocabulary.SpawnObjectState();
            listVocabulary = _spawnVocabulary.GetListVocabulary();
            audioVocabularies = _spawnVocabulary.GetListAudioes();

        }
    }
}
