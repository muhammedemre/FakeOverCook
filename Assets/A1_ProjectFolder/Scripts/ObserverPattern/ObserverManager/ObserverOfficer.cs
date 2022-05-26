using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverOfficer: MonoBehaviour
{
    public Dictionary<ObserverSubjects, SubjectEventHandler> subjectEvents =
        new Dictionary<ObserverSubjects, SubjectEventHandler>();
    
    public delegate void SubjectEventHandler();
    
    event SubjectEventHandler PreGameStart;
    event SubjectEventHandler GameStarted;
    event SubjectEventHandler PostGameStart;
    event SubjectEventHandler Menu;
    event SubjectEventHandler PreLevelInstantiate;
    event SubjectEventHandler LevelInstantiate;
    event SubjectEventHandler PostLevelInstantiate;
    event SubjectEventHandler PreLevelEnd;
    event SubjectEventHandler LevelEnd;
    event SubjectEventHandler PostLevelEnd;
    event SubjectEventHandler GameQuit;
    
    public void Subscriber(IObserver observer, List<ObserverSubjects> _subjectTypeList)
    {
        GameManagerObserverOfficer gameManagerObserverOfficer = GameManager.instance.gameManagerObserverOfficer;

        foreach (ObserverSubjects subjectType in _subjectTypeList)
        {
            gameManagerObserverOfficer.observerSubjectDict[subjectType].Subscribe(observer);
        }
        
        AddEvents();
    }

    void AddEvents()
    {
        subjectEvents.Add(ObserverSubjects.PreGameStart, PreGameStart);
        subjectEvents.Add(ObserverSubjects.GameStart, GameStarted);
        subjectEvents.Add(ObserverSubjects.PostGameStart, PostGameStart);
        subjectEvents.Add(ObserverSubjects.Menu, Menu);
        subjectEvents.Add(ObserverSubjects.PreLevelInstantiate, PreLevelInstantiate);
        subjectEvents.Add(ObserverSubjects.LevelInstantiate, LevelInstantiate);
        subjectEvents.Add(ObserverSubjects.PostLevelInstantiate, PostLevelInstantiate);
        subjectEvents.Add(ObserverSubjects.PreLevelEnd, PreLevelEnd);
        subjectEvents.Add(ObserverSubjects.LevelEnd, LevelEnd);
        subjectEvents.Add(ObserverSubjects.PostLevelEnd, PostLevelEnd);
        subjectEvents.Add(ObserverSubjects.GameQuit, GameQuit);
    }
}
