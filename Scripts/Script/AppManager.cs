using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{

    public static AppManager me;

    private void Awake()
    {
        if (me)
        {
            Destroy(this.gameObject); 
        }
        else
        {
            me = this; 
        }
    }
    public bool Player; 
    public bool Girl;
    public bool Vampire;
    public bool Goblin; 
    public bool CH30;
    public bool JLayGo;
    public bool Pumpkin;
    public bool Parasite;
    public bool Brute;
    public bool Skeleton; 

    // Start is called before the first frame update


    

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Player = true; 
        Vampire = false;
        Girl = false;
        Goblin = false; 
        CH30 = false;
        JLayGo = false;
        Pumpkin = false;
        Parasite = false;
        Brute = false;
        Skeleton = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
