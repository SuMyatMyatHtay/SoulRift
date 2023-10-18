using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class MawMain : MonoBehaviour
{

    public enum Enemy_State
    {
        idle,
        chase,
        attack,
        death
    }

    public AudioSource wakeUpMaw;
    public Enemy_State _state;
    public Enemy_State prev_state;
    public GameObject player;
    public GameObject Enemy;
    public float Notice_Range = 100f;
    public float Attack_Range = 50f;
    private NavMeshAgent _nav;
    private Animator _ani;
    public float Rotate_amt = 2.0f;
    public float maxDistance = 50f;
    public MawCollider[] Enemy_Health;
    public bool alrDead = false;
    private float yTransform = -13.6f;
    public GameObject Teleportation;
    public GameObject KachujinSet;
    public object Enemytransform { get; private set; }
    public bool activated = false;
    public GameObject doorRight;
    public GameObject doorLeft;
    public OverlayText OverlayText;
    public Player PlayerScript;

    private void Start()
    {
        Teleportation.SetActive(false);
        _nav = Enemy.GetComponent<NavMeshAgent>();
        _ani = Enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float totalEnemyHealth = Enemy_Health[0].Enemy_Health + Enemy_Health[1].Enemy_Health;
        //enemy face target 
        //direction facing angle
        if (totalEnemyHealth > 0)
        {

            if (activated == true)
            {
                Vector3 _direction = player.transform.position - Enemy.transform.position;
                Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, Quaternion.LookRotation(_direction), Time.deltaTime * Rotate_amt); float angleToRotate = Vector3.Angle(Enemy.transform.forward, _direction);
 
                if (_state == Enemy_State.idle)
                {
                    _ani.SetBool("Idle", false);
                    _ani.SetBool("IdleWalking", true);
                    _nav.SetDestination(player.transform.position);
                    if (Vector3.Distance(player.transform.position, Enemy.transform.position) < Notice_Range)
                    {
                        _nav.SetDestination(player.transform.position);
                        _state = Enemy_State.chase;

                    }


                }
                else if (_state == Enemy_State.chase)
                {

                    _ani.SetBool("IdleWalking", true);

                    if (Vector3.Distance(player.transform.position, Enemy.transform.position) < Attack_Range)
                    {
                        _nav.isStopped = true;
                        _state = Enemy_State.attack;
                        _ani.SetTrigger("Attack");
                    }

                    else if (Vector3.Distance(player.transform.position, Enemy.transform.position) < Notice_Range)
                    {
                        _nav.SetDestination(player.transform.position);
                        _state = Enemy_State.chase;
                    }
                    else
                    {

                        _nav.SetDestination(player.transform.position);
                        _state = Enemy_State.idle;
                    }


                }
                else if (_state == Enemy_State.attack)
                {
                    if (Vector3.Distance(player.transform.position, Enemy.transform.position) > Attack_Range)
                    {
                        _state = Enemy_State.chase;
                        _nav.SetDestination(player.transform.position);

                    }
                    else
                    {
                        _state = Enemy_State.chase;
                    }


                }

            }

            _ani.SetFloat("Motion", _nav.velocity.magnitude);

        }
        else
        {
            if (alrDead == false)
            {
                alrDead = true;
                _ani.SetBool("Hurt", false);
                _ani.SetTrigger("Death");
                _state = Enemy_State.death;
                _nav.isStopped = true;
            }

        }

    }

    public IEnumerator openDoors()
    {
        _ani.SetBool("IdleWalking", true);
        yield return new WaitForSeconds(5f);
        doorRight.GetComponent<Animator>().SetTrigger("DoorOpen");
        doorLeft.GetComponent<Animator>().SetTrigger("DoorOpen");
        activated = true;
        wakeUpMaw.Play();
        _state = Enemy_State.chase;
        if (_nav != null)
        {
            _nav.SetDestination(player.transform.position);
        }



    }

    public void afterFlexing()
    {
        activated = true;
        _state = Enemy_State.chase;
        _nav.SetDestination(player.transform.position);

    }


    public void DestroyEnemy()
    {

        OverlayText.show = true;
        OverlayText.NewText = "Enter the teleportation for your rebirth";
        OverlayText.UpdateText();
        KachujinSet.SetActive(false);
        Teleportation.SetActive(true);
        Destroy(gameObject);
    }

    public void SetChase()
    {

        _ani.SetTrigger("FinishHurt");
        _ani.SetBool("Hurt", false);
        _state = Enemy_State.chase;
    }

   
    public IEnumerator GoDown()
    {
        float elapsedTime = 0f;
        float duration = 3f;
        Vector3 startPosition = Enemy.transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, yTransform, startPosition.z);

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration; // Calculate the interpolation factor
            Enemy.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }


    }

    public void AttackFinish()
    {
        _state = Enemy_State.chase;
        _nav.isStopped = false;

    }

   
}
