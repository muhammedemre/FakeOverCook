using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawnerActor : MonoBehaviour
{
    [SerializeField] private TablePartActor tablePartActor;
    public void AssignTheFunctionality()
    {
        tablePartActor.TableFunction += PlateSpawnerTableInteractionProcess;
    }

    void PlateSpawnerTableInteractionProcess(HumanActor humanActor, bool chopping)
    {
        print("PlateSpawnerTableInteractionProcess");
    }
}
