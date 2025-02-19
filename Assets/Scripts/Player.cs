﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;

  

    public GameObject effect;
    public Text healthDisplay;

    public GameObject gameOver;
    public GameObject MoveSound;
    public GameObject DestroyScore;

    private void Update()
    { //Cloudy's Health//

        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Instantiate(MoveSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);

            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            Instantiate(MoveSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);

        }
        if (health <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
            Destroy(DestroyScore);
        }

    }
}
