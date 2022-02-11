using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Example_Regex01 : MonoBehaviour
{
    static string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.?)";
    static string patternSlang = "(개새|씨발|니애|느그애)";
    public string[] names= {"Mr. Herry Hunt", "Ms. Sara Samuels", "Abraham Adams", "Ms. Nicole Norris"};
    public List<string> slanges;

    void Start()  // 처음 시작시 실행되는 함수입니다.
    {

        foreach (string name in names)
        {
            string result = Regex.Replace(name, pattern, String.Empty);
            
            Debug.Log(result);
        }

        for (int i = 0; i < slanges.Count; i++)
        {
            string result = Regex.Replace(slanges[i], patternSlang, "**");
            Debug.Log(result);

        }
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
}
