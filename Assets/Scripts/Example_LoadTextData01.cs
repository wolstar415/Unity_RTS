using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_LoadTextData01 : MonoBehaviour
{
    public TextAsset textAsset;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        textAsset = Resources.Load("TestTextData") as TextAsset;
        Debug.Log(textAsset);

    }


    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
}
