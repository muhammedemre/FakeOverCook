using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceTableActor : MonoBehaviour
{
    [SerializeField] private TablePartActor tablePartActor;
    public SaladCheckOfficer saladCheckOfficer;
    public RequestedSaladOfficer requestedSaladOfficer;
    public void AssignTheFunctionality()
    {
        tablePartActor.TableFunction += ServiceTableInteractionProcess;
    }

    void ServiceTableInteractionProcess(HumanActor humanActor, bool chopping)
    {
        // print("ServiceTableInteractionProcess");
        AcceptTheSalad(humanActor);
    }

    void AcceptTheSalad(HumanActor humanActor)
    {
        if (humanActor.HumanResourceInteractionOfficer.carryingPlate == null)
        {
            return;
        }

        GameObject saladPlate = humanActor.HumanResourceInteractionOfficer.carryingPlate.gameObject;
        List<VegetableTypeEnums> providedCombination = saladPlate.GetComponent<SaladActor>().includingVegetables;
        List<VegetableTypeEnums> requestedCombination = requestedSaladOfficer.requestedVegetables;
        
        saladCheckOfficer.CheckMatchOfVegetables(humanActor, requestedCombination, providedCombination);
        Destroy(saladPlate, 0.2f);
        humanActor.HumanAnimationOfficer.PlayLeaveAnItem();
    }
}
