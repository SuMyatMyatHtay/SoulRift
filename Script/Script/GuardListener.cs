using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardListener : MonoBehaviour
{
    public MawMain MawMain;
    

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("HellKingGuards") == null)
        {
            StartCoroutine(MawMain.openDoors());
        }
    }
}
