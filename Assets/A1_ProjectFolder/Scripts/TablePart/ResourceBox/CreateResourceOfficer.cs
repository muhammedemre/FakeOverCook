using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateResourceOfficer : MonoBehaviour
{
    private GameObject lastCreatedResource;
    public void CreateTheResource(GameObject vegetablePrefab, VegetableTypeEnums vegetableType, HumanActor player)
    {
        Transform tempResource = Instantiate(vegetablePrefab).transform;
        tempResource.GetComponent<VegetableActor>().SetTheVegetableType(vegetableType);
        StartCoroutine(player.HumanResourceInteractionOfficer.GrabAResource(tempResource));
    }
}
