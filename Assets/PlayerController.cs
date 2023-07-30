using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D myBody;
    public Animator myAnim;
    public GameObject GameManager;
    public UIManager UIManager;
    public Fade Fade;
    public PointSystem pSystem;
    public GameObject player;
    public AudioSource aud;

    [Header("Speech Bubble")]
    public GameObject bubble;
    public TMP_Text bubbleText;


    [Header("Jump")]
    public bool isJumping;
    public bool grounded;
    public LayerMask IsGround;
    public bool jumpButtonPressed;
    public float jumpHeight;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.49f, 0.03f);


    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        UIManager = GameManager.GetComponent<UIManager>();
        Fade = GameManager.GetComponent<Fade>();
        pSystem = GameManager.GetComponent<PointSystem>();
        //player.SetActive(false);
        player.GetComponent<SpriteRenderer>().enabled = false;
        bubble.SetActive(false);
        StartCoroutine(startGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, IsGround))
        {
            grounded = true;
        }
        else
            grounded = false;

        jump();

        if (isJumping)
        {
            //myAnim.SetTrigger("IsJump");
            myAnim.SetBool("isJump", true);
            
            
            //isJumping = false;
        }
       
        
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(4f);
        myAnim.SetBool("isStart", true);
        player.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        bubble.SetActive(true);
        yield return new WaitForSeconds(5f);
        bubble.SetActive(false);

    }

    private void jump()
    {

        if (grounded)
        {
            isJumping = false;
            myAnim.SetBool("isJump", false);
            

        }



        if (jumpButtonPressed && grounded)
        {
            //jumpButtonPressed = false;
            isJumping = true;
            aud.Play();
            myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
        }
        else if(jumpButtonPressed && !grounded)
        {
            jumpButtonPressed = false;
        }
       
    }

    public void jumpPressed()
    {
        jumpButtonPressed = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Enemy"))
        {
            pSystem.start = false;
            UIManager.GameOver();
            myAnim.SetTrigger("isDead");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Johor"))
        {
            bubble.SetActive(true);
            bubbleText.text = "So this is Johor huh..";
            Destroy(col.gameObject);
            StartCoroutine(clearBubble());
        }else if (col.gameObject.CompareTag("Melaka"))
        {
            bubble.SetActive(true);
            bubbleText.text = "Melaka looks so cool in person";
            Destroy(col.gameObject);
            StartCoroutine(clearBubble());
        }
        else if (col.gameObject.CompareTag("N9"))
        {
            bubble.SetActive(true);
            bubbleText.text = "Negeri Sembilan...";
            Destroy(col.gameObject);
            StartCoroutine(clearBubble());
        }
        else if (col.gameObject.CompareTag("Pahang"))
        {
            bubble.SetActive(true);
            bubbleText.text = "What a state, Pahang";
            Destroy(col.gameObject);
            StartCoroutine(clearBubble());
        }
        else if (col.gameObject.CompareTag("Kelantan"))
        {
            bubble.SetActive(true);
            bubbleText.text = "Kelantan sure looks cool";
            Destroy(col.gameObject);
            StartCoroutine(clearBubble());
        }
        else if (col.gameObject.CompareTag("Perak"))
        {
            bubble.SetActive(true);
            bubbleText.text = "We're in Perak now";
            Destroy(col.gameObject);
            StartCoroutine(clearBubble());
        }
        else if (col.gameObject.CompareTag("Penang"))
        {
            bubble.SetActive(true);
            bubbleText.text = "No way! Penang";
            Destroy(col.gameObject);
            StartCoroutine(clearBubble());
        }
        else if (col.gameObject.CompareTag("Kedah"))
        {
            bubble.SetActive(true);
            bubbleText.text = "This must be Kedah";
            Destroy(col.gameObject);
            StartCoroutine(clearBubble());
        }
        else if (col.gameObject.CompareTag("Perlis"))
        {
            bubble.SetActive(true);
            bubbleText.text = "And this must be Perlis";
            Destroy(col.gameObject);
            StartCoroutine(clearBubble());
        }
        else if (col.gameObject.CompareTag("Sarawak"))
        {
            bubble.SetActive(true);
            bubbleText.text = "How did I end up in Sarawak";
            Destroy(col.gameObject);
            StartCoroutine(clearBubble());
        }
        else if (col.gameObject.CompareTag("Sabah"))
        {
            bubble.SetActive(true);
            bubbleText.text = "This must be Sabah then";
            Destroy(col.gameObject);
            StartCoroutine(clearBubble());
        }
    }

    IEnumerator clearBubble()
    {
        yield return new WaitForSeconds(5f);
        bubble.SetActive(false);
    }
    
}
