using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToInGameSceneTransitionActor : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public IEnumerator TransitionStart(float transitionDuration)
    {
        animator.SetInteger("State", 1);
        yield return new WaitForSeconds(transitionDuration);
        UIManager.instance.menu.SetActive(false);
        UIManager.instance.inGameScreen.SetActive(true);
        animator.SetInteger("State", 2);
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.gameManagerObserverOfficer.Publish(ObserverSubjects.PostLevelInstantiate);
    }
}
