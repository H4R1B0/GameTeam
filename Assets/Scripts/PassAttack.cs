//attackCount횟수만큼 관통을 하며 플레이어 공격력의 1.5배만큼 2번 공격
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassAttack : MonoBehaviour
{

    public static PassAttack instance;
    private float speed = 12.0f; // 이동속도
    public int attackCount = 4;
    // Start is called before the first frame update
    void Awake()
    {
        PassAttack.instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (attackCount == 0)
        {
            Destroy(this.gameObject);
        }
        CheckInScreen();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            attackCount--;
            collision.GetComponent<Monster>().OnDamage(Player.instance.power * 1.5f);
            collision.GetComponent<Monster>().OnDamage(Player.instance.power * 1.5f);
        }
    }

    //카메라 벗어나면 삭제
    private void CheckInScreen()
    {
        Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        if (targetScreenPos.x > Screen.width || targetScreenPos.x < 0 || targetScreenPos.y > Screen.height || targetScreenPos.y < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
