using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHunting : EnemyState
{
    public EnemyHunting(EnemyStateController eSc) : base(eSc) { }
    Rigidbody enemyRb;
    bool inRange = true;
    bool inARange = false;
    GameObject target; 
    public override void OnStateEnter(){
        enemyRb = eSc.GetComponent<Rigidbody>();
        if(eSc.targetPortal){
            target = eSc.portal;
        }else{
            target = eSc.player;
        }
    }public override void CheckTransitions(){
        inRange = Physics.CheckSphere(eSc.transform.position, eSc.huntRange, eSc.playerLayer);                                                                                               
        inARange = Physics.CheckSphere(eSc.transform.position, eSc.attackRange, eSc.playerLayer);                                                                                               
        if(inARange){
            eSc.SetState(new EnemyAttacking(eSc));
        }if(!inRange){
            eSc.SetState(new EnemyIdle(eSc));
        }
        
    }public override void Act(){
        eSc.transform.LookAt(target.transform, Vector3.up);
        Vector3 lookDirection = (target.transform.position - eSc.transform.position).normalized;
        enemyRb.AddForce(lookDirection * eSc.speed * Time.deltaTime, ForceMode.VelocityChange);

    }public override void OnStateExit(){
        
    }
}