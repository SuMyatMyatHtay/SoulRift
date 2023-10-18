using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardsAni: MonoBehaviour
{
    public GuardsMain _code;
    // Start is called before the first frame update
    public void Attackfinish()
    {
        _code.AttackFinish();
    }

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
}