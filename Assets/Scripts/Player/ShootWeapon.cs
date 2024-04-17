using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ShootWeapon : MonoBehaviour
{
    public bool controlState = false;
    public GameObject bulletPrefab;
    public Transform launchPos;
    public Transform launch2DPos;
    public Transform aim;
    bool canShoot = false;
    public float shootDelay;
    public float bulletSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 joystickAxis = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        launch2DPos.LookAt(aim);
    }
    IEnumerator Pause(){
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
    public void PickedUpTrigger(Transform launch){
        canShoot = true;
        controlState = false;
        launchPos = launch;
    }
    public void PickedUp2DTrigger(){
        canShoot = true;
        controlState = true;

    }
    public void DroppedTrigger(){
        canShoot = false;
    }
    public void Fire(){
        if(controlState){
           if(canShoot){
           GameObject bullet = Instantiate(bulletPrefab) as GameObject;
            bullet.SetActive(true);
            bullet.transform.position = launch2DPos.transform.position;
            bullet.transform.rotation = launch2DPos.transform.rotation; 
            bullet.GetComponent<Rigidbody>().AddForce(launch2DPos.transform.right * bulletSpeed, ForceMode.Impulse);
            }
            return;
        } 
        if(canShoot){
            GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                bullet.SetActive(true);
                bullet.transform.position = launchPos.transform.position;
                bullet.transform.rotation = launchPos.transform.rotation; 
                bullet.GetComponent<Rigidbody>().AddForce(launchPos.transform.forward * bulletSpeed, ForceMode.Impulse);
        }
    }
}
