using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] float health = 100;

    [Header("Death")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 0.25f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0f, 1f)] float deathSFXVolume = 0.3f;

    [Header("Attack")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] AudioClip shotSFX;
    [SerializeField] [Range(0f, 1f)] float shotSFXVolume = 0.2f;


    [Header("Projectile")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 5f;

    // Use this for initialization
    void Start()
    {
        ResetShotCounter();
    }

    private void ResetShotCounter()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);

    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (!damageDealer) return;
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        var explosion = Instantiate(
            deathVFX,
            transform.position,
            Quaternion.identity
            );
        Destroy(explosion, explosionDuration);

        AudioSource.PlayClipAtPoint(
            deathSFX,
            Camera.main.transform.position,
            deathSFXVolume
            );

        Destroy(gameObject);
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            ResetShotCounter();
        }
    }

    private void Fire()
    {
        var newProjectile = Instantiate(
                projectilePrefab,
                transform.position,
                Quaternion.identity
            );
        Rigidbody2D rigidBody2D = newProjectile.GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = new Vector2(0, -projectileSpeed);

        AudioSource.PlayClipAtPoint(
            shotSFX,
            Camera.main.transform.position,
            shotSFXVolume
            );
    }

}
