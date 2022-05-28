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
        animator.SetInteger("State", 2);
    }
}
