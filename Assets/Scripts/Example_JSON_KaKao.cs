using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Example_JSON_KaKao : MonoBehaviour
{
    public TextAsset kakaoData;

    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        string kakaoDataJson = kakaoData.text;
        Debug.Log(kakaoDataJson);


        var jsonData = JSON.Parse(kakaoDataJson);
        Debug.Log(jsonData["bot"]["id"]);
        Debug.Log(jsonData["bot"]["name"]);
        
    }



}
