using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamaged
{
    public FixedJoystick joyStick;
    public Animator anim;
    public float hp;
    public float speed;
    
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        joyStick= FindObjectOfType<FixedJoystick>();
    }

    private void Update() {
        Movement();
    }

    private void Movement(){
        Vector2 dir = Vector2.right * joyStick.Horizontal + Vector2.up * joyStick.Vertical * TimeManager.TimeScale;

        anim.SetFloat("MoveX", dir.x* TimeManager.TimeScale);
        anim.SetFloat("MoveY", dir.y* TimeManager.TimeScale);

        rb.velocity = dir *speed * TimeManager.TimeScale;
    }

    public void OnDamaged(float damage){
        hp -= damage;
        if(hp <= 0){
            OnDie();
        }
    }

    private void OnDie(){
        anim.SetBool("Die", true);
        speed = 0;
    }
}
