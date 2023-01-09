using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joyStick;
    public Animator anim;
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Movement();
    }

    private void Movement(){
        Vector2 dir = Vector2.right * joyStick.Horizontal + Vector2.up * joyStick.Vertical;

        anim.SetFloat("MoveX", dir.x);
        anim.SetFloat("MoveY", dir.y);

        rb.velocity = dir * 5;
    }
}
