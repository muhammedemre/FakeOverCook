using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelOfficerTransformBased : MonoBehaviour
{
    [SerializeField] private string targetModel;
    [SerializeField] private List<Transform> models = new List<Transform>();

    public void SelectTheModel(int modelIndex) 
    {
        CloseAllTheModels();
        models[modelIndex].gameObject.SetActive(true);
    }
    void CloseAllTheModels() 
    {
        foreach ( Transform model in models)
        {
            model.gameObject.SetActive(false);
        }
    }
}
