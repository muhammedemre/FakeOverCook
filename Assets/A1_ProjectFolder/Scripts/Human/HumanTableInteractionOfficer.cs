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
    }

    public void InteractWithTheTable()
    {
        closestTablePart.GetComponent<TablePartActor>().ExecuteTablePartProcess(humanActor);
    }
}
