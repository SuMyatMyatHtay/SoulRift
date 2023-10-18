using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV_WeakPoint : MonoBehaviour
{
    public GameObject mainObject; 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Headshot script"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        GameObject collidedObject = col.gameObject;

        if (collidedObject.tag == "Bullet")
        {
            Debug.Log("Head Shot"); 
            //mainObject.GetComponent<EnemyV>().injureTest = true;
            //if (mainObject.GetComponent<EnemyV>()._state == EnemyV.Mutant_state.injured)
            //{
                mainObject.GetComponent<EnemyV>().Damage(30f, transform.position);
            //}
            /*
            collidedObject.GetComponent<EnemyV>().injureTest = true;
            if (collidedObject.GetComponent<EnemyV>()._state == EnemyV.Mutant_state.injured)
            {
                collidedObject.GetComponent<EnemyV>().Damage(30f, transform.position);
            }
            */
        }
    }
}
