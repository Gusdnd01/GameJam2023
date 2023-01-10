using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected enum State{
        Idle = 0,
        Move = 1,
        Attack = 2,
        Die = 3,
    }

    protected State state;

    [SerializeField]protected Rigidbody2D _rb;

    protected Vector2 moveDir;
    protected float speed;

    [SerializeField] protected EnemyData enemyData;
    [SerializeField] protected Animator enemyAnimator;

    [SerializeField]protected bool _isDie=false;

    [SerializeField]protected Transform target;

    IEnumerator EnemyCycle(){
        while(!_isDie){
            ChangeAction();
            switch((int)state){
                case 0:
                    IdleAction();
                    print("Idle");
                    break;
                case 1:
                    MoveAction();
                    print("Move");
                    break;
                case 2:
                    print("Attack");
                    AttackAction();
                    yield return new WaitForSeconds(.5f);
                    break;
                case 3:
                    print("DIE");
                    DieAction();
                    break;
            }
            yield return new WaitForSeconds(enemyData.cycleDelay);
        }
    }

    public void ChangeState(int index){
        state = (State)index;
    }

    public void ChangeAction(){
        float distance = EnemyToPlayerDistance();
        if(distance <= enemyData.checkDistance){
            ChangeState(1);
            if(distance <= enemyData.attackDistance){
                ChangeState(2);
            }
            moveDir = (target.position - transform.position).normalized * speed;
        }
        else {
            ChangeState(0);
            moveDir = Vector2.zero;
        }
    }

    protected void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        Reset();
    }
    private void Start() {
        target = GameManager.Instance.PlayerTrm;
        StartCoroutine(EnemyCycle());
    }

    protected abstract void IdleAction();
    protected abstract void MoveAction();
    protected abstract void AttackAction();
    protected abstract void DieAction();

    protected abstract float EnemyToPlayerDistance();

    protected abstract void Reset();
}
