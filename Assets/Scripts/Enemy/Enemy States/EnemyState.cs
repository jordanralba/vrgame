using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected EnemyStateController eSc;
    public abstract void CheckTransitions();
    public abstract void Act();
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    //the below fuction is telling this abstract class to inherent the properties of the ESC
    public EnemyState(EnemyStateController eSc)
    {
        this.eSc = eSc;
    }
}