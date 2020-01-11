//맨 앞에 공격
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public static BasicAttack instance;
    private float speed = 12.0f; // 이동속도
    // Start is called before the first frame update
    void Awake()
    {
        BasicAttack.instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        CheckInScreen();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.GetComponent<Monster>().OnDamage(Player.instance.power);
            //Debug.Log("Player.instance.power" + Player.instance.power);
            Destroy(this.gameObject);
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
