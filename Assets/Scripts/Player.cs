using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingEntity
{

    // Start is called before the first frame update
    public static Player instance;
    public GameObject basicAttackPrefab;
    public GameObject passAttackPrefab;
    private bool isHalfDamaged = false;

    void Awake()
    {
        Player.instance = this;
    }

    void Start()
    {
        power = 20f;
        health = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void FlatHit()
    {
        Instantiate(basicAttackPrefab, this.transform.position, Quaternion.identity);
    }

    public void LeftToRightSlide()
    {
        //this.transform.position
        Instantiate(passAttackPrefab, this.transform.position, Quaternion.identity);
    }
    public void DonwToUpSlide()
    {
        StartCoroutine("DonwToUpBuffCoroutine");
    }
    public void UpToDownSlide()
    {
        StartCoroutine("UpToDownBuffCoroutine");
    }
    public override void OnDamage(float damage)
    {

        if (isHalfDamaged)
        {
            Debug.Log("damage " + damage / 2);
            base.OnDamage(damage / 2);
        }
        else
        {
            Debug.Log("damage " + damage);
            base.OnDamage(damage);
        }

    }
    IEnumerator UpToDownBuffCoroutine()
    {
        //버프효과 적용
        isHalfDamaged = true;
        Debug.Log("피해 절반 감소 : " + isHalfDamaged);

        //시간 대기(3초)
        yield return new WaitForSeconds(3.0f);

        //버프효과 종료 후 코루틴 함수 끝
        isHalfDamaged = false;
        Debug.Log("피해 절반 감소 : " + isHalfDamaged);
    }
    IEnumerator DonwToUpBuffCoroutine()
    {
        //버프효과 적용
        power += 10.0f;
        Debug.Log("데미지 10 증가");

        //시간 대기(5초)
        yield return new WaitForSeconds(5.0f);

        //버프효과 종료 후 코루틴 함수 끝
        power -= 10.0f;
        Debug.Log("데미지 10 감소");
    }

}
