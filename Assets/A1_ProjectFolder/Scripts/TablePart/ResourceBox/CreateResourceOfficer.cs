using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateResourceOfficer : MonoBehaviour
{
    public void CreateTheResource(GameObject vegetablePrefab, VegetableTypeEnums vegetableType, HumanActor player)
    {
        if (player.HumanResourceInteractionOfficer.resourceList.Count < 2)
        {
            Transform tempResource = Instantiate(vegetablePrefab).transform;
            tempResource.GetComponent<VegetableActor>().SetTheVegetableType(vegetableType);
            StartCoroutine(player.HumanResourceInteractionOfficer.GrabAResource(tempResource));
        }
    }
}
