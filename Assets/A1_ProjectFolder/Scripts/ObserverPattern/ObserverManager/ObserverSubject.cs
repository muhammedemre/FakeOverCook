using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverSubject: ISubject
{
    private List<IObserver> observerList;
    public ObserverSubjects subjectType;
    public ObserverSubject(ObserverSubjects _subjectType)
    {
        observerList = new List<IObserver>();
        subjectType = _subjectType;
    }
    
    public void Subscribe(IObserver observer)
    {
        observerList.Add(observer);
    }

    public void NotifyObservers()
    {
        observerList.ForEach(o =>
        {
            o.GetUpdated(this);
        });
    }
    
}
