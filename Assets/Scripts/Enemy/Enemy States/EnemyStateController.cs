using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    public GameObject player;
    public GameObject portal;
    public bool targetPortal = false;

    public LayerMask playerLayer;
    public EnemyState currentState;
    public float health;
    public float healthRegen;
    public float speed;

    public Transform launchPos;

    public GameObject projectile;
    public float spawnDelay = 2f;
    public float spawnInterval = 1.5f;
    public float attackRange;
    public float huntRange;
    public float escapeRange;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        health = GetComponent<EnemyStats>()._enemyHealth;
        healthRegen = GetComponent<EnemyStats>()._enemyHealthRegen;
        SetState(new EnemyIdle(this));
    }

    // Update is called once per frame
    void Update()                                                                                   
    {
        currentState.CheckTransitions();
        currentState.Act();
    }

    public void SetState(EnemyState eS){
        if(currentState != null){
            currentState.OnStateExit();
        }
        currentState = eS;
        Debug.Log(currentState);
        if(currentState != null){
            currentState.OnStateEnter();
        }
    }
    public void StartFire(){
        InvokeRepeating("EnemyFire", spawnDelay, spawnInterval);
    }public void StopFire(){
        CancelInvoke("EnemyFire");
    }
    public void EnemyFire()
    {
        Debug.Log("Shoot");
        GameObject bullet= Instantiate(projectile, launchPos.position, transform.rotation) as GameObject;
        bullet.GetComponent<EnemyProjectileController>().player = player;
    }
}
