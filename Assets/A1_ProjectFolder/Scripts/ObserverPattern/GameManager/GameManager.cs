using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameManager : SerializedMonoBehaviour
{
    public static GameManager instance;
    public GameManagerObserverOfficer gameManagerObserverOfficer;
    [SerializeField] private float preGameStartDelay;
    public GameStates currentGameState = GameStates.Menu;

    private void Awake()
    {
        StaticCheck();
        
        gameManagerObserverOfficer.CreateSubjects();
        StartCoroutine(PreGameStartDelay());
    }

    IEnumerator PreGameStartDelay()
    {
        yield return new WaitForSeconds(preGameStartDelay);
        gameManagerObserverOfficer.Publish(ObserverSubjects.PreGameStart);
    }
    

    void StaticCheck()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }
    
}
