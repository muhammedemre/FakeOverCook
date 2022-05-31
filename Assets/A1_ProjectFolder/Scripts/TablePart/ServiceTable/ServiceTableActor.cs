using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceTableActor : MonoBehaviour
{
    [SerializeField] private TablePartActor tablePartActor;
    [SerializeField] private SaladCheckOfficer saladCheckOfficer;
    [SerializeField] private RequestedSaladOfficer requestedSaladOfficer;
    public void AssignTheFunctionality()
    {
        tablePartActor.TableFunction += ServiceTableInteractionProcess;
    }

    void ServiceTableInteractionProcess(HumanActor humanActor, bool chopping)
    {
        print("ServiceTableInteractionProcess");
    }
}
