using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2EnemyCollider : MonoBehaviour
{
    public float Enemy_Health = 180f;
    public FireBallAttack fireBallScript;
    public GameObject EnemyWithAni;
    private Animator _ani;
    public Level2Enemy _EnemyCode;
    public GameObject bloodParticles;
    private ParticleSystem _particles;
    private float MaxHealthAmt;
    public Image Health_image;
    public Canvas HealthBar_Canvas;


    private void Start()
    {
        MaxHealthAmt = Enemy_Health;
        _ani = gameObject.GetComponent<Animator>();
        _particles = bloodParticles.GetComponent<ParticleSystem>();
        var emission = _particles.emission;
        var rate = emission.rateOverTime;
        rate.constant = 0f;
        emission.rateOverTime = rate;

    }

    private void Update()
    {
        HealthBar_Canvas.transform.LookAt(Camera.main.transform.position);
    }


    private void OnTriggerEnter(Collider colliders)
    {
        Debug.Log(colliders);
        if (colliders.gameObject.tag == "Spark")
        {
            if (Enemy_Health > 0)
            {
                _ani.SetBool("Hurt", true);
                StartCoroutine(HandleHit());
                Enemy_Health -= fireBallScript._damageAmt;

            }
            if (Enemy_Health >= 0)
            {
                Health_image.fillAmount = Enemy_Health / MaxHealthAmt;
            }


        }

    }

    public IEnumerator HandleHit()
    {
        
        // Emit blood particles
        _particles.Emit(5);

        // Reduce emission rate gradually
        var emission = _particles.emission;
        var rate = emission.rateOverTime;
        float startEmissionRate = rate.constant;
        float targetEmissionRate = 0f;
        float elapsedTime = 0f;
        float duration = 10f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            float currentEmissionRate = Mathf.Lerp(startEmissionRate, targetEmissionRate, t);
            rate.constant = currentEmissionRate;
            emission.rateOverTime = rate;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }


    
}
