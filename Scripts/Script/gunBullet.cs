using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunBullet : MonoBehaviour
{
    //public EnemyV _code;
    public GameObject _EnemyObject; 

    // Start is called before the first frame update
    void Start()
    {
        print("gun bullet script start");
        //_code = GetComponent<EnemyV>();
        _EnemyObject = GameObject.Find("Vampire"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider col)
    {


        print("OnCollisionEnter");
        GameObject collidedObject = col.gameObject;

        if(collidedObject.tag == "Enemy")
        {
            Destroy(gameObject); 
            collidedObject.GetComponent<EnemyV>().injureTest = true; 
            if(collidedObject.GetComponent<EnemyV>()._state == EnemyV.Mutant_state.injured)
            {
                collidedObject.GetComponent<EnemyV>().Damage(10f, transform.position); 
            }

            if(AppManager.me.Vampire == false)
            {
                AppManager.me.Vampire = true; 
            }
        }

        /* This is for one fix player
        _EnemyObject.GetComponent<EnemyV>().injureTest = true;
        //_EnemyObject.GetComponent<EnemyV_ani>().Injured(); 

        if(_EnemyObject.GetComponent<EnemyV>()._state == EnemyV.Mutant_state.injured)
        {
            _EnemyObject.GetComponent<EnemyV>().Health_amt -= 10; 
            //_EnemyObject.GetComponent<EnemyV>().countTemp += 1; 
        }
        */
    }
}
