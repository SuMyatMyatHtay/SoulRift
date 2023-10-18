using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ani : MonoBehaviour
{

    public Level1Enemy _code;
    // Start is called before the first frame update
 public void Attackfinish()
    {
        _code.AttackFinish();
    }

    public void Dead()
    {
        _code.DestroyEnemy();
    }

    public void goDown()
    {
        StartCoroutine(_code.GoDown());
    }

    public void SetChase()
    {
        _code.SetChase();
    }
}
