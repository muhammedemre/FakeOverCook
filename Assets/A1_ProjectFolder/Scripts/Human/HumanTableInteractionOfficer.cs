using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanTableInteractionOfficer : MonoBehaviour
{
    [SerializeField] private HumanActor humanActor;
    public Transform closestTablePart;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "TableDetector")
        {
            Transform tableActor = other.GetComponent<RootFinderOfficer>().root;
            CheckIfThisTableIsCloser(tableActor);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        closestTablePart = null;
        // closestTablePart.GetComponent<TablePartActor>().Highlight(false);
    }

    void CheckIfThisTableIsCloser(Transform currentTable)
    {
        if (closestTablePart != null)
        {
            float distanceToClosest = Vector2.Distance(closestTablePart.position, transform.position);
            float distanceToCurrent = Vector2.Distance(currentTable.position, transform.position);
            if (distanceToCurrent < distanceToClosest)
            {
                closestTablePart = currentTable;
            }
        }
        else
        {
            closestTablePart = currentTable;
        }
        // closestTablePart.GetComponent<TablePartActor>().Highlight(true);
    }

    public void InteractWithTheTable()
    {
        if (closestTablePart == null)
        {
            return;
        }
        closestTablePart.GetComponent<TablePartActor>().ExecuteTablePartProcess(humanActor, false);
    }

    public void Chopping()
    {
        if (closestTablePart == null)
        {
            return;
        }
        if (closestTablePart.GetComponent<TablePartActor>().currentTablePartType == TablePartActor.TablePartEnum.ChoppingBoard)
        {
            closestTablePart.GetComponent<TablePartActor>().ExecuteTablePartProcess(humanActor, true);
        }
    }
}
