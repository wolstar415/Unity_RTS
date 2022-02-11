using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Transform targetPos;
    public NavMeshAgent enemyNavAgent;
    public Animator enemyAnimator;

    public float minDist;

    public int enemyHP;
    public float enemyMS;
    public float enemyAS;
    public float enemyStatTime;
    public float enemyAtkRange;

    public GameObject targetPlayer;

    public bool isAttacking;
    public bool isDead;

    public float distance;
    public float deadTime;
    
    public enum ENEMYSTATE
    {
        IDLE = 0,
        RUN,
        WALK,
        ATTACK,
        HIT,
        DEAD
    }


    public ENEMYSTATE enemyState;
    public GameObject[] points;
    public int destPoint = 0;

    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyState = ENEMYSTATE.IDLE;
        enemyNavAgent = GetComponent<NavMeshAgent>();
        enemyNavAgent.autoBraking = false;
        points = GameObject.FindGameObjectsWithTag("PatrolPoint");
        GoNextPoint();
    }

    void GoNextPoint()
    {
        int rnd = Random.Range(0, points.Length);
        enemyNavAgent.isStopped = false;
        enemyNavAgent.SetDestination(points[rnd].transform.position);

    }

    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        if (targetPlayer != null)
        {
            distance = Vector3.Distance(transform.position,targetPlayer.transform.position);
        }
        //enemyAnimator.SetInteger("EnemyState", int(enemyState));





        switch (enemyState)
        {
            case ENEMYSTATE.IDLE:
                enemyAnimator.SetInteger("EnemyState", (int)enemyState);
                enemyNavAgent.isStopped = true;
                
                enemyStatTime +=Time.deltaTime;
                if (enemyStatTime > 2f)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        enemyState = ENEMYSTATE.IDLE;
                    }
                    else
                    {
                        enemyState = ENEMYSTATE.WALK;
                        //enemyNavAgent.isStopped = false;
                        GoNextPoint();
                    }
                    enemyStatTime = 0;
                }
                    break;
            case ENEMYSTATE.RUN:
                enemyAnimator.SetInteger("EnemyState", (int)enemyState);
                if (distance > 10)
                {
                    enemyState = ENEMYSTATE.IDLE;
                    return;

                }
                if (distance > minDist)
                {

                    enemyNavAgent.isStopped = false;
                    enemyNavAgent.SetDestination(targetPlayer.transform.position);


                }
                else
                {
                    
                    enemyState = ENEMYSTATE.ATTACK;

                }
                    break;
            case ENEMYSTATE.WALK:
                enemyAnimator.SetInteger("EnemyState",1);
                enemyStatTime += Time.deltaTime;

                if (enemyStatTime > 6f)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        enemyState = ENEMYSTATE.IDLE;

                    }
                    else
                    {
                        
                        GoNextPoint();
                    }
                    enemyStatTime = 0;
                }
                

                if (enemyNavAgent.remainingDistance <= 0.2f)
                {


                enemyState = ENEMYSTATE.IDLE;
                    
                }
                
                    break;
            case ENEMYSTATE.ATTACK:
                enemyAnimator.SetInteger("EnemyState", (int)enemyState);
                //enemyNavAgent.speed = 0;
                enemyNavAgent.isStopped = true;
                Debug.Log(targetPlayer.gameObject.name);

                transform.LookAt(targetPlayer.transform);
                Vector3 dlr = transform.localRotation.eulerAngles;
                Debug.Log(dlr);
                dlr.x = 0;
                transform.localRotation = Quaternion.Euler(dlr);

                if (distance < minDist)
                {
                    enemyStatTime += Time.deltaTime;
                    if (enemyStatTime > enemyAS)
                    {
                        enemyStatTime = 0;
                        //플레이어 공격!!!!
                        Debug.Log("Enemy Attack!!!!!");

                    }
                }
                else
                {
                    enemyState = ENEMYSTATE.RUN;
                }
                    break;
            case ENEMYSTATE.HIT:
                enemyNavAgent.isStopped = true;
                enemyAnimator.SetInteger("EnemyState", (int)enemyState);
                enemyStatTime += Time.deltaTime;
                if (enemyStatTime > 1.333f)
                {
                    enemyStatTime = 0;
                    enemyState = ENEMYSTATE.ATTACK;

                }
                    break;
            case ENEMYSTATE.DEAD:
                enemyAnimator.SetInteger("EnemyState", (int)enemyState);
                break;
            default:

                break;
        }

    }

    public void DamageByEnemy(int dmg)
    {
        enemyHP -= dmg;
        if (enemyHP <= 0)
        {
            enemyState = ENEMYSTATE.DEAD;
            isDead = true;

            targetPlayer.GetComponent<PlayerScript>().playerStateTime = 0f;
            targetPlayer.GetComponent<PlayerScript>().playerState = PlayerScript.PLAYERSTATE.IDLE;
            targetPlayer.GetComponent<PlayerScript>().isAttacking = false;
            StartCoroutine(DeadProcess(3));
            enemyNavAgent.enabled = false;
            //Destroy(enemyNavAgent);
            //Destroy(gameObject.GetComponent<BoxCollider>());
            gameObject.GetComponent<BoxCollider>().enabled = false;

        }
    }

    IEnumerator DeadProcess(float t)
    {
        yield return new WaitForSeconds(t);
       

        while (deadTime < t)
        {
        
        deadTime += Time.deltaTime;
        
        transform.Translate(0,-1.5f*Time.deltaTime,0);
            yield return new WaitForEndOfFrame();

        }
        Destroy(gameObject);
    }
}
