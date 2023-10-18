using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GirlMain : MonoBehaviour
{

    public GameObject HealthBar_canvas;

    public enum Girl_state
    {
        cry, jump, idle, chase, attack, death, done
    }
    public Girl_state _state;

    public GameObject Target_obj;
    public GameObject Player_obj; 
    public float Attack_range;
    public float Notice_range = 10;
    public LayerMask Wall_mask;
    public NavMeshAgent _nav;
    public Animator _ani;
    public float Health_amt, HealthMax_amt;
    public Image Health_image;
    
    public GameObject RedShoePost;
    public GameObject Health;
    public GameObject GirlReference; 

    public float speed;
    public AudioSource crying;
    public float cryingRage;
    public string PlayerTag = "Player";

    // Start is called before the first frame update
    private void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _ani = GetComponentInChildren<Animator>();
        RedShoePost.SetActive(true);
        Health.SetActive(false);
        speed = 0; 
    }

    // Update is called once per frame
    private void Update()
    {
        

        if(_state == Girl_state.death)
        {
            Target_obj.GetComponent<EnemyV>().Target_obj = null; 
        }
        
        else
        {
            speed = (Vector3.Distance(Player_obj.transform.position, transform.position) - 0) / (20 - 0);
            //print(speed); 
            Health_image.fillAmount = Health_amt / HealthMax_amt;
            HealthBar_canvas.transform.LookAt(Camera.main.transform.position);
            Health_amt = this.GetComponent<PlayerV>().Health_amt; 
            if (Health_amt <= 0)
            {
                _ani.SetTrigger("Death");
                Health_image.fillAmount = 0f;
                _state = Girl_state.death;
                Destroy(gameObject, 10f);
            }
            else if (_state == Girl_state.jump)
            {
                RedShoePost.SetActive(false);
                Health.SetActive(true); 
                _ani.SetTrigger("JumpT");
                _nav.isStopped = true;
            }
            else if (_state == Girl_state.cry)
            {

                if (Vector3.Distance(Player_obj.transform.position, transform.position) < 40f)
                {
                    crying.Play();
                    _state = Girl_state.cry;
                }
             
                //transform.LookAt(Camera.main.transform.position);
            }
            else if (_state == Girl_state.done)
            {
                _ani.SetTrigger("Wave");
                _nav.isStopped = true; 
            }

            else
            {
                if(_state == Girl_state.idle)
                {
                    
                    GameObject[] players = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (GameObject player in players)
                    {
                        if (Vector3.Distance(player.transform.position, transform.position) < Notice_range)
                        {
                            //if (!Physics.Linecast(player.transform.position, transform.position, Wall_mask))
                            //{
                                //assign this player object to Target_obj, so the rest of the coe can run 
                                //if it is, then go to state.chase 
                                Target_obj = player;
                                _state = Girl_state.chase;
                            //}

                        }                        
                    }

                    if (Vector3.Distance(Player_obj.transform.position, transform.position) > 0)
                    {
                        _state = Girl_state.chase; 
                    }



                }

                else if (_state == Girl_state.chase)
                {
                    if (Target_obj)
                    {
                        if(Target_obj.tag == "Untagged")
                        {
                            Target_obj = null;
                            _state = Girl_state.chase; 
                        }

                        else { 

                            if (Vector3.Distance(Target_obj.transform.position, transform.position) < Attack_range)
                            {
                                _state = Girl_state.attack;
                                _ani.SetTrigger("Attack");
                                //print("error checking for attack");
                                _nav.isStopped = true; //this is to stop the navmeshagent 
                            }

                            else if (Vector3.Distance(Target_obj.transform.position, transform.position) < Notice_range)
                            {

                            //if it is, then use navMeshAgent to moe to the Target_obj
                                _nav.SetDestination(Target_obj.transform.position);
                            }

                            else if (Vector3.Distance(Player_obj.transform.position, transform.position) > 16)
                            {
                                _ani.SetFloat("Speed", speed);
                                _nav.SetDestination(Player_obj.transform.position);
                            }
                            else if (Vector3.Distance(Player_obj.transform.position, transform.position) > 5)
                            {
                                _ani.SetFloat("Speed", speed);
                                _nav.SetDestination(Player_obj.transform.position);
                            }

                            else //if not, it gives up and go back to idle state
                            {
                                //Target obj is still alive, remove the reference 
                                //_nav.SetDestination(Player_obj.transform.position);
                                Target_obj = null;
                                _state = Girl_state.idle;
                            }
                        }
                    }
                    else
                    {
                        GameObject[] players = GameObject.FindGameObjectsWithTag("Enemy");
                        if (players.Length != 0)
                        {
                            foreach (GameObject player in players)
                            {
                                if (Vector3.Distance(player.transform.position, transform.position) < Notice_range)
                                {
                                    //if (!Physics.Linecast(player.transform.position, transform.position, Wall_mask))
                                    //{
                                    //assign this player object to Target_obj, so the rest of the coe can run 
                                    //if it is, then go to state.chase 
                                    Target_obj = player;
                                    _state = Girl_state.chase;
                                    //}

                                }
                            }
                        }
                        else if (Vector3.Distance(Player_obj.transform.position, transform.position) > 16)
                        {
                            _ani.SetFloat("Speed", speed);
                            _nav.SetDestination(Player_obj.transform.position);
                        }
                        else if (Vector3.Distance(Player_obj.transform.position, transform.position) > 5)
                        {
                            _ani.SetFloat("Speed", speed);
                            _nav.SetDestination(Player_obj.transform.position);
                        }
                        else
                        {
                            //_nav.SetDestination(Player_obj.transform.position);
                            //Target_obj = null;
                            _state = Girl_state.idle;
                        }
                        
                    }
                }
                else if (_state == Girl_state.attack)
                {
                    if (Target_obj)
                    {
                        Vector3 _dir = new Vector3(Target_obj.transform.position.x, Target_obj.transform.position.y, Target_obj.transform.position.z) - transform.position;
                        transform.forward = Vector3.RotateTowards(transform.forward, _dir, 90 * Mathf.Deg2Rad * Time.deltaTime, Time.deltaTime);
                    }
                }
            }
        }
    }

    public void JumpDone()
    {
        _state = Girl_state.chase; 
        _nav.isStopped = false;
        gameObject.tag = PlayerTag;
        gameObject.transform.position = GirlReference.transform.position;
        _nav.Warp(GirlReference.transform.position);
        AppManager.me.Girl = true;
        
    }
    
    public void Attack()
    {
        if (Target_obj)
        {
            Target_obj.GetComponent<EnemyV>().Health_amt -= 5f;
        }
    }

    public void AttackDone()
    {
        _state = Girl_state.chase;
        _nav.isStopped = false; 
    }
}
