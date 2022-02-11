using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
public class Example_JSON_InUnity03 : MonoBehaviour
{
    [SerializeField]
    public List<PlayerClass> playerList = new List<PlayerClass>();
    public TextAsset jsonText;
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        string jsonData = jsonText.text;
        Debug.Log(jsonData);
        var fromJson = JSON.Parse(jsonData);



        for (int i = 0; i < fromJson.Count; i++)
        {
            PlayerClass player = new PlayerClass();
            player.IDX =int.Parse(fromJson[i]["IDX"]);
            player.Hp = int.Parse(fromJson[i]["Hp"]);
            player.Mp = int.Parse(fromJson[i]["Mp"]);
            player.Ms = float.Parse(fromJson[i]["Ms"]);
            player.Def = int.Parse(fromJson[i]["Def"]);

            playerList.Add(player);
        }


    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
}
