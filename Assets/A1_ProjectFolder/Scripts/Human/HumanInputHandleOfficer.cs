using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanInputHandleOfficer : MonoBehaviour
{
    [SerializeField] private HumanActor HumanActor;
    
    public void HumanInputInjection(bool moveUp, bool moveDown, bool moveLeft, bool moveRight)
    {
        HumanActor.HumanMoveOfficer.Move(moveUp, moveDown, moveLeft, moveRight);
    }

    public void Interaction()
    {
        HumanActor.HumanTableInteractionOfficer.InteractWithTheTable();
    }
}
