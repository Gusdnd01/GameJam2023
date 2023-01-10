using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase, IDamaged
{
    protected override void Reset()
    {
        hp = enemyData.hp;
    }
    public void OnDamaged(float damage)
    {
        hp -= damage;

        if(hp <= 0){
            ChangeState(3);
        }
    }

    protected override void AttackAction()
    {
        //애니메이션 추가
        Collider2D cols = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Player"));
        if(cols!=null){
            cols.GetComponent<IDamaged>().OnDamaged(5f);
        }
        
        moveDir = Vector2.zero;
        _rb.velocity = moveDir;
        
        enemyData.speed = 2f;
    }

    protected override void DieAction()
    {
        moveDir = Vector2.zero;
    }

    protected override float EnemyToPlayerDistance()
    {
        float distance;
        print(target);
        distance = Vector2.Distance(transform.position, target.position);
        return distance;
    }

    protected override void IdleAction()
    {
        moveDir = Vector2.zero;
        enemyAnimator.SetFloat("MoveX", 0);
        enemyAnimator.SetFloat("MoveY", 0);
    }

    protected override void MoveAction()
    {
        enemyAnimator.SetFloat("MoveX", moveDir.x);
        enemyAnimator.SetFloat("MoveY", moveDir.y);
        moveDir = (target.position - transform.position).normalized * enemyData.speed;
        _rb.velocity = moveDir;
        enemyData.speed = 5f;
    }
}
