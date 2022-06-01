using System;
using UnityEngine;

public class UIManager : Manager
{
    public static UIManager instance;
    public UITaskOfficers UITaskOfficers;
    public GameObject menu, inGameScreen;
    private void Awake()
    {
        StaticCheck();
    }
    
    void StaticCheck()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    public override void GameStartProcess()
    {
        menu.gameObject.SetActive(true);
        GameManager.instance.gameManagerObserverOfficer.Publish(ObserverSubjects.Menu);
    }
}
