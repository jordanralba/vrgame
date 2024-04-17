using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    public float speed;

    public Transform launchPos;

    public GameObject projectile;
    public float spawnDelay = 2;
    public float spawnInterval = 1.5f;
    public float attackRange = 4f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemyFire", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyFire()
    {
        Instantiate(projectile, launchPos.position, transform.rotation);
    }
}
