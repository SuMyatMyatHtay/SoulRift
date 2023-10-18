using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
using UnityEngine.InputSystem;

public class Vampire : MonoBehaviour
{
    public InputActionProperty Right_pri;
    [Header("Attack Properties")]


    public NavMeshAgent _nav;
    public Animator _ani;
    public GameObject Target_obj; 

    public void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _ani = GetComponentInChildren<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        _nav.SetDestination(Target_obj.transform.position);
        _ani.SetFloat("Speed", _nav.velocity.magnitude); 
        
        if(Right_pri.action.WasPressedThisFrame())
        {
            _ani.SetTrigger("Attack");
            _ani.SetBool("Move", true); 
        }
    }
}
