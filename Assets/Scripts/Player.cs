using System;
using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{
    // The force which is added when the player jumps
    // This can be changed in the Inspector window
    public Vector2 jumpForce = new Vector2(0, 300);
    public bool isDead = false;
    public bool alive = true;
    public int points= 0;
    public int score;
    public float volume = 1.0f;
    void Start()
    {
        volume = PlayerPrefs.GetFloat("Audio Volume", volume);
        AudioListener.volume = volume;
        InvokeRepeating("AddOne", 4f, 6f);
    }

    void AddOne()
    {
        points += 1;
    }

    // Update is called once per frame
    void Update()
    {

        score += points;
        PlayerPrefs.SetInt("Player Score", score);
        // Jump
        if (Input.GetKeyUp("space") || (Input.GetMouseButtonDown(0)))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
        }

        // Die by being off screen
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            Die();
        }
    }

    // Die by collision
    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }

    void Die()
    {
        alive = false;
        isDead = true;
    }

    void OnGUI()
    {
        if (alive == true)
        {
            GUI.color = Color.black;
            GUILayout.Label(" Score: " + score.ToString());
        }
        if (isDead==true)
        {
            Application.LoadLevel("DeathScene");
            isDead = false;
        }
    }


    

}