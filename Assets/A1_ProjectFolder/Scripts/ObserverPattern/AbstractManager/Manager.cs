using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class Manager : SerializedMonoBehaviour,IObserver
{
    public ObserverOfficer observerOfficer;
    [SerializeField] private List<ObserverSubjects> subscribeList = new List<ObserverSubjects>();
    
    private void Start()
    {
        observerOfficer.Subscriber(this, subscribeList);
        AssignEvents(observerOfficer);
    }
    public void GetUpdated(ISubject subject)
    {
        if (subject is ObserverSubject observerSubject)
        {
            observerOfficer.subjectEvents[observerSubject.subjectType].Invoke();
        }
    }
    public void AssignEvents(ObserverOfficer observerOfficer)
    {
        observerOfficer.subjectEvents[ObserverSubjects.PreGameStart] += PreGameStartProcess;
        observerOfficer.subjectEvents[ObserverSubjects.GameStart] += GameStartProcess;
        observerOfficer.subjectEvents[ObserverSubjects.PostGameStart] += PostGameStartProcess;
        observerOfficer.subjectEvents[ObserverSubjects.Menu] += MenuProcess;
        observerOfficer.subjectEvents[ObserverSubjects.PreLevelInstantiate] += PreLevelInstantiateProcess;
        observerOfficer.subjectEvents[ObserverSubjects.LevelInstantiate] += LevelInstantiateProcess;
        observerOfficer.subjectEvents[ObserverSubjects.PostLevelInstantiate] += PostLevelInstantiateProcess;
        observerOfficer.subjectEvents[ObserverSubjects.PreLevelEnd] += PreLevelEndProcess;
        observerOfficer.subjectEvents[ObserverSubjects.LevelEnd] += LevelEndProcess;
        observerOfficer.subjectEvents[ObserverSubjects.PostLevelEnd] += PostLevelEndProcess;
        observerOfficer.subjectEvents[ObserverSubjects.GameQuit] += GameQuitProcess;
    }

    public virtual void PreGameStartProcess()
    {
        print("Manager PreGameSTART PROCESS");
    }
    public virtual void GameStartProcess()
    {
        print("Manager GameSTART PROCESS");
    }
    public virtual void PostGameStartProcess()
    {
        print("Manager PostGameSTART PROCESS");
    }

    public virtual void MenuProcess()
    {
        print("Manager MenuProcess");
    }
    public virtual void PreLevelInstantiateProcess()
    {
        print("Manager PreLevelInstantiateProcess");
    }

    public virtual void LevelInstantiateProcess()
    {
        print("Manager LevelInstantiateProcess");
    }

    public virtual void PostLevelInstantiateProcess()
    {
        print("Manager PostLevelInstantiateProcess");
    }

    public virtual void PreLevelEndProcess()
    {
        print("Manager PreLevelEndProcess");
    }
    public virtual void LevelEndProcess()
    {
        print("Manager LevelEndProcess");
    }
    public virtual void PostLevelEndProcess()
    {
        print("Manager PostLevelEndProcess");
    }

    public virtual void GameQuitProcess()
    {
        print("Manager GameQuitProcess");
    }
}
