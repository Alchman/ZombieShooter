using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 10f;

    public Vector3 targetPosition;

    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        Vector3 zombiePosition = transform.position;
        Vector3 direction = targetPosition - zombiePosition;

        if (direction.magnitude > 1)
        {
            direction = direction.normalized;
        }

        animator.SetFloat("Speed", direction.magnitude);

        rb.velocity = direction * speed;
    }

    void Rotate()
    {
        Vector3 zombiePosition = transform.position;
        Vector3 direction = targetPosition - zombiePosition;

        direction.z = 0;
        transform.up = -direction;
    }

    private void OnDisable() //вызывается, когда объект выключается
    {
        rb.velocity = Vector2.zero;
    }

}
