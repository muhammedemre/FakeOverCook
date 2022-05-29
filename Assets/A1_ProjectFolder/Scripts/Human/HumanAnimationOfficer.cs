using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimationOfficer : MonoBehaviour
{
    public Transform humanModelAnchor;
    [SerializeField] private Animator animator;

    public void PlayHumanIdle()
    {
        animator.SetInteger("State", 0);
    }

    public void PlayHoldItem()
    {
        animator.SetInteger("State", 1);
    }

    public void PlayHandWorking()
    {
        animator.SetInteger("State", 2);
    }
    
    public void PlayLeaveAnItem()
    {
        animator.SetInteger("State", 3);
    }

    
}
