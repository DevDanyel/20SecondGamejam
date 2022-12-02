using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 1f;

    private Vector2 target;
    private Vector2 position;
    private GameObject player;
    private Animator animator;

    private Rigidbody2D rb2d;
    private string currAnim;
    private bool isAttackPressed;
    private bool isAttacking;
    

    [SerializeField]
    private float attackDelay = 0.3f;

    //animation states 
    const string Player_Idle = "enemyAnimator";
    const string Player_Swing = "swingE";
    const string Player_Walking = "walkE";

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        position = gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position;

    }

    void Update(){
        float step = walkSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        //right left movement



        //if enemy is so close to player swing. 
    }

    void FixedUpdate(){
        Vector2 vel = new Vector2(0, rb2d.velocity.y);

        if(!isAttacking){
            if(rb2d.velocity.magnitude != 0){
                ChangeAnimationState(Player_Walking);
            }else{
                ChangeAnimationState(Player_Idle);
            }
        }

        if(isAttackPressed){
            isAttackPressed = false;

            if(!isAttacking){
                isAttacking = true;
                ChangeAnimationState(Player_Swing);
                //attackDelay = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("AttackComplete", attackDelay);
            }
        }

    }


    void AttackComplete(){
        isAttacking = false;
    }

    void ChangeAnimationState(string newState){
        //stop animation from interupting itself
        if(currAnim == newState) return;

        //play anim
        animator.Play(newState);

        //reassign curranim
        currAnim = newState;
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("hit player");
            isAttackPressed = true;
        }
    }
}
