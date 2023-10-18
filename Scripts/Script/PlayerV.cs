using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV : MonoBehaviour
{

    public float Health_amt;
    public int playerCheck;
    public GameObject PostProcessingGO; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health_amt <= 0)
        {
            //then die 
            //print("Player Die");
            //Destroy(this.gameObject); 
            gameObject.tag = "Untagged";

            if(playerCheck == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void Damage(float _dmg)
    {
        Health_amt -= _dmg; 
        if(playerCheck == 1)
        {
            PostProcessingGO.GetComponent<PostProcessing>().UpdateVignetteIntensity(Health_amt); 
        }
    }
}
