using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : LivingEntity
{
    private float speed = 4.0f; // 이동속도
    
    // Start is called before the first frame update
    void Start()
    {
        power = 10f;
        health = 40f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime*speed);

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().OnDamage(power);
        }
        if (collision.CompareTag("ShortAttack"))
        {
            OnDamage(Player.instance.power);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {            
            Destroy(this.gameObject);
        }
    }
    public override void OnDamage(float damage)
    {
        //Debug.Log("damage" + damage);
        base.OnDamage(damage);
    }
}
