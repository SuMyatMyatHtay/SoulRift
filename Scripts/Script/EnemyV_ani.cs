using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV_ani : MonoBehaviour
{
    public EnemyV _code; 

    public void Attack()
    {
        //when the attack lands 
        _code.Attack(); 
    }
    public void AttackFinish()
    {
        //this will run when the attack animation plays finish 
        print("Enemy_ani attackFinish");
        _code.AttackFinish(); 
    }


    public void InjuredFinish()
    {
        print("Enemy_ani injuredFinish");
        _code.InjuredFinish(); 
    }

    public void DeathFinish()
    {
        _code.DeathFinish(); 
    }
}
