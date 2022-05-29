using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInputOfficer : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.instance.currentGameState == GameStates.Menu && !InputManager.instance.noInputTime)
        {
            MenuInput();
        }
        // GetInput();
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.currentGameState == GameStates.InGame && !InputManager.instance.noInputTime)
        {
            InGameInput();
        }
    }

    void GetInput()
    {
        if (GameManager.instance.currentGameState == GameStates.Menu && !InputManager.instance.noInputTime)
        {
            MenuInput();
        }
        else if (GameManager.instance.currentGameState == GameStates.InGame && !InputManager.instance.noInputTime)
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
        Player1InGameInput();
        Player2InGameInput();
    }

    void Player1InGameInput()
    {
        HumanActor player1Actor = LevelManager.instance.LevelCreateOfficer.currentLevel.GetComponent<LevelActor>()
            .player1Actor;
        
        player1Actor.HumanInputHandleOfficer.MenuInputInjection(Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S), Input.GetKey(KeyCode.A), Input.GetKey(KeyCode.D),
            Input.GetKeyDown(KeyCode.C));
    }
    void Player2InGameInput()
    {
        HumanActor player2Actor = LevelManager.instance.LevelCreateOfficer.currentLevel.GetComponent<LevelActor>()
            .player2Actor;
        player2Actor.HumanInputHandleOfficer.MenuInputInjection(Input.GetKey(KeyCode.UpArrow),
            Input.GetKey(KeyCode.DownArrow), Input.GetKey(KeyCode.LeftArrow), Input.GetKey(KeyCode.RightArrow),
            Input.GetKeyDown(KeyCode.L));
    }
}
