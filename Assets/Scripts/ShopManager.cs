using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject heart;
    public GameObject portalGun;
    public GameObject normalGun;
    public GameObject portalBullets;
    public GameObject normalBullets;

    public GameObject[] items;

    public PlayerStats playerStats;

    MeshRenderer[] meshes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PurchaseItem(GameObject item){
        ShopItem shopItem = item.GetComponent<ShopItem>();
        int price = shopItem.price;
        int listIndex = shopItem.indexInList;
        Instantiate(item, items[listIndex].transform.position, transform.rotation, items[listIndex].transform);
        if(!shopItem.costStars){
            if(PlayerStats.points < price){
            Destroy(item);
            return;
            } 
            playerStats.UpdatePoints(price*-1);
        }
        else{
            if(PlayerStats.stars < price){
                Destroy(item);
                return;
            }
            playerStats.UpdateStars(price*-1);
        }  
        meshes = item.GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer mr in meshes){
            mr.enabled = true;
        }
        
        
    }
    public void DroppedItem(GameObject item){
        GameObject parent = item.transform.parent.gameObject;
        item.transform.parent = null;
        Destroy(parent);
    }

}
