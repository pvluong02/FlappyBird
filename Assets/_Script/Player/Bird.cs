using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Bird : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Text scoreText;
    
    private bool isFly;
    public int score = 0;
    
    private float rotationSpeed = 8f;
    public float flyForce = 4f;

    public GameObject PipeSpawner;
    public GameObject Message;
    public GameObject GameOver;
    public GameObject ShowScore;

    public Animator anim;
    protected Rigidbody2D rb;

    public CharacterDatabase characterDB;

    public SpriteRenderer playlerSprite;

    private int selectedOption = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.gravityScale = 0;
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        UpdateCharacter(selectedOption);
    }


    private void Update()
    {

        CheckInput();
        isFly = true;
    }

    private void FixedUpdate()
    {
       PlayAnim();
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
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
        ShowScorePanel();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("+1");

        IncreasePoint();


        scoreText.text = score.ToString();
        SoundController.instance.PlaySound("point", 0.5f);
    }

    //ham tang diem
    public int IncreasePoint()
    {
        score += 1;
        return score;
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharactor(selectedOption);
        playlerSprite.sprite = character.characterSprite;
        anim.runtimeAnimatorController = character.controllerRunTime;
    }

    private void ShowScorePanel()
    {
        GameOver.SetActive(true);
    }



    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }


    public void ReloadScene(int ScenceID)
    {
        SceneManager.LoadScene(ScenceID);

    }



    private void PlayAnim()
    {
        anim.SetBool("isFly", isFly);
    }

    
   
}
