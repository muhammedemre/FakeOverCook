using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TablePartActor : MonoBehaviour
{
    public enum TablePartEnum
    {
        NormalTable, PlateSpawner, Garbage, ServiceTable, ChoppingBoard, ResourceBox
    }

    [SerializeField] private ModelOfficerTransformBased categoryModelsOfficer;

    void ChooseTypeOfTablePart(TablePartEnum selectedTablePartType)
    {
        categoryModelsOfficer.SelectTheModel((int)selectedTablePartType);
    }

    #region Button

    // [Title("Select the cam state then Invoke")]
    [Button("Set type of the TablePart", ButtonSizes.Large)]
    void ButtonChooseTypeOfTablePart(TablePartEnum selectedTablePartType)
    {
        ChooseTypeOfTablePart(selectedTablePartType);
    }
    #endregion
}
