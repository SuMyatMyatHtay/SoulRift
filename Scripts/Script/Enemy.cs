using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Enemy : MonoBehaviour
{
    public enum Mutant_state
    {
        idleGirl, walkGirl, attackGirl
    }
    public Mutant_state _state;
    public NavMeshAgent _nav;
    public Animator _ani; 
    public GameObject Target_obj;
    public float Attack_range; 
    public float Notice_range; 

    // Start is called before the first frame update
    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _ani = GetComponentInChildren<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(_state == Mutant_state.idleGirl)
        {
            if(Vector3.Distance(Target_obj.transform.position, transform.position) < Notice_range)
            {
                _state = Mutant_state.walkGirl;
            }
        }
        else if (_state == Mutant_state.walkGirl)
        {
            if (Vector3.Distance(Target_obj.transform.position, transform.position) < Attack_range)
            {
                _state = Mutant_state.attackGirl;
                _ani.SetTrigger("Attack"); 
            }
            else if (Vector3.Distance(Target_obj.transform.position, transform.position) < Notice_range)
            {
                _nav.SetDestination(Target_obj.transform.position);
            }
            else
            {
                _state = Mutant_state.idleGirl;
            }
            
        }
        else if (_state == Mutant_state.attackGirl)
        {
            _ani.SetTrigger("attackGirl");
        }
        _ani.SetFloat("Speed", _nav.velocity.magnitude); 
        
    }

    public void AttackFinish()
    {
        _state = Mutant_state.walkGirl; 
    }
}
