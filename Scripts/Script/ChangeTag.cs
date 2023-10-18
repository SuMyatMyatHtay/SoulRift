using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTag : MonoBehaviour
{
    public string PlayerTag = "Player";
    //_GirlObject.GetComponent<GirlMain>()._state = GirlMain.Girl_state.jump;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = PlayerTag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
