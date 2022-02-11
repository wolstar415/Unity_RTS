using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_JSON_InUnity02 : MonoBehaviour
{
    public MyClass fromJasonObject = new MyClass();
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        string jsonData = PlayerPrefs.GetString("PlayerData");

        fromJasonObject = JsonUtility.FromJson<MyClass>(jsonData);
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
}
