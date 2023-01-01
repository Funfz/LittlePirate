using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private LayerMask platformLayerMask; //ground will be assigned to this variable in inspector

    public GameObject Player;
    Rigidbody2D rb;
    private Vector2 input;
    private Vector2 velocity;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        input.x = UnityEngine.Input.GetAxis("Horizontal");
        input.y = UnityEngine.Input.GetAxis("Vertical");

        rb.velocity = new Vector2 (input.x * speed, rb.velocity.y); //player movement
        Jump();
    }
    private void Jump()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            rb.AddForce(Vector2.up * 7f, ForceMode2D.Impulse); //jump itself
        }
    }
    public bool GroundCheck()
    {
        bool check = Physics2D.Raycast(rb.position, Vector2.down, 1f, platformLayerMask);
        Debug.DrawRay(transform.position, Vector2.down, Color.red, 7f);
        Debug.Log(check);
        return check;
    }
}
