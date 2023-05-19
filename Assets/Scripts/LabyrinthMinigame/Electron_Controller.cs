using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron_Controller : MonoBehaviour
{
    Rigidbody2D rb;

    float horizontal;
    float vertical;

    [SerializeField]
    float runSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        rb.velocity = rb.velocity.normalized * runSpeed;
    }
}
