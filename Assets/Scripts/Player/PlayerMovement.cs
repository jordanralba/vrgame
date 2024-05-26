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
    public bool isGrounded2D;
    public bool isGrounded;
    public LayerMask[] groundMasks;
    public GameObject player2D;
    
    Rigidbody playerRb;
    Rigidbody player2DRb;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //player2DRb = player2D.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePlayer2D(){
        player2DRb = player2D.GetComponent<Rigidbody>();
    }
    void GroundCheck(){
        bool grounded = false;
        bool grounded2D = false;
        foreach(LayerMask ground in groundMasks){ 
            grounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, ground);
            grounded2D = Physics.Raycast(player2D.transform.position, Vector3.down, ground2DDistance, ground);
            if(grounded) isGrounded = true;
            if(grounded2D) isGrounded2D = true;
        }
        if(!grounded && !isGrounded) isGrounded = false;    
        if(!grounded2D && !isGrounded2D) isGrounded2D = false;
        //Debug.DrawRay(transform.position, Vector3.down, Color.red, groundDistance);
        //Debug.DrawRay(player2D.transform.position, Vector3.down, Color.red, ground2DDistance);
    }
    public void Jump(){
        GroundCheck();
        if (controlState)
        {   
            if(isGrounded2D){
                Debug.Log("2D Jumped");
                player2DRb.AddRelativeForce(Vector3.up * jumpPower*mult2D, ForceMode.VelocityChange);
            }
            isGrounded2D = false;
            return;
        }
        if(isGrounded){
            Debug.Log("Jumped");
            playerRb.AddRelativeForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
        }
        isGrounded = false;
        
        
    }
    public void Move(){
        Vector2 joystickAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        if (controlState)
        {   
            player2DRb.AddRelativeForce(new Vector3(joystickAxis.x, 0, joystickAxis.y)*accelerationScale*mult2D);
            return;
        }
        playerRb.AddRelativeForce(new Vector3(joystickAxis.x, 0, joystickAxis.y)*accelerationScale);
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
