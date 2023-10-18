using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    public float noticeRange = 100f;
    private NavMeshAgent _nav;
    private Animator _ani;
    public GameObject player;
    public GameObject[] SkeletonArr;
    //door outside level 1 
    public GameObject DoorCollider;
    public GameObject DoorRight;
    public GameObject DoorLeft;
    public float skeletonAttackRange = 60f;
    public int counter = 0;
    public float Rotate_amt = 2.0f;
    public GameObject StaticDoor;
    private bool start = false;
    public OverlayText OverlayText;
    public Player PlayerScript;

    void Start()
    {

        SkeletonArr = GameObject.FindGameObjectsWithTag("Skeleton");

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        foreach (GameObject skeleton in SkeletonArr)
        {
            _nav = skeleton.GetComponent<NavMeshAgent>();
            _nav.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        print(counter);
        if (counter >= 10)
        {
            DoorCollider.GetComponent<Collider>().enabled = true;
            StaticDoor.SetActive(false);
            StaticDoor.isStatic = false;
            DoorLeft.GetComponent<Animator>().SetTrigger("DoorOpen");
            DoorRight.GetComponent<Animator>().SetTrigger("DoorOpen");
        }
        if (GameObject.Find("Level1Enemy1") == null)
        {
            if (start == false)
            {
                OverlayText.show = true;
                OverlayText.NewText = "Kill Skeletons until door open!";
                OverlayText.UpdateText();
                start = true;
            }
            //We check the distance for All player Object 
            foreach (GameObject skeleton in SkeletonArr)
            {

                if (skeleton != null)
                {
                    _nav = skeleton.GetComponent<NavMeshAgent>();
                    _nav.enabled = true;
                    print("here");
                    StartCoroutine(waitForSeconds(skeleton));
                }
                
            }


        }




    }


    private IEnumerator waitForSeconds(GameObject skeleton)
    {
        yield return new WaitForSeconds(5f);
        if (skeleton != null)
        {
            if (skeleton.name == "skeleton_animated_dead")
            {
                Vector3 currentPosition = skeleton.transform.position;
                currentPosition.y = 5f;
                skeleton.transform.position = currentPosition;
                _ani = skeleton.GetComponent<Animator>();
                _nav = skeleton.GetComponent<NavMeshAgent>();
                _nav.SetDestination(player.transform.position);
                _ani.SetTrigger("Walking");
                Vector3 _direction = player.transform.position - skeleton.transform.position;
                float distanceToPlayer = Vector3.Distance(skeleton.transform.position, player.transform.position);
                skeleton.transform.rotation = Quaternion.Slerp(skeleton.transform.rotation, Quaternion.LookRotation(_direction), Time.deltaTime * Rotate_amt); float angleToRotate = Vector3.Angle(skeleton.transform.forward, _direction);

                if (Vector3.Distance(player.transform.position, skeleton.transform.position) < skeletonAttackRange)
                {
                    _ani = skeleton.GetComponent<Animator>();

                    _nav.enabled = true;
                    _ani.SetTrigger("Attack");
                    _nav.isStopped = true;
                }


                else if (Vector3.Distance(player.transform.position, skeleton.transform.position) < noticeRange)
                {

                    _ani = skeleton.GetComponent<Animator>();
                    _nav = skeleton.GetComponent<NavMeshAgent>();
                    _nav.enabled = true;
                    _nav.SetDestination(player.transform.position);
                    _ani.SetTrigger("Walking");
                    skeleton.transform.localScale = new Vector3(40, 40, 40);

                }
            }
        }
       
   
        
       
    }




}
