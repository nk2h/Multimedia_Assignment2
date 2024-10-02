using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class HeroScript : MonoBehaviour
{
    //Game Objects
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    //Display
    public TextMeshProUGUI fuelCollectedText;
    public TextMeshProUGUI heroLivesText;
    public TextMeshProUGUI distanceText;
    public static float distance;
    public static float fuelCollected;

    //Player's Movement 
    public float jumpForce = 7.0f;
    public int movementSpeed = 7;
    private bool onGround = false;
    public static bool facingRight = true;
    public static float moveDirection;
    private bool isJumping = false;
    private float heroHealth;

    //Audio
    public AudioClip gameOver;
    public AudioClip jump;
    public AudioClip run;
    public AudioClip lazer;
    public AudioClip fuelCanCollected;


    private void Awake()
    {      
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        anim.SetInteger("Transition", 1); //Stand
        rb.freezeRotation = true;
        heroHealth = 100f;
        fuelCollected = 0f;
        fuelCollectedText.text = fuelCollected.ToString();
        heroLivesText.text = "Hero Lives: " + heroHealth.ToString();

    }
    void Update()
    {
        ProcessInputs();
        Animate();

        distance = ((int)transform.position.x);
        distanceText.text = distance.ToString();
    }
    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("up"))
        {
            isJumping = true; 
        }
    }
    private void Animate()
    {
        //print("MoveDirection: " + moveDirection + ", Facing Right: " + facingRight);
        if (moveDirection > 0 && !facingRight)
        {
            //print("Condition 1");
            flipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            //print("Condition 2");
            flipCharacter();
        }
    }
    private void flipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    private void Move()
    {
        anim.SetInteger("Transition", 2); //Run
        rb.velocity = new Vector2(moveDirection * movementSpeed, rb.velocity.y);

        if (isJumping && onGround == true)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            onGround = false;
            //anim.SetTrigger("Jump");
            GetComponent<AudioSource>().PlayOneShot(jump, 1.0F);
            anim.SetInteger("Transition", 3); //Jump            
        }
        isJumping = false;
    }
    void FixedUpdate()
    {
        Move();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("Hero has touched ground");
        
        onGround = true;
        GetComponent<AudioSource>().PlayOneShot(run, 3.0F);
        
        if (collision.gameObject.name == "LazersParent" || collision.gameObject.name == "LazersChild")
        {
            GetComponent<AudioSource>().PlayOneShot(lazer,1.5F);
            heroHealth -= 0.5f;
            if (heroHealth <= 0f)
            {
                HeroDied();
            }
            heroLivesText.text = "Hero Lives: " + heroHealth.ToString();
        }     
    }
    public void ImproveHealth(float healthAdd)
    {
        heroHealth += healthAdd;
        fuelCollected ++;
        GetComponent<AudioSource>().PlayOneShot(fuelCanCollected,3.0F);
        if (heroHealth > 100f) heroHealth = 100f;

        fuelCollectedText.text = fuelCollected.ToString();
        heroLivesText.text = "Hero Lives: " + heroHealth.ToString();
    }
    public void ReduceHealth(float healthReduce)
    {
        heroHealth -= healthReduce;
        heroLivesText.text = "Hero Lives: " + heroHealth.ToString();
        if(heroHealth <= 0f)
        {
            //anim.SetTrigger("died");
            HeroDied();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //GetComponent<AudioSource>().PlayOneShot(run, 3.0F);
        if (collision.gameObject.name == "LazersParent" || collision.gameObject.name == "LazersChild")
        {
            GetComponent<AudioSource>().PlayOneShot(lazer);
            heroHealth -= 0.5f;
            heroLivesText.text = "Hero Lives: " + heroHealth.ToString();
            if (heroHealth <= 0f)
            {
                HeroDied();
            }
        }
    }
    IEnumerator GameOverAfterWait()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void HeroDied() {
        GetComponent<AudioSource>().PlayOneShot(gameOver, 3.0F);
        anim.SetInteger("Transition", 4);
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(GameOverAfterWait());
    }
}
