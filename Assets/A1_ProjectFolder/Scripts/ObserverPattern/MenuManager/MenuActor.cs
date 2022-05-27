using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class MenuActor : SerializedMonoBehaviour
{
    private bool displayMenuForTheFirstTime = true;

    public Dictionary<PlayerEnums, MenuElementEnums> playersCurrentMenuElement =
        new Dictionary<PlayerEnums, MenuElementEnums>();

    [SerializeField] private Dictionary<PlayerEnums, int> playerMenuButtonIndex = new Dictionary<PlayerEnums, int>();

    public enum MenuElementEnums
    {
        MenuButtons, HighScoreList, ChangeNameScreen, PlayerName, InfoBox
    }
    public enum MenuControlEnums
    {
        Up, Down, Left, Right, Backward, Forward
    }

    public Dictionary<PlayerEnums, Dictionary<MenuElementEnums, GameObject>> menu =
        new Dictionary<PlayerEnums, Dictionary<MenuElementEnums, GameObject>>();

    public void MenuPrepare()
    {
        if (displayMenuForTheFirstTime)
        {
            displayMenuForTheFirstTime = false;
            playersCurrentMenuElement[PlayerEnums.Player1] = MenuElementEnums.InfoBox;
            playersCurrentMenuElement[PlayerEnums.Player2] = MenuElementEnums.InfoBox;
            menu[PlayerEnums.Player1][MenuElementEnums.InfoBox].SetActive(true);
            menu[PlayerEnums.Player2][MenuElementEnums.InfoBox].SetActive(true);
        }
        else
        {
            playersCurrentMenuElement[PlayerEnums.Player1] = MenuElementEnums.MenuButtons;
            playersCurrentMenuElement[PlayerEnums.Player2] = MenuElementEnums.MenuButtons;
            menu[PlayerEnums.Player1][MenuElementEnums.MenuButtons].SetActive(true);
            menu[PlayerEnums.Player2][MenuElementEnums.MenuButtons].SetActive(true);
        }
    }

    public void MenuInputInjection(PlayerEnums player, MenuControlEnums inputType)
    {
        switch (inputType)
        {
            case MenuControlEnums.Up:
                MoveOnMenuElements(player, -1);
                break;
            case MenuControlEnums.Down:
                MoveOnMenuElements(player, 1);
                break;

            case MenuControlEnums.Backward:
                CloseMenuElement(player);
                break;
            case MenuControlEnums.Forward:
                
                break;
        }
    }

    void MoveOnMenuElements(PlayerEnums player, int indexAdd)
    {
        if (!(playersCurrentMenuElement[player] == MenuElementEnums.MenuButtons))
        {
            return;
        }
        Transform menuButtons = menu[player][MenuElementEnums.MenuButtons].transform;
        playerMenuButtonIndex[player] += indexAdd;
        playerMenuButtonIndex[player] = (playerMenuButtonIndex[player] < 0) ? 0 : playerMenuButtonIndex[player];
        playerMenuButtonIndex[player] = (playerMenuButtonIndex[player] >= menuButtons.childCount) ? menuButtons.childCount-1 : playerMenuButtonIndex[player];
        
        for (int i = 0; i < menuButtons.childCount; i++)
        {
            if (i == playerMenuButtonIndex[player])
            {
                HighLightButton(menuButtons.GetChild(i) , false);
            }
            else
            {
                HighLightButton(menuButtons.GetChild(i) , true);
            }
        }
    }

    void HighLightButton(Transform button, bool highlightState)
    {
        button.GetChild(0).gameObject.SetActive(highlightState);
    }

    void CloseMenuElement(PlayerEnums player)
    {
        if (playersCurrentMenuElement[player] == MenuElementEnums.InfoBox ||
            playersCurrentMenuElement[player] == MenuElementEnums.HighScoreList ||
            playersCurrentMenuElement[player] == MenuElementEnums.ChangeNameScreen)
        {
            menu[player][playersCurrentMenuElement[player]].SetActive(false);
            playersCurrentMenuElement[player] = MenuElementEnums.MenuButtons;
            menu[player][MenuElementEnums.MenuButtons].SetActive(true);
            MoveOnMenuElements(player, 0);
        }
    }
}
