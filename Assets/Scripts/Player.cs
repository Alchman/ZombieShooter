using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnHealthChange = delegate { };
    public Action OnDeath = delegate { };

    public Bullet bulletPrefab;
    public GameObject shootPosition;

    public float fireRate = 1f;
    public int health = 100;
    public bool isDead = false;

    float nextFire; //через сколько времени можно произвести следующий выстрел

    Animator animator;

    private void Awake()
    {
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
        Instantiate(bulletPrefab, shootPosition.transform.position, transform.rotation);
        nextFire = fireRate;

    }
}
