using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
    protected override void Reset()
    {
        speed = enemyData.speed;
    }

    protected override void AttackAction()
    {
        //애니메이션 추가
        Collider2D cols = Physics2D.OverlapCircle(transform.position, 2f, LayerMask.GetMask("Player"));
        if (cols != null)
        {
            cols.GetComponent<IDamaged>().OnDamaged(5f);
        }

        speed = .1f;
        _rb.velocity = moveDir;
    }

    protected override void DieAction()
    {
        moveDir = Vector2.zero;
        _rb.velocity = moveDir;
        speed = 0;
    }

    protected override float EnemyToPlayerDistance()
    {
        float distance;
        print(target);
        if (target != null)
        {

            distance = Vector2.Distance(transform.position, target.position);
        }
        else{
            distance = 100;
        }
        return distance;
    }

    protected override void IdleAction()
    {
        moveDir = Vector2.zero;
        speed = 0;
        enemyAnimator.SetFloat("MoveX", 0);
        enemyAnimator.SetFloat("MoveY", 0);
    }

    protected override void MoveAction()
    {
        speed = 3f;
        enemyAnimator.SetFloat("MoveX", moveDir.x);
        enemyAnimator.SetFloat("MoveY", moveDir.y);
        _rb.velocity = moveDir;
    }
}
