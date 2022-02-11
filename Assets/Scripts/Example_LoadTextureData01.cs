using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Example_LoadTextureData01 : MonoBehaviour
{
    public GameObject box;
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        box.GetComponent<Renderer>().material.mainTexture =Resources.Load<Texture>("box-texture-pbr-01");

    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
}
