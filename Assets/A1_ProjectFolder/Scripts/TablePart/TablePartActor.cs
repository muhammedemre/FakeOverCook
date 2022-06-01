using System;
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

    public delegate void TableFunctionDel(HumanActor humanActor, bool chopping);

    public event TableFunctionDel TableFunction;
    
    [SerializeField] private ModelOfficerTransformBased categoryModelsOfficer;
    public TablePartEnum currentTablePartType;
    [SerializeField] Transform selectedCategoryTransform;
    [SerializeField] private GameObject highlight;

    private void Start()
    {
        AssignTheCategoryProcess(selectedCategoryTransform, currentTablePartType);
    }

    void ChooseTypeOfTablePart(TablePartEnum selectedTablePartType)
    {
        currentTablePartType = selectedTablePartType;
        selectedCategoryTransform = categoryModelsOfficer.SelectTheModel((int)selectedTablePartType);
        
    }

    void AssignTheCategoryProcess(Transform categoryTransform, TablePartEnum selectedType)
    {
        switch (selectedType)
        {
            case TablePartEnum.NormalTable:
                categoryTransform.GetComponent<NormalTableActor>().AssignTheFunctionality();
                break;
            case TablePartEnum.PlateSpawner:
                categoryTransform.GetComponent<PlateSpawnerActor>().AssignTheFunctionality();
                break;
            case TablePartEnum.Garbage:
                categoryTransform.GetComponent<GarbageActor>().AssignTheFunctionality();
                break;
            case TablePartEnum.ServiceTable:
                categoryTransform.GetComponent<ServiceTableActor>().AssignTheFunctionality();
                break;
            case TablePartEnum.ChoppingBoard:
                categoryTransform.GetComponent<ChoppingBoardActor>().AssignTheFunctionality();
                break;
            case TablePartEnum.ResourceBox:
                categoryTransform.GetComponent<ResourceBoxActor>().AssignTheFunctionality();
                break;
        }
    }

    public void ExecuteTablePartProcess(HumanActor humanActor, bool chopping)
    {
        TableFunction(humanActor, chopping);
    }

    public void Highlight(bool state)
    {
        highlight.SetActive(state);
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
