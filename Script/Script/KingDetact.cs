using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingDetact : MonoBehaviour
{
    public GameObject king;
    public MawMain MawMain;
    private void OnTriggerEnter(Collider target)
    {
        print(target);
        if (target.tag=="Enemy")
        {
            king.GetComponent<Animator>().SetTrigger("DoorOpened");
        }
    }
}
