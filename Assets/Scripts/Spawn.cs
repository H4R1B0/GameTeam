using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    const float SPAWNTIME = 0.5f;

    public GameObject monsterPrefab; // 적 프리팹
    private float spawnTime = SPAWNTIME;  // 리스폰 시간 ( 1초에 1번 소환)
    private int spawnMax;
    private int spawnCount;
    // Start is called before the first frame update
    void Start()
    {
        spawnMax = 5;
        spawnCount = 0;
    }

    // Update is called once per frame

    void Update()
    {
        spawnTime -= Time.deltaTime;  // 리스폰 시간을 깍음.
        
        for (int i = spawnCount; i < spawnMax; i++)
        {
            if (spawnTime < 0)  // 리스폰 시간이 0이 되었는지 검사
            {
                GameObject monster= Instantiate(monsterPrefab, this.transform.position, Quaternion.identity); // 생성

                spawnTime = SPAWNTIME;   // 리스폰시간 초기화
                spawnCount++;
            }
            //Debug.Log(this.transform.position.x);
        }
        if (GameObject.FindGameObjectWithTag("Monster") == null)
        {
            spawnCount = 0;
            //spawnMax *= Mathf.RoundToInt(spawnMax * 1.8f);
        }

    }
    Vector3 CalPos(Vector3 pos,float X)
    {
        pos.x += X;
        return pos;
    }
    //IEnumerator CreateMonster()    {    }
}
