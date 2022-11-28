using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        //instantiate the rb to find the rb on playrr automatically
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");

        moveInput.Normalize();

        rb.velocity = moveInput * moveSpeed;
    }
}
