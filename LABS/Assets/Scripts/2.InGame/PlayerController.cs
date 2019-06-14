using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    SpriteRenderer sprite;

    float moveSpeed = 6f;
    float moveX = 0;

    [SerializeField]
    float jumpPower = 6f;
    int jumpCount = 0;
    bool isGround = true;

    int health = 3;
    int maxhealth = 3;

    bool isHit = false;
    float hitTime = 0.0f;
    float hitInterval = 2.5f;

    float hitAniTime = 0.0f;
    float hitAniInterval = 0.5f;
    
    [SerializeField]
    Sprite[] hitSprites = new Sprite[2]; // Inspector
    int spriteCount = 0;
    enum eHitSprite
    {
        DEFAULT,
        DAMAGED,
    }

    [SerializeField]
    public Text healthText = null;     // Inspector

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();

        hitAniInterval = hitInterval / 6;
    }
    
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        Hitted();
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
        isHit = true;
    }

    void Hitted()
    {
        if (!isHit) { return; }

        HitAni();

        hitTime += Time.deltaTime;
        if (hitTime >= hitInterval)
        {
            hitTime = 0.0f;

            isHit = false;
        }
    }

    void HitAni()
    {
        hitAniTime += Time.deltaTime;
        if(hitAniTime >= hitAniInterval)
        {
            hitAniTime = 0.0f;

            sprite.sprite = hitSprites[spriteCount++];
            spriteCount %= 2;
        }
    }

    void Heal()
    {
        if (health < maxhealth)
        {
            ++health;
            healthText.text = health.ToString();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HealKit")) { Heal(); Destroy(collision.gameObject); }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hit")) { Hit(); }
    }

    #region IsGround Collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { isGround = true; }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { isGround = false; }
    }
    #endregion
}
