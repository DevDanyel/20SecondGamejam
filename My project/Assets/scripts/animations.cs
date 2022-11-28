using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 0.3f;

    private Animator animator;

    private float xAxis;
    private Rigidbody2D rb2d;
    private string currAnim;
    private bool isAttackPressed;
    private bool isattacking;

    [SerializeField]
    private float attackDelay = 0.3f;

    //animation states 
    const string Player_Idle = "idle_1";
    const string Player_Swing = "swing_1";
    const string Player_Walking = "walking";

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update(){
        xAxis = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            isAttackPressed = true;
        }
    }

    void FixedUpdate(){
        Vector2 vel = new Vector2(0, rb2d.velocity.y);

        if(xAxis < 0){
            vel.x = -walkSpeed;
            transform.localScale = new Vector2(-1, 1);
        }else if(xAxis > 0 ){
            vel.x = walkSpeed;
            transform.localScale = new Vector2(1, 1); 
        }else{
            vel.x = 0;
        }
    }
   
}
