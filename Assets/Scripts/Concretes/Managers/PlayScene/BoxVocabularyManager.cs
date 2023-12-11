using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Controllers;
using System.Collections;

namespace Assets.Scripts.Concretes.Managers
{
    public class BoxVocabularyManager : Manager
    {
        public static BoxVocabularyManager Instance { get; private set; }
        private BoxVocabularyState _pushUpBoxVocabulary;
        private BoxVocabularyState _pushCenterBoxVocabulary;

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(this);
            Instance = this;
            _pushUpBoxVocabulary = GetComponentInChildren<PushUpBoxVocabulary>();
            _pushCenterBoxVocabulary = GetComponentInChildren<PushCenterBoxVocabulary>();
        }

        public override void AdjustObjects()
        {
            _pushUpBoxVocabulary.PerformState();
        }

        public void PushCenterEndGame()
        {
            _pushCenterBoxVocabulary.PerformState();
        }



    }
}
