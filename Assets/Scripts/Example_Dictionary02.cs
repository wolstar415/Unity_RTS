using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_Dictionary02 : MonoBehaviour
{
    public Dictionary<string, GameObject> test = new Dictionary<string, GameObject>();


    void AddtoDictionary()
    {
        test.Add("DictionaryObject", transform.gameObject);

    }
    void PrintFromDictonary()
    {
        test.TryGetValue("DictionaryObject", out GameObject result);
        Debug.Log(result);
    }

    void DeleteFromDictionary()
    {
        test.Remove("DictionaryObject");
    }
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        AddtoDictionary();

        PrintFromDictonary();

    }


    void Update() // 매 프레임마다 실행되는 함수입니다.
    {

    }
}
