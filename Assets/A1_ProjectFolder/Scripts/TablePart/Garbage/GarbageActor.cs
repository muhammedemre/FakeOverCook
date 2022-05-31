using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageActor : MonoBehaviour
{
    [SerializeField] private TablePartActor tablePartActor;
    public void AssignTheFunctionality()
    {
        tablePartActor.TableFunction += GarbageTableInteractionProcess;
    }

    void GarbageTableInteractionProcess(HumanActor humanActor)
    {
        print("GarbageTableInteractionProcess");
    }
}
