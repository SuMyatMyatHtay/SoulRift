using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI; 

public class EnemyV : MonoBehaviour
{
    public enum Mutant_state //is used to store different states 
    {
        idle, chase, attack, death, injured, sleep, patrol
    }
    public Mutant_state _state; 

    public GameObject Target_obj;
    public float Attack_range;
    public float Notice_range;
    public float Awake_range;
    public LayerMask Wall_mask;

    public NavMeshAgent _nav;
    public Animator _ani;

    public float Health_amt, HealthMax_amt;
    public Image Health_image;
    public GameObject HealthBar_canvas;
    public GameObject AnigameObject; 
    public GameObject GoldenGoose; 
    public GameObject blood_ps;

    public bool injureTest;
    public bool Awake;
    //public int countTemp; 

    public int Patrol_index;
    public List<GameObject> PatrolStation1;
    public List<GameObject> PatrolStation2;
    public List<GameObject> PatrolStation3;
    public List<GameObject> PatrolStation4;

    public bool lastVampire;
    public float Rotate_amt = 2f;
    public void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _ani = GetComponentInChildren<Animator>();
        injureTest = false;
        Awake = false; 
        //countTemp = 0; 
        _nav.speed = 3f;
        lastVampire = false;
        GoldenGoose.SetActive(false); 

