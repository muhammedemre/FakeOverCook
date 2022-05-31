using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ResourceBoxActor : MonoBehaviour
{
    public ModelOfficerSpriteBased ModelOfficerSpriteBased;
    public CreateResourceOfficer CreateResourceOfficer;
    
    [SerializeField] private GameObject vegetablePrefab;
    public VegetableTypeEnums selectedResourceType;
    
    [SerializeField] private TablePartActor tablePartActor;
    public void AssignTheFunctionality()
    {
        tablePartActor.TableFunction += ResourceBoxTableInteractionProcess;
    }

    void ResourceBoxTableInteractionProcess(HumanActor humanActor, bool chopping)
    {
        print("ResourceBoxTableInteractionProcess");
        CreateResourceOfficer.CreateTheResource(vegetablePrefab, selectedResourceType, humanActor);
    }
    
    #region SettingTypeProcess
    void SetTheResourceType(VegetableTypeEnums _selectedResourceType)
    {
        AssignVegetableSpritesToModelOfficer();
        selectedResourceType = _selectedResourceType;
        ModelOfficerSpriteBased.SelectTheModel((int)selectedResourceType);
    }

    void AssignVegetableSpritesToModelOfficer()
    {
        ModelOfficerSpriteBased.modelSprites = new List<Sprite>(vegetablePrefab.GetComponent<VegetableActor>().ModelOfficerSpriteBased.modelSprites);
    }
    #endregion
    #region Button

    // [Title("Select the cam state then Invoke")]
    [Button("Set type of the Resource", ButtonSizes.Large)]
    void ButtonChooseTypeOfTheResource(VegetableTypeEnums _selectedResourceType)
    {
        SetTheResourceType(_selectedResourceType);
    }
    #endregion
}
