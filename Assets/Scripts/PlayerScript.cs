using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public Transform targetPos;
    public Transform enepos;
    public int playerHP;
    [Range(0f, 10f)] 
    public float playerMS;
    [Range(0f, 2f)]
    public float playerAS;
    public float playerStateTime;
    public float attackRange;
    public bool isAttacking = false;
    public int PlayerATK = 30;
    

    public PointerController pointerController;
    public enum PLAYERSTATE
    {
        IDLE = 0,
        RUN,
        ATTACK,
        DEAD
    }

    public PLAYERSTATE playerState;
    Animator playerAnim;


    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        pointerController=GameObject.Find("TargetPos").GetComponent<PointerController>();

        navAgent = GetComponent<NavMeshAgent>();
        playerState = PLAYERSTATE.IDLE;
        //navAgent.SetDestination(targetPos.position);
        playerAnim = GetComponentInChildren<Animator>();
        navAgent.SetDestination(targetPos.position);
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        switch (playerState)
        {
            case PLAYERSTATE.IDLE:
               
                if (isAttacking)
                {

                    playerState = PlayerScript.PLAYERSTATE.ATTACK;
                }
                    navAgent.speed = playerMS;
                break;
            case PLAYERSTATE.RUN:
                if (isAttacking) // 공격런..
                {
                    float enemyDist = Vector3.Distance(transform.position, enepos.position);
                    navAgent.stoppingDistance = 2;
                    if (enemyDist < attackRange)
                    {
                        playerState = PlayerScript.PLAYERSTATE.ATTACK;
                    }
                }
                else //일반런
                {
                    playerStateTime = 0f;
                    isAttacking = false;
                    navAgent.isStopped = false;
                    navAgent.speed = playerMS;
                    if (navAgent.remainingDistance == 0)
                    {
                        //Debug.Log("테스트");
                        //navAgent.stoppingDistance = 2;
                        playerState = PlayerScript.PLAYERSTATE.IDLE;
                    }
                }
                    
                break;
            case PLAYERSTATE.ATTACK:
                if (isAttacking)
                {

                    
                    enepos.GetComponent<EnemyController>().targetPlayer = gameObject;
                    enepos.GetComponent<EnemyController>().isAttacking = true;
                    enepos.GetComponent<EnemyController>().enemyState = EnemyController.ENEMYSTATE.HIT;

                    transform.LookAt(enepos);
                    Vector3 dir = transform.localRotation.eulerAngles;
                    dir.x = 0;
                    //dir.Normalize();
                    // transform.LookAt(dir);
                    transform.localRotation = Quaternion.Euler(dir);


                    navAgent.speed = 0f;
                    navAgent.isStopped = true;
                    pointerController.Rendercheck(false);
                    targetPos.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                    //navAgent.SetDestination(targetPos.position);
                    playerStateTime += Time.deltaTime;
                    if (playerStateTime > 1.6f)
                    {
                        playerStateTime = 0f;
                        //isAttacking = false;
                        enepos.gameObject.GetComponent<EnemyController>().DamageByEnemy(PlayerATK);
                        playerState = PLAYERSTATE.IDLE;
                    }

                    if (enepos.GetComponent<EnemyController>().enemyState == EnemyController.ENEMYSTATE.DEAD)

                    {
                        playerStateTime = 0f;
                        playerState = PlayerScript.PLAYERSTATE.IDLE;
                        isAttacking = false;
                        return;
                    }
                }
                break;
            case PLAYERSTATE.DEAD:
                break;
            default:
                break;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isAttacking = false;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                targetPos.position = hit.point;
            navAgent.SetDestination(targetPos.position);
                navAgent.stoppingDistance = 0;
                playerState = PlayerScript.PLAYERSTATE.RUN;
                //return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

               // Debug.Log(hit.collider.gameObject.name);
                switch (hit.collider.tag)
                {
                    case "Enemy":
                        enepos = hit.collider.transform;
                        //transform.LookAt(hit.collider.gameObject.transform);
                        //Vector3 dir = transform.localRotation.eulerAngles;
                        //Debug.Log("1 ::" + dir);
                        //dir.x = 0;
                        //Debug.Log("2 ::" + dir);
                        ////dir.Normalize();
                        //// transform.LookAt(dir);
                        //transform.localRotation = Quaternion.Euler(dir);
                        //transform.localEulerAngles = dir;
                        float enemyDist = Vector3.Distance(transform.position, hit.collider.transform.position);
                        //gameObject.transform.LookAt(hit.collider.gameObject.transform);
                        
                        navAgent.stoppingDistance = 2;
                        isAttacking = true;
                        if (enemyDist < attackRange)
                        {
                            
                            playerState = PlayerScript.PLAYERSTATE.ATTACK;
                        }
                        else
                        {
                            //targetPos = hit.collider.transform;
                            
                            targetPos.position = new Vector3(enepos.position.x, enepos.position.y, enepos.position.z);
                            playerState = PlayerScript.PLAYERSTATE.RUN;
                            navAgent.SetDestination(enepos.position);
                        }
                            break;

                    default:
                        break;
                }


                
            }


        }




        playerAnim.SetInteger("PLAYERSTATE", (int)playerState);

    }



}
