using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardsCollider: MonoBehaviour
{

    public float Enemy_Health = 100f;
    public FireBallAttack fireBallScript;
    private Animator _ani;
    public GuardsMain _EnemyCode;
    public GameObject bloodParticles;
    private ParticleSystem _particles;

    // Start is called before the first frame update
    void Start()
    {
        _ani = gameObject.GetComponent<Animator>();
        _particles = bloodParticles.GetComponent<ParticleSystem>();
        var emission = _particles.emission;
        var rate = emission.rateOverTime;
        rate.constant = 0f;
        emission.rateOverTime = rate;
    }
    private void OnTriggerEnter(Collider colliders)
    {
        Debug.Log(colliders);
        if (colliders.gameObject.tag == "Spark")
        {
            if (Enemy_Health > 0)
            {
                Enemy_Health -= fireBallScript._damageAmt;

                _ani.SetBool("Hurt", true);
                StartCoroutine(HandleHit());

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
