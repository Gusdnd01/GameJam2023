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

    SpriteRenderer spriteRenderer;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        joyStick= FindObjectOfType<FixedJoystick>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        anim.SetTrigger("Hit");
        StartCoroutine(HitEffect());
        if(hp <= 0){
            OnDie();
        }
    }
    IEnumerator HitEffect(){
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = Color.white;
    }

    private void OnDie(){
        StartCoroutine(Die());
        speed = 0;
    }

    IEnumerator Die(){
        GameManager.Instance.enemySpawner.parts.Play();
        TimeManager.TimeScale = 0;
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
        GameUI.Instance.MoveDown();
    }
}
