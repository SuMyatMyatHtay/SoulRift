using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAni : MonoBehaviour
{
    private ParticleSystem childParticle;
    void Start()
    {

        childParticle = GetComponentInChildren<ParticleSystem>();
        childParticle.Stop();
    }

    public void Death()
    {

        childParticle.Play();
        Destroy(gameObject);
    }
}
