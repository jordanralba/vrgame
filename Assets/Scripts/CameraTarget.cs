using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public Transform cameraTarget;
    public Transform controller;
    public Transform start;
    public float scale = 0.5f;
    bool isTargeting = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isTargeting) return;
        Vector3 distanceBetween = new Vector3(start.localPosition.z - controller.localPosition.x, start.localPosition.y - controller.localPosition.y, start.localPosition.x - controller.localPosition.z);
        Debug.Log(distanceBetween);
        //if(distanceBetween.magnitude > 5 || distanceBetween.x <= 0)return;
        if(distanceBetween.x > 5 || distanceBetween.x <= 0)return;
        transform.localPosition = new Vector3(distanceBetween.x*scale, transform.localPosition.y, distanceBetween.y*scale);
        cameraTarget.localPosition = new Vector3((distanceBetween.x * -1f), cameraTarget.localPosition.y, cameraTarget.localPosition.z);
        //Debug.Log(distanceBetween);
        transform.LookAt(cameraTarget, Vector3.up);
    }
    public void PickedUpTrigger(){
        Debug.Log(isTargeting);
        isTargeting = false;
        Debug.Log(isTargeting);
  
    }public void DroppedTrigger(){
        Debug.Log(isTargeting);
        isTargeting = true;
        Debug.Log(isTargeting);
    }
}
