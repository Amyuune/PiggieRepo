﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;

    public GameObject CollisionSound;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(CollisionSound, transform.position, Quaternion.identity);

            Instantiate(effect, transform.position, Quaternion.identity);

            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);
        }
    }
}
