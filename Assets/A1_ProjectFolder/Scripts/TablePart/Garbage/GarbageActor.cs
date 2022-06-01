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

    void GarbageTableInteractionProcess(HumanActor humanActor, bool chopping)
    {
        print("GarbageTableInteractionProcess");
        DestroyTheResource(humanActor);
    }

    void DestroyTheResource(HumanActor humanActor)
    {
        PlayerManager.instance.playerPointsOfficer.PlayerPointAddition(-2, humanActor.player);
        Transform resourceToDestroy = humanActor.HumanResourceInteractionOfficer.LeaveAnItem();
        if (resourceToDestroy != null)
        {
            Destroy(resourceToDestroy.gameObject);
        }
    }
}
