using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScared : EnemyState
{
    public EnemyScared(EnemyStateController eSc) : base(eSc) { }
    Rigidbody enemyRb;
    bool inRange = true;
    public override void OnStateEnter(){
        enemyRb = eSc.GetComponent<Rigidbody>();
    }public override void CheckTransitions(){
        inRange = Physics.CheckSphere(eSc.transform.position, eSc.attackRange, eSc.playerLayer);                                                                                               
        if(!inRange){
            eSc.SetState(new EnemyIdle(eSc));
        }
        if(eSc.targetPortal){
            eSc.SetState(new EnemyHunting(eSc));
        }
    }public override void Act(){
        Vector3 lookDirection = (eSc.player.transform.position - eSc.transform.position).normalized;
        eSc.transform.LookAt(lookDirection, Vector3.up);
        enemyRb.AddForce(-lookDirection * eSc.speed * Time.deltaTime, ForceMode.VelocityChange);
    }public override void OnStateExit(){
        
    }
}