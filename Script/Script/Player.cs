using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Level1Enemy _code;
    public GameObject Enemy;
    public GameObject player;
    public float Health_amt=500f;
    // Start is called before the first frame update
    public void Damage(float _dmg)
    {
        Health_amt -= _dmg;

    }
    void Update()
    {
        if (Health_amt <= 0)
        {

            SceneManager.LoadScene("DeathScene");

        }
    }
    


}
