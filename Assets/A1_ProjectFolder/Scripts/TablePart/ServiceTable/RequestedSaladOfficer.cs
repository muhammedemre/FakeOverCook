using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RequestedSaladOfficer : MonoBehaviour
{

    [SerializeField] private float frequencyToChangeRequest, randomRate, doubleVegetableRate;
    [SerializeField] private List<VegetableActor> requestedSaladCombination = new List<VegetableActor>();
    [SerializeField] private List<VegetableTypeEnums> vegetableVarietyList = new List<VegetableTypeEnums>();
    [SerializeField] private Transform saladDeadlineBar;
    
    private float nextCombinationAssign, currentTotalDuration;

    private void Start()
    {
        nextCombinationAssign = Time.time + frequencyToChangeRequest;
    }

    void Update()
    {
        CheckSaladCombination();
    }

    void CheckSaladCombination()
    {
        if (Time.time > nextCombinationAssign)
        {
            float randomFrequencyAddition = UnityEngine.Random.Range(-frequencyToChangeRequest * randomRate, frequencyToChangeRequest * randomRate);
            float calculatedFrequency = frequencyToChangeRequest + randomFrequencyAddition;
            currentTotalDuration = calculatedFrequency;
            nextCombinationAssign = Time.time + calculatedFrequency;
            ChangeSaladRequest();
        }
        CalculatesaladDeadlineBar(currentTotalDuration);
    }

    void CalculatesaladDeadlineBar(float totalDuration)
    {
        float durationRatio = (nextCombinationAssign-Time.time)/ totalDuration;
        if (durationRatio < 0.25f && (saladDeadlineBar.GetChild(0).GetComponent<SpriteRenderer>().color != Color.red))
        {
            saladDeadlineBar.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (durationRatio >= 0.25f && (saladDeadlineBar.GetChild(0).GetComponent<SpriteRenderer>().color != Color.green))
        {
            saladDeadlineBar.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
        }

        // print("durationRatio : "+ durationRatio);
        durationRatio = durationRatio < 0 ? 0 : durationRatio;
        durationRatio = durationRatio > 1 ? 1 : durationRatio;
        saladDeadlineBar.localScale = new Vector3(durationRatio, saladDeadlineBar.localScale.y, saladDeadlineBar.localScale.z);
    }

    void ChangeSaladRequest()
    {
        int doubleOrSingleRate = UnityEngine.Random.Range(0, 100);
        int vegetableAmount = 0;
        if (doubleOrSingleRate > doubleVegetableRate)
        {
            vegetableAmount = 2;
            requestedSaladCombination[1].ModelOfficerSpriteBased.targetSpriteRenderer.enabled = true;
        }
        else
        {
            vegetableAmount = 1;
            requestedSaladCombination[1].ModelOfficerSpriteBased.targetSpriteRenderer.enabled = false;
        }

        for (int i = 0; i < vegetableAmount; i++)
        {
            int randomForVegetableType = UnityEngine.Random.Range(0, vegetableVarietyList.Count);
            VegetableTypeEnums randomlySelectedVegetableType = vegetableVarietyList[randomForVegetableType];
            requestedSaladCombination[i].SetTheVegetableType(randomlySelectedVegetableType);
        }
    }
}
