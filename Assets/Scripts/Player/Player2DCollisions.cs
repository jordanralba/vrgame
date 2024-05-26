using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2DCollisions : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Star")){
            Destroy(col.gameObject);
            playerStats.UpdateStars(1);
            gameState.UpdateStarDisplay(true);
            gameState.collectedStars += 1;
        }
    }
}
