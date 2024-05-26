using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDisk : MonoBehaviour
{
    public GameObject level;
    public bool isComplete;
    public Material screenRenderTexture;
    public GameObject player2D;
    //public GameObject[] enemies2D;
    public int stars;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelLock(GameObject obj, int layerId){
        if(isComplete){
            obj.layer = layerId;
            foreach (Transform child in obj.transform)
            {
                child.gameObject.layer = layerId;
                Transform children = child.GetComponentInChildren<Transform>();
                if (children != null) LevelLock(child.gameObject, layerId);
            }
        }
    } 
    public void LevelLock(int layerId){
        if(isComplete){
            level.layer = layerId;
            foreach (Transform child in level.transform)
            {
                child.gameObject.layer = layerId;
                Transform children = child.GetComponentInChildren<Transform>();
                if (children != null) LevelLock(child.gameObject, layerId);
            }
        }
    }
}
