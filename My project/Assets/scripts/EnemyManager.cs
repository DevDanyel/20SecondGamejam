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
    //private Animator animator;

    private float xAxis;
    private Rigidbody2D rb2d;
    private string currAnim;
    private bool isAttackPressed;
    private bool isAttacking;
    

    [SerializeField]
    private float attackDelay = 0.3f;

    //animation states 
    const string Player_Idle = "idle_1";
    const string Player_Swing = "swing_1";
    const string Player_Walking = "walking";

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start(){
        //ChangeAnimationState(Player_Idle);
        //animator = GetComponent<Animator>();
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


    void AttackComplete(){
        isAttacking = false;
    }
/*
    void ChangeAnimationState(string newState){
        //stop animation from interupting itself
        if(currAnim == newState) return;

        //play anim
        animator.Play(newState);

        //reassign curranim
        currAnim = newState;
    }*/
}
