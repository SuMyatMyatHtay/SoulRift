using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2EnemyAni : MonoBehaviour
{
    public Level2Enemy _code;
    public EnemyTwoAni EnemyTwoAni;
    // Start is called before the first frame update
    public void Attackfinish()
    {
        _code.AttackFinish();
    }

    public void Dead()
    {

      //  EnemyTwoAni.StartBreaking();
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