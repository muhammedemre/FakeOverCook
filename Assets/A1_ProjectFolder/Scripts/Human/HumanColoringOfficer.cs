using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class HumanColoringOfficer : SerializedMonoBehaviour
{
    public enum HumanBodyParts
    {
        Body, Head, Hair, Hat, Arms, Hands 
    }

    [SerializeField] private Dictionary<HumanBodyParts, Color> humanColorDict = new Dictionary<HumanBodyParts, Color>();
    public Dictionary<HumanBodyParts, List<GameObject>> humanBodyParts = new Dictionary<HumanBodyParts, List<GameObject>>();

    void PaintTheHuman()
    {
        foreach (HumanBodyParts bodyPart in humanBodyParts.Keys)
        {
            if (humanColorDict.ContainsKey(bodyPart))
            {
                foreach (GameObject bodyPartObject in humanBodyParts[bodyPart])
                {
                    bodyPartObject.GetComponent<SpriteRenderer>().color = humanColorDict[bodyPart];
                }
            }
        }
    }

    #region Button

    // [Title("Select the cam state then Invoke")]
    [Button("Paint The Human", ButtonSizes.Large)]
    void ButtonPaintTheHuman()
    {
        PaintTheHuman();
    }
    #endregion
}
