using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladCheckOfficer : MonoBehaviour
{
    [SerializeField] private ServiceTableActor serviceTableActor;
    public void CheckMatchOfVegetables(HumanActor humanActor, List<VegetableTypeEnums> requestedVegetables, List<VegetableTypeEnums> providedVegetables)
    {
        bool matched = CompareVegDicts(CountVegetables(requestedVegetables), CountVegetables(providedVegetables));
        if (matched)
        {
            serviceTableActor.requestedSaladOfficer.SuccessfulSaladRequest(humanActor);
        }
    }

    Dictionary<VegetableTypeEnums, int> CountVegetables(List<VegetableTypeEnums> vegList)
    {
        Dictionary<VegetableTypeEnums, int> vegDict = new Dictionary<VegetableTypeEnums, int>();
        foreach (VegetableTypeEnums vegetable in vegList)
        {
            if (!vegDict.ContainsKey(vegetable))
            {
                vegDict.Add(vegetable, 1);
            }
            else
            {
                vegDict[vegetable]++ ;
            }
        }

        return vegDict;
    }

    bool CompareVegDicts(Dictionary<VegetableTypeEnums, int> requestedVegDict, Dictionary<VegetableTypeEnums, int> providedVectDict)
    {
        foreach (VegetableTypeEnums vegetable in requestedVegDict.Keys)
        {
            if (providedVectDict.ContainsKey(vegetable))
            {
                if (requestedVegDict[vegetable] != providedVectDict[vegetable])
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}
