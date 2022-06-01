using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VegetableActor : MonoBehaviour
{
    public ModelOfficerSpriteBased ModelOfficerSpriteBased;
    [SerializeField] private Color processedColor;
    [SerializeField] private float colorChangeDuration;
    public VegetableTypeEnums currentVegetableType;
    public bool toService = false;

    public void SetTheVegetableType(VegetableTypeEnums selectedVegetableType)
    {
        currentVegetableType = selectedVegetableType;
        ModelOfficerSpriteBased.SelectTheModel((int)currentVegetableType);
    }

    public void GetProcessed()
    {
        ModelOfficerSpriteBased.targetSpriteRenderer.DOColor(processedColor, colorChangeDuration);
    }
}
