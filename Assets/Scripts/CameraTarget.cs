using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public Transform cameraTarget;
    public Transform player;
    public Transform screen;
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
        Vector2 distanceBetween = new Vector2(player.localPosition.x, player.localPosition.z);
        if(distanceBetween.magnitude > 5 || distanceBetween.x <= 0)return;
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
