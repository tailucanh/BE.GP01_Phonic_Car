using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class VocabularyManager : Manager
    {
        [SerializeField] protected List<GameObject> listVocabulary;
        [SerializeField] protected List<GameObject> listItemBox;
        [SerializeField] protected List<AudioClip> audioVocabularies;
        [SerializeField] protected List<GameObject> listResult;
        [SerializeField] protected RectTransform uiLever;

        private SpawnVocabulary _spawnVocabulary;
        private ICollideHandler collideHandler;
        private VocabularyState vocabularyState;
        public static VocabularyManager Instance { get; private set; }
        private AudioSource _hostSource;

        private bool spritesAssigned = false;
        private bool endAssigned = false;


        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _spawnVocabulary = GetComponentInChildren<SpawnVocabulary>();
            _hostSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (!spritesAssigned && listVocabulary.Count > 0)
            {
                for (int i = 0; i < listVocabulary.Count; i++)
                {
                    if (listItemBox[i].TryGetComponent<SpriteRenderer>(out var spriteRenderer))
                    {
                        spriteRenderer.sprite = listVocabulary[i].GetComponent<SpriteRenderer>().sprite;
                    }
                }
                spritesAssigned = true;
            }
            StartCoroutine(ChangeVocabularyStatus());

        }


        public override void AdjustObjects()
        {
            _spawnVocabulary.SpawnObjectState();
            listVocabulary = _spawnVocabulary.GetListVocabulary();
            audioVocabularies = _spawnVocabulary.GetListAudioes();
        }

        public IEnumerator ChangeVocabularyStatus()
        {
            if (listVocabulary.Count > 0)
            {
                collideHandler = listVocabulary[0].GetComponent<ICollideHandler>();
                 vocabularyState = listVocabulary[0].GetComponent<MissedVocabularyState>();

                if (collideHandler.StateCollide == EnumStateVocabulary.IsCollision.ToString())
                {

                    GamePlayManager.Instance.ChangeStausAudiences(EnumAniAudience.Happy, 8f);
                    CarPlayManager.Instance.MoveCarsBotStateVocabulary(collideHandler);
                    listResult.Add(listVocabulary[0]);
                    GamePlayManager.Instance.ChangeSpeedBackGroundState(8f);
                    CarPlayManager.Instance.OnSwichClickLand(false);
                    CarPlayManager.Instance.OnChangeCarCollide();
                    listVocabulary.Remove(listVocabulary[0]);
                    listItemBox.Remove(listItemBox[0]);
                    GamePlayManager.Instance.PlaySfxAudience(EnumAudienceVoice.AudienceHappy);
                    yield return wait3_5.Wait();
                    GamePlayManager.Instance.ChangeSpeedBackGroundState(4f);
                    yield return wait2.Wait();
                    CarPlayManager.Instance.OnSwichClickLand(true);
                    yield return wait1.Wait();
                    SpwanItemVocabulary();
                }

                if (collideHandler.StateCollide == EnumStateVocabulary.End.ToString() )
                {
                    vocabularyState.MissedTurn++;
                    GamePlayManager.Instance.ChangeStausAudiences(EnumAniAudience.Sad, 8f);
                    CarPlayManager.Instance.MoveCarsBotStateVocabulary(collideHandler);
                    CarPlayManager.Instance.OnSwichClickLand(false);
                    GamePlayManager.Instance.PlaySfxAudience(EnumAudienceVoice.AudienceDisappointed);
                    if (GamePlayManager.Instance.HostSource.isPlaying)
                    {
                        collideHandler.SetState(EnumStateVocabulary.Start);
                    }
                    yield return CoroutineHelper.WaitInWhile(() => GamePlayManager.Instance.HostSource.isPlaying);
                    CarPlayManager.Instance.OnSwichClickLand(true);
                    if (vocabularyState.MissedTurn == 2)
                    {
                        CarPlayManager.Instance.OnSwichClickLand(false);
                        vocabularyState.PerformState();
                        yield return wait3.Wait();
                        HandClickManager.Instance.HandClickCollectItem(listVocabulary[0].transform);
                        yield return wait1.Wait();
                        CarPlayManager.Instance.OnSwichClickLand(true);
                    }
                    else 
                    {
                        yield return wait1.Wait();
                        SpwanItemVocabulary();
                    }
                 
                }
            }
            if(listVocabulary.Count == 0 && listResult.Count == 3 && !endAssigned)
            {
                endAssigned = true;
                yield return StartCoroutine(EndCollectVocabularies());
                StopAllCoroutines();
    
            }
        }

        public void ContinueSpwanVocabulary()
        {
            if (listVocabulary.Count > 0)
            {
                vocabularyState = listVocabulary[0].GetComponent<MissedVocabularyState>();
                if (vocabularyState.MissedTurn == 2)
                {
                    vocabularyState.MissedTurn = 0;
                    SpwanItemVocabulary();
                }
            }
               
        }

        public IEnumerator EndCollectVocabularies()
        {
            GamePlayManager.Instance.SpawnLineEndGame();
            yield return wait6.Wait();
            StartCoroutine(GamePlayManager.Instance.InitializeLineEndGame());
            yield return StartCoroutine(SpeedTankManager.Instance.StartSpawnSpeedTank());
            endAssigned = false;
        }


        public void SpwanItemVocabulary()
        {
            if(listVocabulary.Count > 0)
            {
                ColliderVocabularyState itemCollider = listVocabulary[0].GetComponent<ColliderVocabularyState>();
                itemCollider.TargetPoint = listItemBox[0].transform;
                itemCollider.PerformState();
        }
        
        }
        public int GetCountList()
        {
            return listVocabulary.Count;
        }

        public IEnumerator PlaySfxAudioVocabulary()
        {
            yield return wait0_5.Wait();
            AudioPlayManager.Instance.PlaySfx(_hostSource, audioVocabularies[0]);

            foreach (var item in listResult)
            {
                MoveableObject moveableObject = item.GetComponent<MoveableVocabularyItem>();
                Vector3 toScale = new(item.transform.localScale.x * 2f, item.transform.localScale.y * 2f, item.transform.localScale.z);
         
                yield return StartCoroutine(moveableObject.ScaleObject(toScale, 0.4f));
            }
            yield return CoroutineHelper.WaitInWhile(() => _hostSource.isPlaying);
            yield return wait0_3.Wait();
            AudioPlayManager.Instance.PlaySfx(_hostSource, audioVocabularies[1]);
            foreach (var item in listResult)
            {
                MoveableObject moveableObject = item.GetComponent<MoveableVocabularyItem>();
                Vector3 toScale = new(item.transform.localScale.x * 1.5f, item.transform.localScale.y * 1.5f, item.transform.localScale.z);

                StartCoroutine(moveableObject.ScaleObject(toScale, 0.4f));
            }
            yield return wait2_5.Wait();
            uiLever.gameObject.SetActive(true);

        }


    }
}
