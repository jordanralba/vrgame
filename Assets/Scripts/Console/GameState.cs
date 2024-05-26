using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public GameObject player;
    public GameObject player2D;
    public GameObject screen;
    public GameObject[] enemies2D;
    public int totalStars;
    public int collectedStars = 0;
    public GameObject[] stars;
    public Sprite enabledStar;
    public int hearts;
    public static int enemiesRemaining = 0;
    public GameObject[] portals;
    public Transform portalPos;
    bool portalsActive = false;
    public GameObject activeDisk;

    public Material defaultScreen;



    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject enemy in enemies2D){
            enemiesRemaining++;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(collectedStars == totalStars){
            if(!portalsActive){
                player2D.SetActive(false);
                SpawnPortal();
                activeDisk.GetComponent<LevelDisk>().isComplete = true;
            }
        }
        if(enemiesRemaining == 0){
            portals[1].SetActive(true);
        }
        // if(activeLevel != null){
        //   Debug.Log(activeLevel.name);  
        // }
        
    }
    public void Teleport(GameObject gameObject){
       
        gameObject.transform.position = portalPos.position;
        gameObject.transform.rotation = portalPos.rotation;
        
    }
    public void UpdateStarDisplay(bool setActive){
        //stars[collectedStars].GetComponent<Image>().sprite = enabledStar;
        if(setActive) stars[collectedStars].SetActive(true);
        else 
        {
            for(int i = 0;i<stars.Length;i++){
                stars[i].SetActive(false);
            }
            
        }
        
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

    public void ChangeDisplay(){
        screen.GetComponent<MeshRenderer>().material = defaultScreen;
    }public void ChangeDisplay(Material material){
        screen.GetComponent<MeshRenderer>().material = material;
    }

    public void WarpReality(){
        if(PlayerStats.abilityLevel <= 0 ) return;
        activeDisk.GetComponent<LevelDisk>().level.GetComponent<DimensionTracker>().CycleDimension();
    }
}
