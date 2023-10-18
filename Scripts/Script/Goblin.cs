using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Goblin : MonoBehaviour
{

    public enum Goblin_state 
    {
        wait, idle, mascot, done
    }
    public Goblin_state _state;
    public GameObject Target_obj;
    public GameObject Player_obj; 
    public NavMeshAgent _nav;
    public Animator _ani;
    public float noticeRange;
    public float arriveRange;

    // Start is called before the first frame update
    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _ani = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_state == Goblin_state.done)
        {
            transform.LookAt(Target_obj.transform.position);
            //_state = Goblin_state.wait
        }
        else if (_state == Goblin_state.wait)
        {
            //_state = Goblin_state.wait
        }
        else if (_state == Goblin_state.mascot)
        {
            if (Vector3.Distance(Target_obj.transform.position, transform.position) < arriveRange)
            {
                _ani.SetTrigger("done");
                _state = Goblin_state.done;
            }
            //_nav.SetDestination(Target_obj.transform.position);
            else if (Vector3.Distance(Player_obj.transform.position, transform.position) < noticeRange)
            {
                
                if (Vector3.Distance(Target_obj.transform.position, transform.position) < Vector3.Distance(Target_obj.transform.position, Player_obj.transform.position))
                {
                    _ani.SetFloat("Speed", 0.5f);
                    //_nav.speed = 0.5f;
                }
                else if (Vector3.Distance(Target_obj.transform.position, transform.position) >= Vector3.Distance(Target_obj.transform.position, Player_obj.transform.position))
                {
                    _ani.SetFloat("Speed", 1f);
                    //_nav.speed = 1f;
                }
                _nav.SetDestination(Target_obj.transform.position);
                //_state = Mutant_state.attack;
                //_ani.SetTrigger("Attack");
                //print("error checking for attack");
                //_nav.isStopped = true; //this is to stop the navmeshagent 
            }
            else
            {
                _state = Goblin_state.idle;
                _ani.SetTrigger("idle");
            }

            //else if (Vector3.Distance(Target_obj.transform.position, transform.position) < Notice_range)
            //{

            //if it is, then use navMeshAgent to moe to the Target_obj
            // _nav.SetDestination(Target_obj.transform.position);
            //}

        }
        else if (_state == Goblin_state.idle)
        {
            if (Vector3.Distance(Player_obj.transform.position, transform.position) < noticeRange)
            {
                _state = Goblin_state.mascot;
                _ani.SetTrigger("mascot");
            }
        }
    }
}
