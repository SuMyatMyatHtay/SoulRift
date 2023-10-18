using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MawAni : MonoBehaviour
{
    public MawMain _code;

    public void Dead()
    {
        _code.DestroyEnemy();
    }

    public void SetChase()
    {
        _code.SetChase();
    }

    public void goDown()
    {
        StartCoroutine(_code.GoDown());
    }

    public void AttackFinish()
    {
        _code.AttackFinish();
    }

    public void afterFlexing()
    {
        _code.afterFlexing();
    }


}
