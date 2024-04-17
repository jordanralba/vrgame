using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : EnemyState
{
    bool inRange = true;
    public EnemyAttacking(EnemyStateController eSc) : base(eSc) { }

    public override void OnStateEnter(){
        eSc.StartFire();
        eSc.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    public override void CheckTransitions(){ 
        inRange = Physics.CheckSphere(eSc.transform.position, eSc.attackRange, eSc.playerLayer);                                                                                               
        if(!inRange && eSc.health > 6f){
            eSc.SetState(new EnemyHunting(eSc));
        }if(!inRange && eSc.health <= 6f){
            eSc.SetState(new EnemyScared(eSc));
        }
        if(eSc.targetPortal){
            eSc.SetState(new EnemyHunting(eSc));
        }
    }public override void Act(){
        eSc.transform.LookAt(eSc.player.transform, Vector3.up);
    }public override void OnStateExit(){
        eSc.StopFire();
    }
    
}