using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanInputHandleOfficer : MonoBehaviour
{
    [SerializeField] private HumanActor HumanActor;
    
    public void MenuInputInjection(bool moveUp, bool moveDown, bool moveLeft, bool moveRight, bool Interaction)
    {
        HumanActor.HumanMoveOfficer.Move(moveUp, moveDown, moveLeft, moveRight);
    }
}
