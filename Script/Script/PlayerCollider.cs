using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    public GameObject player;
    public GameObject Enemy;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider target)
    {
        
        if (GameObject.Find("Level1Enemy1") == null)
        {
            if (target.gameObject.tag == "Skeleton")
            {
                player.GetComponent<Player>().Damage(5f);
            }
        }
       if (target.gameObject.name == "EnemyAxeCollider")
        {

            player.GetComponent<Player>().Damage(20f);
        }
        else if(target.gameObject.name== "ParasiteLeftArmAttack")
        {
            player.GetComponent<Player>().Damage(20f);
        }
        else if (target.gameObject.name == "ParasiteRightArmAttack")
        {
            player.GetComponent<Player>().Damage(20f);
        }
       else if (target.gameObject.name=="MAWRightLeg")
        {
            player.GetComponent<Player>().Damage(30f);
        }
       else if(target.gameObject.name== "MAWLeftLegAttack")
        {
            player.GetComponent<Player>().Damage(30f);
        }
       else if (target.gameObject.name == "MAWLeftArm") {
            player.GetComponent<Player>().Damage(30f);

        }
       else if (target.gameObject.name == "MawRightArm")
        {
            player.GetComponent<Player>().Damage(30f);
        }
        else if (target.gameObject.tag == "Enemy")
        {
            player.GetComponent<Player>().Damage(10f);
        }

    }
 
}
