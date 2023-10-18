using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireBallAttack : MonoBehaviour
{
    public InputActionProperty Left_pri;
    [Header("FireBall Properties")]
    public GameObject spark;
    public GameObject pf_FireBall;
    [SerializeField] private GameObject ShootPoint;
    [SerializeField] private float fireBallSpeed = 2400f;
    [SerializeField] private float fireBallLife = 10f;
    //for EnemyDamage script to get the amount of damage from the gun
    public float _damageAmt = 10f;
    private bool canShoot = true;
    private ParticleSystem gunsparks;

    private void Start()
    {
        gunsparks = spark.GetComponent<ParticleSystem>();
        gunsparks.Stop();
        pf_FireBall.SetActive(false);
    }

    public void FireBallLaunch()
    {
        if (canShoot)
        {
            StartCoroutine(ShootFireBall());
        }
    }

    private IEnumerator ShootFireBall()
    {
        pf_FireBall.SetActive(true);
        gunsparks.Play();

        GameObject tmpFireBall = Instantiate(pf_FireBall, ShootPoint.transform.position, ShootPoint.transform.rotation);
        Rigidbody rb = tmpFireBall.GetComponent<Rigidbody>();
        rb.AddForce(ShootPoint.transform.forward * fireBallSpeed);

        yield return new WaitForSeconds(5f);
        canShoot = false;
        Destroy(tmpFireBall);
        gunsparks.Stop();
        pf_FireBall.SetActive(false);

        StartCoroutine(Cooldown());

    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2f);
        canShoot = true;
    }

    public void NotLaunch()
    {
        gunsparks.Stop();
        pf_FireBall.SetActive(false);
    }
}
