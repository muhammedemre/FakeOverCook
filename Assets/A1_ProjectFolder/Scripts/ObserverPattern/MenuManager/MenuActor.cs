using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class MenuActor : SerializedMonoBehaviour
{
    [SerializeField] private MenuButtonOfficer MenuButtonOfficer;
   
    
    public enum MenuControlEnums
    {
        Up, Down, Left, Right, Backward, Forward
    }

    public void MenuPreparetion()
    {
        MenuButtonOfficer.MenuPrepare();
    }

    public void MenuInputInjection(PlayerEnums player, MenuControlEnums inputType)
    {
        switch (inputType)
        {
            case MenuControlEnums.Up:
                MenuButtonOfficer.MoveOnMenuElements(player, -1);
                break;
            case MenuControlEnums.Down:
                MenuButtonOfficer.MoveOnMenuElements(player, 1);
                break;

            case MenuControlEnums.Backward:
                MenuButtonOfficer.CloseMenuElement(player);
                break;
            case MenuControlEnums.Forward:
                MenuButtonOfficer.MenuButtonActivate(player);
                break;
        }
    }
}
