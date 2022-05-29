using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VegetableActor : MonoBehaviour
{
    public ModelOfficerSpriteBased ModelOfficerSpriteBased;
    [SerializeField] private Color processedColor;
    [SerializeField] private float colorChangeDuration;
    public bool isProcessed = false;

    public void GetProcessed()
    {
        ModelOfficerSpriteBased.targetSpriteRenderer.DOColor(processedColor, colorChangeDuration);
    }
}
