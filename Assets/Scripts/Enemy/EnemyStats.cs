using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{

    public float _enemyHealth = 20f;
    public float _enemyHealthRegen = .3f;
    [SerializeField] private Slider healthSlider;
    EnemyStateController eSc;
    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        eSc = GetComponent<EnemyStateController>();
       healthSlider.minValue = 0;
       healthSlider.maxValue = _enemyHealth;
       healthSlider.value = _enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
     public void UpdateHealth(float addendValue){
        _enemyHealth += addendValue;
        eSc.health += addendValue;
        healthSlider.value = _enemyHealth;
        if(_enemyHealth <= 0){
            //SpawnManager.enemyCount -= 1;
            playerStats.UpdatePoints(2);
            Destroy(gameObject);
            GameState.enemiesRemaining -= 1;
        }
    }
}
