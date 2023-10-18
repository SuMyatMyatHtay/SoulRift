using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager me;
    public GameObject MainPlayer;

    [Header("Golden Goose")]
    public GameObject GoldenGoose;
    public Transform GoldenGooseRef;
    public AudioSource CreepyAmbience;

    public void Awake()
    {
        me = this;
    }

    public int Enemy_Left; 

    public List<GameObject> Patrol_list;


    
    // Start is called before the first frame update
    void Start()
    {
       // CreepyAmbience.Play();
        //DontDestroyOnLoad(CreepyAmbience);
        Enemy_Left = 4; 
        //Debug.Log(AppManager.me.Alive_Vampire + " App manager on start"); 
    }

    // Update is called once per frame
    void Update()
    {
        if(MainPlayer == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScene");
        }
        
        
    }
}
