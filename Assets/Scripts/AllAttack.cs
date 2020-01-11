using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAttack : MonoBehaviour
{
    private GameObject[] monsters;

    void Awake()
    {
        
    }

    void Start()
    {
        StartCoroutine(Scan());
    }

    IEnumerator Scan()
    {
        //1.5초 딜레이, 타겟팅
        yield return new WaitForSeconds(1.5f);

        monsters = GameObject.FindGameObjectsWithTag("Monster");

        for(int i = 0; i < monsters.Length; i++)
        {
            //이펙트생성 코드 나중에 추가
            monsters[i].GetComponent<Monster>().OnDamage(Player.instance.power);
        }
    }
}