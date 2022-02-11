using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unitychaneffect : MonoBehaviour
{
    public GameObject hitEffectL;
    public GameObject hitEffectR;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }

    public void PlayHitEffectL()
    {

        hitEffectL.GetComponent<ParticleSystem>().Play();
    }
    public void PlayHitEffectR()
    {

        hitEffectR.GetComponent<ParticleSystem>().Play();
    }
}
