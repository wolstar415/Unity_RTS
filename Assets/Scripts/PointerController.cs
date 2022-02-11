using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    public Transform player;
    public float minDist = 0.5f;
    public MeshRenderer meshRenderer;
    public MeshRenderer childmeshRenderer;
    public PlayerScript playerScript;


    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        playerScript = GameObject.Find("Player").GetComponentInChildren<PlayerScript>();
    }


    void Update() // 매 프레임마다 실행되는 함수입니다.
    {

        float dist = Vector3.Distance(transform.position, player.position);
        if (dist < minDist)
        {
            //meshRenderer.enabled = false;
            //childmeshRenderer.enabled = false;
            Rendercheck(false);
            //playerScript.playerState = PlayerScript.PLAYERSTATE.IDLE;
        }
        else
        {
            Rendercheck(true);
            //childmeshRenderer.enabled = true;
            //meshRenderer.enabled = true;
        }
    }

    public void Rendercheck(bool a)
    {
        meshRenderer.enabled = a;
        childmeshRenderer.enabled = a;
    }
}
