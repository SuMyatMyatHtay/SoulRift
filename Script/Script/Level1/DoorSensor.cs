using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorSensor : MonoBehaviour
{
    public GameObject DoorRight;
    public GameObject DoorLeft;
    public GameObject[] skeleton;
    private NavMeshAgent _nav;
    private Animator _ani;
    public GameObject Enemy;
    public GameObject player;
    public GameObject staticWall;
    [HideInInspector]
    public bool enter=false;

    private void Start()
    {
        _nav = Enemy.GetComponent<NavMeshAgent>();
        _ani = Enemy.GetComponent<Animator>();
        enter = false;
        staticWall.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"|| other.gameObject.tag == "MainCamera")
        {

            DoorLeft.GetComponent<Animator>().SetTrigger("DoorOpen");
            DoorRight.GetComponent<Animator>().SetTrigger("DoorOpen");
            _nav.SetDestination(player.transform.position);
            enter = true;
            for (int i = 0; i < skeleton.Length; i++)
            {
                skeleton[i].GetComponent<Animator>().SetTrigger("DoorOpen");
            }
           
        }
    }

    private void OnTriggerExit(Collider other)
    {

        DoorLeft.GetComponent<Animator>().SetTrigger("DoorClose");
        DoorRight.GetComponent<Animator>().SetTrigger("DoorClose");
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MainCamera")
        {
            StartCoroutine(wait5Secs());
        }
    }

    private IEnumerator wait5Secs()
    {

     
        // Wait for 2 seconds before executing the code inside this block
        yield return new WaitForSeconds(5.0f);
        staticWall.SetActive(true);
        DoorLeft.GetComponent<Animator>().SetTrigger("DoorClose");
        DoorRight.GetComponent<Animator>().SetTrigger("DoorClose");
        gameObject.GetComponent<Collider>().enabled = false;

    }
}
