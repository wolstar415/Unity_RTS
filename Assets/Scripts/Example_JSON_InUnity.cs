using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.js



public class Example_JSON_InUnity : MonoBehaviour
{
    public MyClass myObject = new MyClass();
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        myObject.level = 1;
        myObject.timeElapsed = 47.5f;
        myObject.playerName = "MyPlayer01";

        string jsonData = JsonUtility.ToJson(myObject);

        Debug.Log(jsonData);

        PlayerPrefs.SetString("PlayerData",jsonData);
        Debug.Log(PlayerPrefs.GetString("PlayerData"));

    }


    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
}
