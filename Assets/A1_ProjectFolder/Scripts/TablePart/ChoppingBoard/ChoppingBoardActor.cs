using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChoppingBoardActor : MonoBehaviour
{
    [SerializeField] private TablePartActor tablePartActor;
    [SerializeField] private float choppingDuration;
    [SerializeField] private GameObject saladPrefab, readySalad;
    public void AssignTheFunctionality()
    {
        tablePartActor.TableFunction += ChoppingBoardTableInteractionProcess;
    }

    void ChoppingBoardTableInteractionProcess(HumanActor humanActor, bool chopping)
    {
        // print("ChoppingBoardTableInteractionProcess");
        ChoppingTableDecision(humanActor);
    }

    void ChoppingTableDecision(HumanActor humanActor)
    {
        if (readySalad == null)
        {
            if (humanActor.HumanResourceInteractionOfficer.resourceList.Count > 0)
            {
                StartCoroutine(StartChopping(humanActor));
            }
        }
        else
        {
            StartCoroutine(humanActor.HumanResourceInteractionOfficer.GrabAPlate(readySalad.transform));
            readySalad = null;
        }
    }

    IEnumerator StartChopping(HumanActor humanActor)
    {
        humanActor.HumanMoveOfficer.CalculateTheFacingAngle(transform.position);
        humanActor.HumanAnimationOfficer.PlayHandWorking();
        InputManager.instance.noInputTime = true;
        yield return new WaitForSeconds(choppingDuration);
        Transform tempSalad = Instantiate(saladPrefab, transform.position, Quaternion.identity, transform).transform;
        ImportingVegetables(tempSalad.GetComponent<SaladActor>(), humanActor);
        readySalad = tempSalad.gameObject;
        InputManager.instance.noInputTime = false;
        humanActor.HumanAnimationOfficer.PlayHumanIdle();
    }

    void ImportingVegetables(SaladActor saladActor, HumanActor humanActor)
    {
        int listCount = humanActor.HumanResourceInteractionOfficer.resourceList.Count;
        for (int i = 0; i < listCount; i++)
        {
            saladActor.includingVegetables.Add(humanActor.HumanResourceInteractionOfficer.resourceList[0].GetComponent<VegetableActor>().currentVegetableType);
            humanActor.HumanResourceInteractionOfficer.resourceList[0].SetParent(i==0? saladActor.vegPos1 : saladActor.vegPos2);
            humanActor.HumanResourceInteractionOfficer.resourceList[0].localPosition = Vector3.zero;
            humanActor.HumanResourceInteractionOfficer.resourceList.RemoveAt(0);
        }
        
    }
}