        /*
        List<GameObject> PatrolStation1 = new List<GameObject>();
        List<GameObject> PatrolStation2 = new List<GameObject>();

        for (int i = 0; i < GameManager.me.Patrol_list.Count; i++)
        {
            if ( i < 4)
            {
                PatrolStation1.Add(GameManager.me.Patrol_list[i]); 
            }
            else if (i < 8)
            {
                PatrolStation2.Add(GameManager.me.Patrol_list[i]); 
            }
        }
        */
    }

    private void Update()
    {
        
        if (_state == Mutant_state.death)
        {   
            /*
            GameManager.me.Enemy_Left -= 1; 
            if(GameManager.me.Enemy_Left == 0)
            {
                lastVampire = true; 
            }
            */
        }

        else 
        { 
            if (Health_amt <= 0)
            {
                _ani.SetTrigger("Death");
                Health_image.fillAmount = 0f;
                _state = Mutant_state.death;
                //mutant deals damage on death 
                //deal damage, etc 
                // if want to disappear after a while 
                //Destroy(gameObject, 10f);

                //HealthBar_canvas.SetActive(false); 
                //AnigameObject.SetActive(false);
                //gameObject.tag = "Untagged"; 
            }

            
            
            else if (injureTest == true)
            {
                Health_image.fillAmount = Health_amt / HealthMax_amt;

                if (_state != Mutant_state.injured)
                {
                    _ani.SetTrigger("Injured");
                    _nav.isStopped = true;
                    injureTest = false; 
               
                }
                
                print("Injured state animation"); 
                _state = Mutant_state.injured;
            }
            else
            {
                if (_state == Mutant_state.sleep)
                {
                    if (Vector3.Distance(Target_obj.transform.position, transform.position) < Awake_range)
                    {
                        _state = Mutant_state.chase;
                        _ani.SetTrigger("AwakeT");
                        //_nav.isStopped = true;

                    }
                }

                else if (_state == Mutant_state.idle)
                {
                    /* Unity AI before 3.06.43 
                    if (Target_obj)
                    {
                        //check if target_obj is within notice_range 
                        if(Vector3.Distance(Target_obj.transform.position, transform.position) < Notice_range)
                        {

                            //if it is, then go to state.chase 
                            _state = Mutant_state.chase; 
                        }
                    }

                    //if no target look for one 
                    //if our player has the tag 
                    else
                    {
                        Target_obj = GameObject.FindGameObjectWithTag("Player"); 
                    }
                    */
                    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                    List<GameObject> otherPlayers = new List<GameObject>();

                    foreach (GameObject player in players)
                    {
                        if (player != gameObject) // Exclude the GameObject with this script
                        {
                            otherPlayers.Add(player);
                        }
                    }
                    Debug.Log(otherPlayers.Count + " otherPlayers.Count"); 

                    //check distance for every single player object picked 
                    foreach (GameObject player in otherPlayers)
                    {
                        if (Vector3.Distance(player.transform.position, transform.position) < Notice_range)
                        {
                            if (!Physics.Linecast(player.transform.position, transform.position, Wall_mask))
                            {
                                //assign this player object to Target_obj, so the rest of the coe can run 
                                //if it is, then go to state.chase 
                                Target_obj = player;
                                _state = Mutant_state.chase;
                            }

                        }
                    }

                    if (!Target_obj)
                    {
                        _state = Mutant_state.patrol;

                        float nearest_dist = Mathf.Infinity;
                        GameObject nearest_obj = null;

                        List<GameObject> CheckQuarterList = new List<GameObject>();
                        bool firstQuarter = true;
                        bool secondQuarter = true;
                        bool thirdQuarter = true;
                        bool fourthQuarter = true; 

                        GameObject[] tempMatess = GameObject.FindGameObjectsWithTag("Enemy");
                        List<GameObject> tempMates = new List<GameObject>();

                        foreach (GameObject player in tempMatess)
                        {
                            if (player != gameObject) // Exclude the GameObject with this script
                            {
                                tempMates.Add(player);
                            }
                        }


                        Debug.Log(tempMates.Count + " tempMates.Length");
                        Debug.Log(tempMatess.Length + " tempMatess.Length"); 
                        //Debug.Log(tempMates); 
                        foreach(GameObject tempMate in tempMates)
                        {
                          
                            if (tempMate.GetComponent<EnemyV>().Patrol_index >= 0 && tempMate.GetComponent<EnemyV>().Patrol_index <= 3)
                            {
                                firstQuarter = false; 
                            }
                            else if (tempMate.GetComponent<EnemyV>().Patrol_index >= 4 && tempMate.GetComponent<EnemyV>().Patrol_index <= 7)
                            {
                                secondQuarter = false; 
                            }
                            else if (tempMate.GetComponent<EnemyV>().Patrol_index >= 8 && tempMate.GetComponent<EnemyV>().Patrol_index <= 11)
                            {
                                thirdQuarter = false;
                            }
                            else if (tempMate.GetComponent<EnemyV>().Patrol_index >= 12 && tempMate.GetComponent<EnemyV>().Patrol_index <= 15)
                            {
                                fourthQuarter = false;
                            }

                        }

                        if(firstQuarter == true)
                        {
                            CheckQuarterList.AddRange(PatrolStation1); 
                        }
                        if (secondQuarter == true)
                        {
                            CheckQuarterList.AddRange(PatrolStation2);
                        }
                        if(thirdQuarter == true)
                        {
                            CheckQuarterList.AddRange(PatrolStation3); 
                        }
                        if (fourthQuarter == true)
                        {
                            CheckQuarterList.AddRange(PatrolStation4);
                        }

                        //foreach(GameObject _patrol in GameManager.me.Patrol_list)
                        for (var i = 0; i < CheckQuarterList.Count; i++)
                        {
                            GameObject _patrol = CheckQuarterList[i]; 
                            float _dist = Vector3.Distance(transform.position, _patrol.transform.position); 
                            if(_dist < nearest_dist)
                            {
                                nearest_dist = _dist;
                                nearest_obj = _patrol; 
                            }
                        }


                        if (nearest_obj)
                        {
                            Target_obj = nearest_obj;
                            Patrol_index = GameManager.me.Patrol_list.IndexOf(Target_obj);
                        }

                        //Target_obj = GameManager.me.Patrol_list[0]; 
                    }

                    

                    //no mention of Target_obj now, it can run if it is empty 

                }

                else if(_state == Mutant_state.patrol)
                {
                    _nav.speed = 5.8f;
                    bool Have_player = false; 
                    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

                    //check distance for every single player object picked 

                    foreach (GameObject player in players)
                    {
                        if (Vector3.Distance(player.transform.position, transform.position) < Notice_range)
                        {
                            if (!Physics.Linecast(player.transform.position, transform.position, Wall_mask))
                            {
                                //assign this player object to Target_obj, so the rest of the coe can run 
                                //if it is, then go to state.chase 
                                Target_obj = player;
                                _state = Mutant_state.chase;
                            }

                        }
                    }

                    if (Have_player)
                    {
                        _state = Mutant_state.chase;
                    }
                    else
                    {

                        if (Vector3.Distance(Target_obj.transform.position, transform.position) > 0.1f)
                        {

                            //not yet reached, move to it. 
                            _nav.SetDestination(Target_obj.transform.position);
                        }

                        else
                        {
                            /*
                            if (Patrol_index == GameManager.me.Patrol_list.Count - 1)
                            //count needs to -1 cuz count starts from 0;
                            {
                                Patrol_index = 4;
                            }
                            else
                            {
                                Patrol_index++;
                            }
                            */

                            if((Patrol_index + 1) % 4 == 0)
                            {
                                Patrol_index = Patrol_index - 3; 
                            }
                            else
                            {
                                Patrol_index++;
                            }
                            Target_obj = GameManager.me.Patrol_list[Patrol_index];
                            Patrol_index = GameManager.me.Patrol_list.IndexOf(Target_obj);
                        }
                    }
                }
                
                else if (_state == Mutant_state.chase)
                {
                    
                    if (Target_obj) //check if Target_obj exists or not. 
                    {

                        //check if target_obj is within notice_range 
                        if (Vector3.Distance(Target_obj.transform.position, transform.position) < Attack_range)
                        {
                            _state = Mutant_state.attack;
                            _ani.SetTrigger("Attack");
                            //print("error checking for attack");
                            _nav.isStopped = true; //this is to stop the navmeshagent 
                        }

                        else if (Vector3.Distance(Target_obj.transform.position, transform.position) < Notice_range)
                        {

                            //if it is, then use navMeshAgent to moe to the Target_obj
                            _nav.SetDestination(Target_obj.transform.position);
                        }

                        else //if not, it gives up and go back to idle state
                        {
                            //Target obj is still alive, remove the reference 

                            Target_obj = null;
                            _state = Mutant_state.idle;
                        }
                    }
                    else
                    {
                        _state = Mutant_state.idle;
                    }


                }
                else if (_state == Mutant_state.attack)
                {
                    if (Target_obj)
                    {
                        /*
                        Vector3 _dir = new Vector3(Target_obj.transform.position.x, Target_obj.transform.position.y, Target_obj.transform.position.z) - transform.position;
                        transform.forward = Vector3.RotateTowards(transform.forward, _dir, 90 * Mathf.Deg2Rad * Time.deltaTime, Time.deltaTime);
                        transform.LookAt(Target_obj.transform.position);
                        */

                        Vector3 _direction = Target_obj.transform.position - transform.position;
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction), Time.deltaTime * Rotate_amt); float angleToRotate = Vector3.Angle(transform.forward, _direction);

                    }


                }
                //we want this to run regardless of state, so put outside 
                _ani.SetFloat("Speed", _nav.velocity.magnitude);

                //fill amount only goes from 0 to 1 
                Health_image.fillAmount = Health_amt / HealthMax_amt;
                HealthBar_canvas.transform.LookAt(Camera.main.transform.position);
            }
        } 
         
    }

    public void Attack ()
    {
        //deal damage to target 
        //print("ouch");

        //reduced by 10 each time 

        if (Target_obj)
        {
            if(Vector3.Distance(Target_obj.transform.position, transform.position) < Attack_range)
            {
                Target_obj.GetComponent<PlayerV>().Damage(10f); 
                //Target_obj.GetComponent<PlayerV>().Health_amt -= 10f;
            }

            
        }
        
    }

    public void AttackFinish()
    {
        //print("attack finish ");
        _state = Mutant_state.chase;
        //rmb to turn the nav mesh back on 
        _nav.isStopped = false;
        
         
    }

    public void InjuredFinish()
    {
        //print("injured finish please please ");
        _state = Mutant_state.chase;
        _nav.isStopped = false;
        injureTest = false; 
    }

    public void DeathFinish()
    {
        if(GameManager.me.Enemy_Left == 1)
        {
            GoldenGoose.SetActive(true); 
        }
        GameManager.me.Enemy_Left -= 1;
        HealthBar_canvas.SetActive(false);
        AnigameObject.SetActive(false);
        gameObject.tag = "Untagged";

    }

    public void Damage(float _dmg, Vector3 _pos)
    {
        Health_amt -= _dmg;
        Vector3 _dir = new Vector3(_pos.x, transform.position.y, _pos.z) - transform.position;
        //ps_position is to add up some height to the blood particle 
        Vector3 ps_position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        GameObject _blood = Instantiate(blood_ps, ps_position, Quaternion.LookRotation(_dir));
        Destroy(_blood, 1f); 
    }

    
}
