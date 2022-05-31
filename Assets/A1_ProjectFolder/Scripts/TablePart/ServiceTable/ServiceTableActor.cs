﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceTableActor : MonoBehaviour
{
    [SerializeField] private TablePartActor tablePartActor;
    public void AssignTheFunctionality()
    {
        tablePartActor.TableFunction += ServiceTableInteractionProcess;
    }

    void ServiceTableInteractionProcess(HumanActor humanActor)
    {
        print("ServiceTableInteractionProcess");
    }
}
