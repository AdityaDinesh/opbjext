using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Camera;

    public float speed = 10.0f;
    public float acceleration = 30.0f;
    public float jumpSpeed = 10.0f;
    public float jumpHeight = 10.0f;

    Vector2 velocity;
    Rigidbody2D rb;
    bool isJumping = false;
    bool stopRunning = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        velocity = rb.velocity;
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);

        this.transform.Translate(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpHeight * 100.0f);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isJumping = false;
        }
    }
}
