using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class MenuButtonOfficer : SerializedMonoBehaviour
{
    [SerializeField] private MenuActor MenuActor;
    public enum MenuElementEnums
    {
        MenuButtons, HighScoreList, ChangeNameScreen, PlayerName, InfoBox, CheckSign
    }
    public enum MenuButtonEnums
    {
        ChangeName, LeaderBoard, ReadyToPlay
    }
    
    public Dictionary<PlayerEnums, Dictionary<MenuElementEnums, GameObject>> menu =
        new Dictionary<PlayerEnums, Dictionary<MenuElementEnums, GameObject>>();
    
    public Dictionary<PlayerEnums, MenuElementEnums> playersCurrentMenuElement =
        new Dictionary<PlayerEnums, MenuElementEnums>();
    
    [SerializeField] private Dictionary<PlayerEnums, int> playerMenuButtonIndex = new Dictionary<PlayerEnums, int>();
    public Dictionary<PlayerEnums, bool> playerReadyDict = new Dictionary<PlayerEnums, bool>();
    
    private bool displayMenuForTheFirstTime = true;
    
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
    
    public void MoveOnMenuElements(PlayerEnums player, int indexAdd)
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
    
    public void CloseMenuElement(PlayerEnums player)
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
    
    public void MenuButtonActivate(PlayerEnums player)
    {
        int menuButtonEnumIndex = playerMenuButtonIndex[player];
        MenuButtonEnums selectedMenuButton = (MenuButtonEnums)menuButtonEnumIndex;

        switch (selectedMenuButton)
        {
            case MenuButtonEnums.ChangeName:
                break;
            case MenuButtonEnums.LeaderBoard:
                break;
            case MenuButtonEnums.ReadyToPlay:
                PlayerReady(player);
                break;
        }
    }
    
    public void PlayerReady(PlayerEnums player)
    {
        playerReadyDict[player] = !playerReadyDict[player];
        menu[player][MenuElementEnums.CheckSign].gameObject.SetActive(playerReadyDict[player]);

        if (BothPlayerReadyCheck())
        {
            GameManager.instance.gameManagerObserverOfficer.Publish(ObserverSubjects.PreLevelInstantiate);
        }
        
    }

    bool BothPlayerReadyCheck()
    {
        foreach (bool state in playerReadyDict.Values)
        {
            if (state == false)
            {
                return false;
            }
        }
        return true;
    }
}
