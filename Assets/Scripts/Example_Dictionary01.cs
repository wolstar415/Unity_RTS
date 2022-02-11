using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_Dictionary01 : MonoBehaviour
{
    public Dictionary<int, GameObject> test = new Dictionary<int, GameObject> ();
    public Dictionary<int, float> test2 = new Dictionary<int, float> ();
   

    void AddtoDictionary()
    {
        test.Add(0, transform.gameObject);

    }
    void PrintFromDictonary()
    {
        test.TryGetValue(0,out GameObject result);
        Debug.Log(result);
    }

    void DeleteFromDictionary()
    {
        test.Remove(0);
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
