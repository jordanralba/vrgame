using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public GameObject player;
    public GameObject player2D;
    public GameObject[] enemies2D;
    public int totalStars = 3;
    public static int collectedStars = 0;
    public GameObject[] stars;
    public Sprite enabledStar;
    public int hearts;
    public static int enemiesRemaining = 0;
    public GameObject[] portals;
    public Transform portalPos;
    bool portalsActive = false;



    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject enemy in enemies2D){
            enemiesRemaining++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(collectedStars == totalStars){
            if(!portalsActive){
                player2D.SetActive(false);
                SpawnPortal();
            }
            
        }
        if(enemiesRemaining == 0){
            portals[1].SetActive(true);
        }
    }
    public void Teleport(GameObject gameObject){
       
        gameObject.transform.position = portalPos.position;
        gameObject.transform.rotation = portalPos.rotation;
        
    }
    public void UpdateStarDisplay(){
        //stars[collectedStars].GetComponent<Image>().sprite = enabledStar;
        stars[collectedStars].SetActive(true);
    }
    
    
    void SpawnPortal(){
        /*foreach (GameObject portal in portals)
        {
            portal.SetActive(true);
            
        }*/
        portals[0].SetActive(true);
        portalsActive = true;
        foreach(GameObject enemy in enemies2D){
            enemy.GetComponent<EnemyStateController>().targetPortal = true;
        }
    }
}
