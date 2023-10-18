using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardsMain : MonoBehaviour
{

    public enum Enemy_State
    {

        idle,
        patrol,
        chase,
        attack,
        death,
        hurt
    }

    public float Notice_Range = 100f;
    public float Attack_Range = 50f;
    public Enemy_State _state;
    public Enemy_State prev_state;
    public int Patrol_index = 0;
    public List<GameObject> PatrolList;
    public GameObject EnemyChild;
    private bool alrDead = false;
    public GameObject player;
    private NavMeshAgent _nav;
    private Animator _ani;
    public float Rotate_amt = 2.0f;
    public GuardsCollider EnemyColliderScript;
    private GameObject nearest_obj = null;
    private float yTransform = -13.6f;
    public bool doorOpened=false;
    public OverlayText OverlayText;
    public Player PlayerScript;
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("MainCamera");

        }
        _nav = EnemyChild.GetComponent<NavMeshAgent>();
        _ani = EnemyChild.GetComponent<Animator>();

    }

    private void Update()
    {

        if (EnemyColliderScript.Enemy_Health > 0)
        {

            if (_state == Enemy_State.idle)
            {

                _ani.SetBool("Idle", false);
                _ani.SetBool("IdleWalking", true);

                if (doorOpened == true)
                {
                    _nav.SetDestination(PatrolList[Patrol_index].transform.position);

                    if (Vector3.Distance(player.transform.position, EnemyChild.transform.position) < Notice_Range)
                    {
                        Vector3 _direction = player.transform.position - EnemyChild.transform.position;
                        EnemyChild.transform.rotation = Quaternion.Slerp(EnemyChild.transform.rotation, Quaternion.LookRotation(_direction), Time.deltaTime * Rotate_amt); float angleToRotate = Vector3.Angle(EnemyChild.transform.forward, _direction);
                        _state = Enemy_State.chase;

                    }
                    else
                    {

                        _nav.SetDestination(PatrolList[Patrol_index].transform.position);
                        _state = Enemy_State.patrol;

                    }
                }
                else
                {

                    _nav.SetDestination(PatrolList[Patrol_index].transform.position);
                    _state = Enemy_State.patrol;
                }

            }
            else if (_state == Enemy_State.patrol)
            {
                if (Vector3.Distance(player.transform.position, EnemyChild.transform.position) < Notice_Range)
                {
                    _state = Enemy_State.chase;
                    }
                else
                {
                    
                    if (Vector3.Distance(PatrolList[Patrol_index].transform.position, EnemyChild.transform.position) > 13f)
                    {
                        _nav.SetDestination(PatrolList[Patrol_index].transform.position);
                        _ani.SetFloat("Motion", 0.5f);
                    }
                    else
                    {
                        
                        _nav.ResetPath();
                        if (Patrol_index == 1)
                        {
                            Patrol_index = 0;
                        }
                        else
                        {
                            Patrol_index = 1;
                        }
                        _nav.SetDestination(PatrolList[Patrol_index].transform.position);
                        _ani.SetFloat("Motion", 0.5f);

                    }
                
                }
            

                }
                else if (_state == Enemy_State.chase && doorOpened==true)
                {
                _nav.SetDestination(PatrolList[Patrol_index].transform.position);
                Vector3 _direction = player.transform.position - EnemyChild.transform.position;
                    EnemyChild.transform.rotation = Quaternion.Slerp(EnemyChild.transform.rotation, Quaternion.LookRotation(_direction), Time.deltaTime * Rotate_amt); float angleToRotate = Vector3.Angle(EnemyChild.transform.forward, _direction);

                    if (Vector3.Distance(player.transform.position, EnemyChild.transform.position) < Attack_Range)
                    {
                        _ani.SetBool("IdleWalking", false);
                        _nav.isStopped = true;
                        _state = Enemy_State.attack;
                        _ani.SetTrigger("Attack");
                    }
                    else if (Vector3.Distance(player.transform.position, EnemyChild.transform.position) < Notice_Range)
                    {
                        _ani.SetBool("IdleWalking", true);
                        _nav.SetDestination(player.transform.position);
                        _state = Enemy_State.chase;
                    }
                    else
                    {
                        _state = Enemy_State.idle;
                    }
                }
                else if (_state == Enemy_State.attack && doorOpened == true)
                {
                    Vector3 _direction = player.transform.position - EnemyChild.transform.position;
                    EnemyChild.transform.rotation = Quaternion.Slerp(EnemyChild.transform.rotation, Quaternion.LookRotation(_direction), Time.deltaTime * Rotate_amt); float angleToRotate = Vector3.Angle(EnemyChild.transform.forward, _direction);
                    _nav.ResetPath();

                    if (Vector3.Distance(player.transform.position, EnemyChild.transform.position) > Attack_Range)
                    {
                        _state = Enemy_State.chase;
                        _nav.SetDestination(player.transform.position);

                    }
                    else
                    {
                        _state = Enemy_State.chase;
                    }

                }
                _ani.SetFloat("Motion", _nav.velocity.magnitude);
            }
        

        //dead
        else
        {
            if (alrDead == false)
            {
                alrDead = true;
                _state = Enemy_State.death;
                _ani.SetBool("Hurt", false);
                _ani.SetTrigger("Death");
            }
        }
    }



    public void SetChase()
    {
        _ani.SetTrigger("FinishHurt");
        _ani.SetBool("Hurt", false);
        _state = Enemy_State.chase;

    }

    public void DestroyEnemy()
    {
        OverlayText.show = true;
        OverlayText.NewText = "Player Health Remaining: " + PlayerScript.Health_amt;
        OverlayText.UpdateText();

        Destroy(gameObject);
    }

    public void AttackFinish()
    {
        _state = Enemy_State.chase;
        _nav.isStopped = false;

    }

    public IEnumerator GoDown()
    {
        float elapsedTime = 0f;
        float duration = 3f;
        Vector3 startPosition = EnemyChild.transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, yTransform, startPosition.z);

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration; // Calculate the interpolation factor
            EnemyChild.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }


    }

}
