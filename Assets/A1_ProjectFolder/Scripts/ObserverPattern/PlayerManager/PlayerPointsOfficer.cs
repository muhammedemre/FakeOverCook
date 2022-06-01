using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class PlayerPointsOfficer : SerializedMonoBehaviour
{
    
    [SerializeField] private Dictionary<PlayerEnums, List<int>> playerValues = new Dictionary<PlayerEnums, List<int>>();
    [SerializeField] private TextMeshProUGUI p1Timer, p2Timer, p1Score, p2Score;
    private bool timerOn = false;
    
    float nextTimeCheck = 0f;
    
    private void Update()
    {
        Timer();
    }

    public void PrepareValues()
    {
        nextTimeCheck = Time.time + 1;
        timerOn = true;
    }

    void Timer()
    {
        if (Time.time > nextTimeCheck)
        {
            nextTimeCheck = Time.time + 1;
            OneSecondDeduction();
        }
    }

    void OneSecondDeduction()
    {
        playerValues[PlayerEnums.Player1][1]--;
        playerValues[PlayerEnums.Player2][1]--;
        
        playerValues[PlayerEnums.Player1][1] = playerValues[PlayerEnums.Player1][1] < 0 ? 0 : playerValues[PlayerEnums.Player1][1];
        playerValues[PlayerEnums.Player2][1] = playerValues[PlayerEnums.Player2][1] < 0 ? 0 : playerValues[PlayerEnums.Player2][1];

        p1Timer.text = playerValues[PlayerEnums.Player1][1].ToString();
        p2Timer.text = playerValues[PlayerEnums.Player2][1].ToString();

        if (playerValues[PlayerEnums.Player1][1] <= 0 || playerValues[PlayerEnums.Player2][1]<=0)
        {
            GameFinish();
        }
        
    }

    void GameFinish()
    {
        WinnerCheck();
    }

    void WinnerCheck()
    {
        if (playerValues[PlayerEnums.Player1][0] > playerValues[PlayerEnums.Player2][0])
        {
            print("PLAYER 1 Wins");
        }
        else
        {
            print("PLAYER 2 Wins");
        }
    }

    public void PlayerPointAddition(int pointToAdd, PlayerEnums player)
    {
        print("PlayerPointAddition: "+pointToAdd + " Player : "+ player);
        playerValues[player][0] += pointToAdd;
        playerValues[player][0] = playerValues[player][0] < 0 ? 0 : playerValues[player][0];

        p1Score.text = playerValues[PlayerEnums.Player1][0].ToString();
        p2Score.text = playerValues[PlayerEnums.Player2][0].ToString();
    }
}
