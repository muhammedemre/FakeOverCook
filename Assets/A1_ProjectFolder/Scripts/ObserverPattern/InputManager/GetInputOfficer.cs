using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInputOfficer : MonoBehaviour
{
    private void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        if (GameManager.instance.currentGameState == GameStates.Menu)
        {
            MenuInput();
        }
        else if (GameManager.instance.currentGameState == GameStates.InGame)
        {
            InGameInput();
        }
    }

    void MenuInput()
    {
        Player1MenuInputs();
        Player2MenuInputs();
    }

    void Player1MenuInputs()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            MenuManager.instance.MenuActor.MenuInputInjection(PlayerEnums.Player1, MenuActor.MenuControlEnums.Up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MenuManager.instance.MenuActor.MenuInputInjection(PlayerEnums.Player1, MenuActor.MenuControlEnums.Down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MenuManager.instance.MenuActor.MenuInputInjection(PlayerEnums.Player1, MenuActor.MenuControlEnums.Left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MenuManager.instance.MenuActor.MenuInputInjection(PlayerEnums.Player1, MenuActor.MenuControlEnums.Right);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            MenuManager.instance.MenuActor.MenuInputInjection(PlayerEnums.Player1, MenuActor.MenuControlEnums.Backward);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            MenuManager.instance.MenuActor.MenuInputInjection(PlayerEnums.Player1, MenuActor.MenuControlEnums.Forward);
        }
    }
    void Player2MenuInputs()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            MenuManager.instance.MenuActor.MenuInputInjection(PlayerEnums.Player2, MenuActor.MenuControlEnums.Up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MenuManager.instance.MenuActor.MenuInputInjection(PlayerEnums.Player2, MenuActor.MenuControlEnums.Down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MenuManager.instance.MenuActor.MenuInputInjection(PlayerEnums.Player2, MenuActor.MenuControlEnums.Left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MenuManager.instance.MenuActor.MenuInputInjection(PlayerEnums.Player2, MenuActor.MenuControlEnums.Right);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            MenuManager.instance.MenuActor.MenuInputInjection(PlayerEnums.Player2, MenuActor.MenuControlEnums.Backward);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            MenuManager.instance.MenuActor.MenuInputInjection(PlayerEnums.Player2, MenuActor.MenuControlEnums.Forward);
        }
    }

    void InGameInput()
    {
        
    }
}
