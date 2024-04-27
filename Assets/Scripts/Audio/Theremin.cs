using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theremin : MonoBehaviour
{
    public int activeHands = 0;
    public bool leftActive = false;
    public bool rightActive = false;
    ChuckSubInstance chuck;
    public GameObject[] hands;
    public Transform positionCompare;
    // Start is called before the first frame update
    void Start()
    {
        chuck = GetComponent<ChuckSubInstance>();
        chuck.RunCode(@"
                    440 => global float InFreq;
                    0 => global float soundAmplitude;
                    SinOsc s => dac;
                    while( true )
                    {
                    soundAmplitude => s.gain;
                    InFreq => s.freq;
                    10::ms => now;
                    }
                ");
    }

    // Update is called once per frame
    void Update()
    {
        if(leftActive && rightActive){
            activeHands = 2;
        }else if(leftActive && !rightActive){
            activeHands = 1;
        }else if(!leftActive && rightActive){
            activeHands = 1;
        }
        switch (activeHands){
            case 0: break;
            case 1: {
                if(leftActive){
                    Vector3 distanceBetween = new Vector3(positionCompare.position.x - hands[0].transform.position.x, positionCompare.position.y - hands[0].transform.position.y, positionCompare.position.z - hands[0].transform.position.z);
                    chuck.SetFloat("soundAmplitude", distanceBetween.y);
                    if(distanceBetween.magnitude > 0.75f){
                        leftActive = false;
                        chuck.SetFloat("soundAmplitude", 0);
                    }
                }else if(rightActive){
                    Vector3 distanceBetween = new Vector3(positionCompare.position.x - hands[1].transform.position.x, positionCompare.position.y - hands[1].transform.position.y, positionCompare.position.z - hands[1].transform.position.z);
                    chuck.SetFloat("soundAmplitude", distanceBetween.y);
                    if(distanceBetween.magnitude > 0.75f){
                        rightActive = false;
                        chuck.SetFloat("soundAmplitude", 0);
                    }
                }
                break;
            }
            case 2: {
                Vector3 distanceLeft = new Vector3(positionCompare.position.x - hands[0].transform.position.x, positionCompare.position.y - hands[0].transform.position.y, positionCompare.position.z - hands[0].transform.position.z);
                Vector3 distanceRight = new Vector3(positionCompare.position.x - hands[1].transform.position.x, positionCompare.position.y - hands[1].transform.position.y, positionCompare.position.z - hands[1].transform.position.z);
                if(distanceLeft.magnitude > 0.75f){
                        leftActive = false;
                }if(distanceRight.magnitude > 0.75f){
                        rightActive = false;
                }
                chuck.SetFloat("soundAmplitude", distanceLeft.y);
                chuck.SetFloat("InFreq", distanceRight.x * 1000);
                break;
            }
        }
    }
    


    void OnTriggerEnter(Collider other){
        GameObject parent = other.gameObject.transform.parent.transform.parent.transform.parent.gameObject;
        //GameObject parent = other.gameObject.transform.parent.gameObject;
        if(parent.name == "[BuildingBlock] Hand Tracking left"){
            //Debug.Log("Left");
            leftActive = true;
        }
        else if(parent.name == "[BuildingBlock] Hand Tracking right"){
            //Debug.Log("Right");
            rightActive = true;
        }
    }
    // void OnTriggerExit(Collider other){
    //     GameObject parent = other.gameObject.transform.parent.transform.parent.transform.parent.gameObject;
    //     //GameObject parent = other.gameObject.transform.parent.gameObject;
    //     Debug.Log(parent.name);
    //     // if(parent.name == "Hand Tracking left"){
    //     //     hand[0] = null;
    //     // }
    //     // else if(parent.name == "Hand Tracking right"){
    //     //     hand[1] = null;
    //     // }
    // }
}
