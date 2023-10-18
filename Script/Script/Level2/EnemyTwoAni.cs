using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoAni : MonoBehaviour
{
    public GameObject[] LightningArr;
    public EnemyTwo _code;
    public ParticleSystem BreakGlass;
    public AudioSource breakGlassAudio;
    public GameObject[] displays;
    private void Start()
    {
        foreach (GameObject Lightning in LightningArr)
        {
            Lightning.GetComponent<ParticleSystem>().Stop();
        }
        BreakGlass.Stop();
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

    public void StartBreaking()
    {
        StartCoroutine(PlayGlassBreaking());
    }

    //play when display glass breaks
    public IEnumerator PlayGlassBreaking()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Animator>().SetTrigger("OutOfBox");

    }

    //Play lightning for attack
    public void LightningPlay()
    {
        foreach (GameObject Lightning in LightningArr)
        {
            Lightning.GetComponent<ParticleSystem>().Play();
        }
    }

    //Stop lightning after attack 
    public void LightningEnd()
    {
        foreach (GameObject Lightning in LightningArr)
        {
            Lightning.GetComponent<ParticleSystem>().Stop();
        }
    }

    public void glassSound()
    {
        breakGlassAudio.Play();
    }

    //when enemy two kicking box animation completes
    public void startActivating()
    {

        BreakGlass.Play();
        foreach (GameObject display in displays)
        {
            Destroy(display);
        }
        _code.activated = true;
        StartCoroutine(PauseParticle());
    }

    public IEnumerator PauseParticle()
    {
        yield return new WaitForSeconds(5f);
        BreakGlass.Pause();
    }

}
