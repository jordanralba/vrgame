using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour
{
    
    public float speed;
    private Rigidbody projectileRb;
    //private Rigidbody enemyRb;
    public GameObject player;
    public GameObject target;
    //public GameObject enemy;
    public int bulletDamage;
    public float bulletLifetime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletLifetime);
        //player = GameObject.Find("2DPlayer");
        projectileRb = GetComponent<Rigidbody>();
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        projectileRb.AddForce(lookDirection * speed, ForceMode.VelocityChange);
        //enemyRb = enemy.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Player")){
            Debug.Log("Player Hit");
            collision.gameObject.GetComponent<PlayerStats>().UpdateHealth(bulletDamage*-1);    
        }
        Destroy(gameObject);        
    }
    
}
