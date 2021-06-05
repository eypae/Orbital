using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerEnemy : Enemy
{
    public float stopDistance;

    private float attackTime;

    private Animator anim;

    public Transform spitPoint;

    public GameObject spit;

    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            if (Time.time >= attackTime)
            {
               attackTime = Time.time + timeBetweenAttacks;
               anim.SetTrigger("attack");
            }
        }
    }

    public void RangedAttack()
    {
        Vector2 direction = player.position - spitPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        spitPoint.rotation = rotation;
        Instantiate(spit, spitPoint.position, spitPoint.rotation);
    }
}
