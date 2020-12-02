using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    public State NextState { get; }
    public Func<bool> Condition { get; }

    public Transition(State nextState, Func<bool> transitionCondition)
    {
        NextState = nextState;
        Condition = transitionCondition;
    }

}
