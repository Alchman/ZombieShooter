using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Dictionary<string, string> people = new Dictionary<string, string>(); 

    public float speed = 20f;
    public int damage = 50;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        people.Add("one", "Denis");
        people.Add("two", "Anton");

        bool hasKey = people.ContainsKey("one");
        print(people["one"]);

        people.Remove("two");
    }

    private void OnEnable()
    {
        rb.velocity = -transform.up * speed;
    }

    private void OnBecameInvisible()
    {
        LeanPool.Despawn(gameObject);
    }
}
