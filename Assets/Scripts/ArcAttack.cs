using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcAttack : MonoBehaviour
{
    private GameObject[] monsters;
    private Transform Target;
    private float firingAngle = 45.0f;
    private float gravity = 9.8f;
    public Transform Projectile;
    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        StartCoroutine(SimulateProjectile());
    }

    //몬스터중 무작위 타겟팅, 위치고정에 따라가지 않음.
    private Transform FindTarget()
    {
        monsters = GameObject.FindGameObjectsWithTag("Monster");
        int rand = Random.Range(1, monsters.Length);
        Debug.Log(monsters.Length+" 타겟팅 " + rand);
        return monsters[rand].transform;
    }

    IEnumerator SimulateProjectile()
    {
        //1.5초 딜레이, 타겟팅
        yield return new WaitForSeconds(1.5f);
        Target = FindTarget();

        // Move projectile to the position of throwing object + add some offset if needed.
        //Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // 목표까지 거리
        float target_Distance = Vector3.Distance(Projectile.position, Target.position);

        // 물체까지 필요한 속도 계산
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
        //Debug.Log(projectile_Velocity);

        // x축, y축 속도 계산
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
        //Debug.Log(Vx+", "+Vy);

        // 날아가는 시간
        float flightDuration = target_Distance / Vx;
        Debug.Log(flightDuration);

        // Rotate projectile to face the target.
        //Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

        float elapse_time = 0;
        //Debug.Log(this.transform.position.z);
        while (elapse_time < flightDuration)
        {
            Projectile.transform.Translate(Vx * Time.deltaTime, (Vy - (gravity * elapse_time)) * Time.deltaTime, 0);
            //Debug.Log(this.transform.position.z);
            elapse_time += Time.deltaTime;

            yield return null;
        }
    }
}