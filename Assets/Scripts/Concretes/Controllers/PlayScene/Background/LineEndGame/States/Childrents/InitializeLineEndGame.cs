
using Assets.Scripts.Utilities;
using System.Collections;

namespace Assets.Scripts.Concretes.Controllers
{
    public class InitializeLineEndGame : LineEndGameState
    {
        private void Awake()
        {
            moveDuration = 3f;
            targetPosition =new(GameHelper.GetMiddleX(), transform.position.y, transform.position.z);
        }
        public override IEnumerator Sequence()
        {
            moveableObject = GetComponent<MoveableLineEndGame>();
            StartCoroutine(moveableObject.MoveObject(targetPosition, moveDuration));
            yield return null;
        }
    }
}
