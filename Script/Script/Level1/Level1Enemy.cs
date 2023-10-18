using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Level1Enemy : MonoBehaviour
{

    public enum Enemy_State
    {
        idle,
        chase,
        attack,
        death
    }

    public Enemy_State _state;
    public Enemy_State prev_state;
    public GameObject player;
    public GameObject Enemy;
    public float Notice_Range = 100f;
    public float Attack_Range = 50f;
    private NavMeshAgent _nav;
    private Animator _ani;
    public LayerMask WallMask;
    public float Rotate_amt = 2.0f;
    //DoorSensor script
    public DoorSensor doorSensor;
    public float maxDistance = 50f;
    public EnemyDamage Enemy_Health;
    public bool alrDead = false;
    private float yTransform = -13.6f;
    public OverlayText OverlayText;
    public Player PlayerScript;
    public object Enemytransform { get; private set; }
    private void Start()
    {
        _nav = GetComponentInChildren<NavMeshAgent>();
        _ani = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //enemy face target 
        //direction facing angle
        if (Enemy_Health.Enemy_Health > 0)
        {

            if (doorSensor.enter)
            {
                Vector3 _direction = player.transform.position - Enemy.transform.position;
                Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, Quaternion.LookRotation(_direction), Time.deltaTime * Rotate_amt); float angleToRotate = Vector3.Angle(Enemy.transform.forward, _direction);
                _ani.SetBool("Hurt", false);
                if (_state == Enemy_State.idle)
                {
                    _ani.SetBool("Idle", false);
                    _ani.SetBool("IdleWalk", true);

                        if (Vector3.Distance(player.transform.position, Enemy.transform.position) < Notice_Range)
                        {
                            _state = Enemy_State.chase;

                        }
                   

                }
                else if (_state == Enemy_State.chase)
                {

                    _ani.SetBool("IdleWalk", false);
               
                        if (Vector3.Distance(player.transform.position, Enemy.transform.position) < Attack_Range)
                        {
                            // Replace this with your desired attack range value
                            // Vector3 attackDirection = (player.transform.position - Enemy.transform.position).normalized;
                            //Enemy.transform.position = player.transform.position - attackDirection * Attack_Range;

                            _nav.isStopped = true;
                            _state = Enemy_State.attack;
                            _ani.SetTrigger("Attack");
                            Enemy.GetComponent<NavMeshAgent>().isStopped = true;
                        }

                        else if (Vector3.Distance(player.transform.position, Enemy.transform.position) < Notice_Range)
                        {
                            _nav.SetDestination(player.transform.position);
                        _state = Enemy_State.chase;
                    }
                        else
                        {
                            _state = Enemy_State.idle;
                        }

                 
                }
                else if (_state == Enemy_State.attack)
                {
                    _nav.ResetPath();
                    if (Vector3.Distance(player.transform.position, Enemy.transform.position) > Attack_Range)
                    {
                        _state = Enemy_State.chase;
                        _nav.SetDestination(player.transform.position);

                    }


                }

            }

            _ani.SetFloat("Motion", 1.5f);

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

    public void AttackFinish()
    {
        _state = Enemy_State.chase;
        _nav.isStopped = false;

    }
    public void DestroyEnemy()
    {
        OverlayText.show = true;
        OverlayText.NewText = "Player Health Remaining: " + PlayerScript.Health_amt;
        OverlayText.UpdateText();
        Destroy(gameObject);
    }
    public void Hurt()
    {
        _ani.SetBool("Hurt", true);
    }

    public void SetChase()
    {
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
}
