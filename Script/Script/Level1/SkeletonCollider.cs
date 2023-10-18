using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCollider : MonoBehaviour
{
    private SkeletonAni skeletonAni;
    public float skeletonHealth=20f;
    private Animator _ani;
    private GameObject gameObjectParent;
    private bool alrdead=false;
    public Skeleton skeletonScript;
    void Start()
    {
        gameObjectParent = transform.parent.gameObject;
  
        _ani = gameObjectParent.GetComponent<Animator>();
   
    }

    private void OnTriggerEnter(Collider colliders)
    {

        if (GameObject.Find("Level1Enemy1") == null)
        {
            if (colliders.gameObject.tag == "Spark")
            {
                skeletonHealth -= 10f;

            }
        }
    }

     void Update()
    {
        if (skeletonHealth <= 0)
        {
            if (alrdead != true)
            {
                skeletonScript.counter ++;
                gameObjectParent = transform.parent.gameObject;
            print(gameObjectParent);
            _ani = gameObjectParent.GetComponent<Animator>();
            gameObjectParent.name = "skeleton_animated_dead";
        
                _ani.SetTrigger("Death");
                alrdead = true;
            }
        }
    }

 
    }
