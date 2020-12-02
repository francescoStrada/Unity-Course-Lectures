using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    private string _name;

    public string Name => _name;

    protected State(string name)
    {
        _name = name;
    }
    public abstract void Enter();
    public abstract void Tik();
    public abstract void Exit();
}
