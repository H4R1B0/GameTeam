using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    public float power; //공격력
    public float health; //체력
    public virtual void OnDamage(float damage)
    {
        health -= damage;
    }
}
