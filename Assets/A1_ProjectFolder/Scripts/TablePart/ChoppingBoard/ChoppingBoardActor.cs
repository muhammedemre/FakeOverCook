using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoardActor : MonoBehaviour
{
    [SerializeField] private TablePartActor tablePartActor;
    public void AssignTheFunctionality()
    {
        tablePartActor.TableFunction += ChoppingBoardTableInteractionProcess;
    }

    void ChoppingBoardTableInteractionProcess(HumanActor humanActor)
    {
        print("ChoppingBoardTableInteractionProcess");
    }
}
