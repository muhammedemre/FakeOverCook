using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTableActor : MonoBehaviour
{
    [SerializeField] private TablePartActor tablePartActor;
    public void AssignTheFunctionality()
    {
        tablePartActor.TableFunction += NormalTableInteractionProcess;
    }

    void NormalTableInteractionProcess(HumanActor humanActor, bool chopping)
    {
        print("NormalTableInteractionProcess");
    }
}
