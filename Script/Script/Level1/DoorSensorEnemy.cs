using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSensorEnemy : MonoBehaviour
{
    public GameObject DoorRight;
    public GameObject DoorLeft;
    public GameObject staticDoor;


    private void Start()
    {
        staticDoor.isStatic = false;
        staticDoor.SetActive(false);
    }
    private void OnTriggerEnter(Collider colliders)
    {
        if (colliders.gameObject.tag == "Enemy")
        {
            DoorLeft.GetComponent<Animator>().SetTrigger("DoorOpen");
            DoorRight.GetComponent<Animator>().SetTrigger("DoorOpen");
        }
        else if (colliders.gameObject.tag == "Player" &&!staticDoor.activeSelf)
        {
            DoorLeft.GetComponent<Animator>().SetTrigger("DoorOpen");
            DoorRight.GetComponent<Animator>().SetTrigger("DoorOpen");
        }
    }

    private void OnTriggerExit(Collider colliders)
    {

        DoorLeft.GetComponent<Animator>().SetTrigger("DoorClose");
        DoorRight.GetComponent<Animator>().SetTrigger("DoorClose");
        if (colliders.gameObject.tag == "Enemy")
        {
           StartCoroutine(wait5Secs());
        }
        
    }

    private IEnumerator wait5Secs()
    {
        // Wait for 2 seconds before executing the code inside this block
       
        yield return new WaitForSeconds(10f);
        staticDoor.SetActive(true);
        staticDoor.isStatic = true;
        DoorLeft.GetComponent<Animator>().SetTrigger("DoorClose");
        DoorRight.GetComponent<Animator>().SetTrigger("DoorClose");
        gameObject.GetComponent<Collider>().enabled = false;
    }


}
