using Lean.Pool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance
    {
        get
        {
            return instance;
        }
    }


    public int Health
    {
        get
        {
            return health;
        }
    }


    public Action OnHealthChange = delegate { };
    public Action OnDeath = delegate { };

    public Bullet bulletPrefab;
    public GameObject shootPosition;

    public float fireRate = 1f;
    public bool isDead = false;

    [SerializeField] private int health = 100;

    float nextFire; //через сколько времени можно произвести следующий выстрел

    Animator animator;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        animator = GetComponent<Animator>();
    }

    public void UpdateHealth(int amount)
    {
        health += amount;
        OnHealthChange();

        if (health <= 0)
        {
            isDead = true;
            OnDeath();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckFire();
    }

    private void CheckFire()
    {

        if (Input.GetButton("Fire1") && nextFire <= 0)
        {
            Shoot();
        }

        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        //TODO sound
        animator.SetTrigger("Shoot");
        LeanPool.Spawn(bulletPrefab, shootPosition.transform.position, transform.rotation);
        nextFire = fireRate;

    }

    private void OnDestroy()
    {
        if (this == instance)
        {
            instance = null;
        }
    }
}
