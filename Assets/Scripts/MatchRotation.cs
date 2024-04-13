using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MatchRotation : MonoBehaviour
{
    public Transform target;
    public Transform trackingSpace;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, target.localRotation.eulerAngles.y, 0);   
        trackingSpace.position = transform.localPosition;
    }
    
}
