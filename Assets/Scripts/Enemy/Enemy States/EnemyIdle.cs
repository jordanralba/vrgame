using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    public EnemyIdle(EnemyStateController eSc) : base(eSc) { }
    bool inRange = false;
    public override void OnStateEnter(){

    }public override void CheckTransitions(){
        switch(eSc.health){
            case < 6f: 
                inRange = Physics.CheckSphere(eSc.transform.position, eSc.escapeRange, eSc.playerLayer);
                if(inRange){
                    eSc.SetState(new EnemyScared(eSc));  
                }
                break;
            case >=6f: 
                inRange = Physics.CheckSphere(eSc.transform.position, eSc.huntRange, eSc.playerLayer);
                if(inRange){
                    eSc.SetState(new EnemyHunting(eSc));  
                }
                break;
        }
        if(eSc.targetPortal){
            eSc.SetState(new EnemyHunting(eSc));
        }
    }public override void Act(){
        if(eSc.health < 20f){
          eSc.health += eSc.healthRegen * Time.deltaTime;  
        }
    }public override void OnStateExit(){
        
    }
}
