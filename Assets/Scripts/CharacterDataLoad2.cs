using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataLoad2 : MonoBehaviour
{
    public string dataPath;
    [SerializeField]
    public List<Dictionary<string, object>> data;
    public GameObject character;


    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        GameObject go = Instantiate(character);
        data = CSVReader.Read(dataPath);
        go.GetComponent<Character>().characterName = data[0]["Name"].ToString();
        go.GetComponent<Character>().hp = float.Parse(data[0]["HP"].ToString());
        go.GetComponent<Character>().mp = float.Parse(data[0]["MP"].ToString());
        go.GetComponent<Character>().ad = float.Parse(data[0]["AD"].ToString());
        go.GetComponent<Character>().asp = float.Parse(data[0]["AS"].ToString());
        go.GetComponent<Character>().aDef = float.Parse(data[0]["ADEF"].ToString());
        go.GetComponent<Character>().mDef = float.Parse(data[0]["MDEF"].ToString());
        go.GetComponent<Character>().ms = float.Parse(data[0]["MS"].ToString());
        go.GetComponent<Character>().arg = float.Parse(data[0]["RANGE"].ToString());
        go.name = data[0]["Name"].ToString();

    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int rnd = Random.Range(0, data.Count);

            GameObject go = Instantiate(character);
            go.GetComponent<Character>().characterName = data[rnd]["Name"].ToString();
            go.GetComponent<Character>().hp = float.Parse(data[rnd]["HP"].ToString());
            go.GetComponent<Character>().mp = float.Parse(data[rnd]["MP"].ToString());
            go.GetComponent<Character>().ad = float.Parse(data[rnd]["AD"].ToString());
            go.GetComponent<Character>().asp = float.Parse(data[rnd]["AS"].ToString());
            go.GetComponent<Character>().aDef = float.Parse(data[rnd]["ADEF"].ToString());
            go.GetComponent<Character>().mDef = float.Parse(data[rnd]["MDEF"].ToString());
            go.GetComponent<Character>().ms = float.Parse(data[rnd]["MS"].ToString());
            go.GetComponent<Character>().arg = float.Parse(data[rnd]["RANGE"].ToString());
            go.name = data[rnd]["Name"].ToString();
        }
    }
}
