using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelOfficerSpriteBased : MonoBehaviour
{
    [SerializeField] private string targetModel;
    public List<Sprite> modelSprites = new List<Sprite>();
    [SerializeField] SpriteRenderer targetSpriteRenderer;
    public void SelectTheModel(int modelSpriteIndex) 
    {
        targetSpriteRenderer.sprite = modelSprites[modelSpriteIndex];
    }
}
