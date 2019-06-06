using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;

    float moveSpeed = 6f;
    float moveX = 0;

    float jumpPower = 6f;
    int jumpCount = 0;
    bool isGround = true;

    [SerializeField]
    int health = 3;
    [SerializeField]
    int maxhealth = 3;
    bool isHit = false;
    float hitTime = 0.0f;
    float hitInterval = 1.0f;
    Material mater;
    Color defaultColor;         // Prototype Var

    public Text healthText;     // Inspector
    public Text ScoreText;      // Inspector

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        mater = GetComponent<MeshRenderer>().material;
        defaultColor = mater.color; // Prototype Var
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(isHit)
        {
            hitTime += Time.deltaTime;
            if(hitTime >= hitInterval)
            {
                hitTime = 0.0f;

                mater.color = defaultColor; // Prototype Var
                isHit = false; 
            }
        }
    }

    void Move()
    {
        int moveLeft = 0;
        int moveRight = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  { moveLeft = -1; }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { moveRight = 1; }

        moveX = (moveRight + moveLeft) * moveSpeed;
        transform.Translate(moveX * Time.deltaTime, 0,0);
    }

    void Jump()
    {
        if(isGround) { jumpCount = 0; }

        if (jumpCount == 2) { return; }
        
        rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        ++jumpCount;
    }

    void Hit()
    {
        if(isHit) { return; }

        --health;
        healthText.text = health.ToString();
        mater.color = Color.blue;
        isHit = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))   { isGround = true; }
        
        if (collision.gameObject.CompareTag("HealKit"))
        {
            if (health < maxhealth)
            {
                ++health;
                healthText.text = health.ToString();
            }
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hit"))      { Hit(); }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))   { isGround = false; }
    }

}
