using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionTracker : MonoBehaviour
{
    public GameObject[] dimensions;
    public int numberOfSwaps = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CycleDimension(){
        //if(PlayerStats.abilityLevel <= 0) return;
        int totalDimensions = dimensions.Length;
        dimensions[numberOfSwaps%totalDimensions].SetActive(false);
        numberOfSwaps++;
        dimensions[numberOfSwaps%totalDimensions].SetActive(true);
    }
}
