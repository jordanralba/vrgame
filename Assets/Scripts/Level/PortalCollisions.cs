using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollisions : MonoBehaviour
{
    public GameState gameState;
    public GameObject player;
    public Transform teleportPos;
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
            collision.gameObject.GetComponent<EnemyStateController>().player = player;
            collision.gameObject.GetComponent<EnemyStateController>().targetPortal = false;
        }
        collision.gameObject.transform.position = teleportPos.position;
        collision.gameObject.transform.rotation = teleportPos.rotation;
    }
}
