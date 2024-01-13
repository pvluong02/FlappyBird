using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Bird : MonoBehaviour
{
    public Text scoreText;

    private bool isFly;
    private int score = 0;

    public float flyForce = 4f;

    public GameObject PipeSpawner;
    public GameObject Message;
    public GameObject GameOver;
    protected Animator anim;
    protected Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.gravityScale = 0;
    }


    private void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        PlayAnim();
    }

    private void Move()
    {
        rb.velocity = new Vector2(rb.velocity.x, flyForce);
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            SoundController.instance.PlaySound("wing", 0.5f);
            rb.gravityScale = 1;
            PipeSpawner.GetComponent<PipeSpawner>().enableSpawnerPipe = true;
            Message.GetComponent<SpriteRenderer>().enabled = false;
            Move();
            isFly = true;
        }
        else
        { 
            isFly = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        Debug.Log("die");
        SoundController.instance.PlaySound("die", 0.5f);
        Time.timeScale = 0;
        GameOver.SetActive(true);
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        score+= 1;
        scoreText.text = score.ToString();
        SoundController.instance.PlaySound("point", 0.5f);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Main");
    }



    private void PlayAnim()
    {
        anim.SetBool("isFly", isFly);
    }

    
}
