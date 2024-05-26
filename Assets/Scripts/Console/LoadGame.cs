using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public Transform target;
    GameObject console;
    GameState gS;
    // Start is called before the first frame update
    void Start()
    {
        console = transform.parent.gameObject;
        gS = console.GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Disk")){
            LoadGameData(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Disk")){
           UnloadGameData(); 
        }
    }
    public void LoadGameData(GameObject disk){
        LevelDisk lD = (LevelDisk)disk.GetComponent<LevelDisk>();
        gS.activeDisk = disk;
        gS.ChangeDisplay(lD.screenRenderTexture);
        gS.totalStars = lD.stars;
        gS.player2D = lD.player2D;
        gS.player2D.SetActive(true);
        PlayerMovement pM = gS.player.GetComponent<PlayerMovement>();
        pM.player2D = lD.player2D;
        pM.ChangePlayer2D();
    }
    public void UnloadGameData(){
        gS.activeDisk = null;
        gS.ChangeDisplay();
        gS.totalStars = 0;
        gS.collectedStars = 0;
        gS.UpdateStarDisplay(false);
        gS.player2D.SetActive(false);
    }
}
