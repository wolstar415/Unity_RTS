using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataLoad : MonoBehaviour
{
    public string dataPath;
    public List<Dictionary<string, object>> data;
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {

        data = CSVReader.Read(dataPath);
        Debug.Log("==== 불러온 데이터 =======");
        Debug.Log("No ::: " + data[0]["No"]);
        Debug.Log("Name ::: " + data[0][ "Name"]);
        Debug.Log("Hp ::: " + data[0][ "Hp"]);
        Debug.Log("Count ::: " + data[0][ "Count"]);

    }


}
