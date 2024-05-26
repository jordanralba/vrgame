using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static int abilityLevel = 0;
    public static int points = 0;
    public static int stars = 0;
    public static int normalBullets = 0;
    public static int portalBullets = 0;

    public TextMeshProUGUI canvasPoints;
    public TextMeshProUGUI canvasStars;
    
    int currentHealth; 
    public int maxHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePoints(100);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(int addendValue){
        currentHealth += addendValue;
    }
    public void UpdatePoints(int addendValue){
        points += addendValue;
        canvasPoints.text = "$ "+points;
    }public void UpdateStars(int addendValue){
        stars += addendValue;
        canvasStars.text = "Stars: "+stars;
    }

    

}
