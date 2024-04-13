using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    public float jumpPower = 1f;  
    public float groundDistance = 1.1f;
    public float ground2DDistance = 1.1f;
    public float accelerationScale = 10f;
    public float mult2D = .5f;
    private bool controlState = false; 
    bool isGrounded2D;
    bool isGrounded;
    public LayerMask groundMask;
    public GameObject player2D;
    
    Rigidbody playerRb;
    Rigidbody player2DRb;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        player2DRb = player2D.GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundMask);
        isGrounded2D = Physics.Raycast(player2D.transform.position, Vector3.down, ground2DDistance, groundMask);
        Debug.DrawRay(transform.position, Vector3.down, Color.red, groundDistance);
        Debug.DrawRay(player2D.transform.position, Vector3.down, Color.red, ground2DDistance);     
    }
    public void Jump(){
        Debug.Log(isGrounded2D);
        Debug.Log(isGrounded);
        if (controlState)
        {   
            if(isGrounded2D){
                Debug.Log("2D Jumped");
                player2DRb.AddRelativeForce(Vector3.up * jumpPower*mult2D, ForceMode.VelocityChange);
            }
            return;
        }if(isGrounded){
            Debug.Log("Jumped");
            playerRb.AddRelativeForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
        }
        
    }
    public void Move(){
        Vector2 rightJoystickAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        if (controlState)
        {   
            player2DRb.AddRelativeForce(new Vector3(rightJoystickAxis.x, 0, rightJoystickAxis.y)*accelerationScale*mult2D);
            return;
        }
        playerRb.AddRelativeForce(new Vector3(rightJoystickAxis.x, 0, rightJoystickAxis.y)*accelerationScale);
    }
    public void PickedUpTrigger(){
        Debug.Log(controlState);
        controlState = true;
        Debug.Log(controlState);
    }public void DroppedTrigger(){
        Debug.Log(controlState);
        controlState = false;
        Debug.Log(controlState);
    }
}
