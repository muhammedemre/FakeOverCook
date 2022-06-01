using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RequestedSaladOfficer : MonoBehaviour
{

    [SerializeField] private float frequencyToChangeRequest, randomRate, doubleVegetableRate;
    public List<VegetableTypeEnums> requestedVegetables = new List<VegetableTypeEnums>();
    [SerializeField] private List<VegetableTypeEnums> vegetableVarietyList = new List<VegetableTypeEnums>();
    [SerializeField] private Transform saladDeadlineBar;
    
    private float nextCombinationAssign, currentTotalDuration;

    [SerializeField] private GameObject vegetable1, vegetable2;

    private void Start()
    {
        currentTotalDuration = FrequencyAddition();
        nextCombinationAssign = Time.time + currentTotalDuration;
        ChangeSaladRequest("Start");
    }

    void Update()
    {
        CheckSaladCombination();
    }

    void CheckSaladCombination()
    {
        if (Time.time > nextCombinationAssign)
        {
            currentTotalDuration = FrequencyAddition();
            nextCombinationAssign = Time.time + currentTotalDuration;
            FailedSaladRequest();
        }
        CalculatesaladDeadlineBar(currentTotalDuration);
    }

    float FrequencyAddition()
    {
        float randomFrequencyAddition = UnityEngine.Random.Range(-frequencyToChangeRequest * randomRate, frequencyToChangeRequest * randomRate);
        float calculatedFrequency = frequencyToChangeRequest + randomFrequencyAddition;
        return calculatedFrequency;
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

    void ChangeSaladRequest(string nereden)
    {
        print("nereden : "+ nereden);
        requestedVegetables = new List<VegetableTypeEnums>();
        if (IsDouble(doubleVegetableRate))
        {
            ActivateVegetable(vegetable1.GetComponent<VegetableActor>());
            ActivateVegetable(vegetable2.GetComponent<VegetableActor>());
        }
        else
        {
            ActivateVegetable(vegetable1.GetComponent<VegetableActor>());
            DeactivateVegetable(vegetable2.GetComponent<VegetableActor>());
        }
    }

    void ActivateVegetable(VegetableActor vegetable)
    {
        vegetable.ModelOfficerSpriteBased.targetSpriteRenderer.gameObject.SetActive(true);
        int randomForVegetableType = UnityEngine.Random.Range(0, vegetableVarietyList.Count);
        VegetableTypeEnums randomlySelectedVegetableType = vegetableVarietyList[randomForVegetableType];
        vegetable.SetTheVegetableType(randomlySelectedVegetableType);
        requestedVegetables.Add(randomlySelectedVegetableType);
    }

    void DeactivateVegetable(VegetableActor vegetable)
    {
        vegetable.ModelOfficerSpriteBased.targetSpriteRenderer.gameObject.SetActive(false);
    }

    bool IsDouble(float doubleRate)
    {
        int rate = UnityEngine.Random.Range(0, 100);
        return ((rate > doubleRate) ? false : true);
    }
    

    void FailedSaladRequest()
    {
        // print("FAILED");
        currentTotalDuration = FrequencyAddition();
        nextCombinationAssign = Time.time + currentTotalDuration;
        ChangeSaladRequest("FailedSaladRequest");
    }

    public void SuccessfulSaladRequest(HumanActor humanActor)
    {
        print("SUCCEESSS");
        PlayerManager.instance.playerPointsOfficer.PlayerPointAddition(10, humanActor.player);
        currentTotalDuration = FrequencyAddition();
        nextCombinationAssign = Time.time + currentTotalDuration;
        ChangeSaladRequest("SuccessfulSaladRequest");
    }
    
}
