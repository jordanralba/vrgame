using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
    public float bulletDamage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy")){
            Debug.Log("Enemy Hit");
            collision.gameObject.GetComponent<EnemyStats>().UpdateHealth(bulletDamage*-1);    
        }
        Destroy(gameObject);        
    }
}
