using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    SpriteRenderer sprite;

    [SerializeField]
    float moveSpeed = 6f;
    float moveX = 0;

    [SerializeField]
    float jumpPower = 6f;
    int jumpCount = 0;
    bool isGround = true;

    int health = 3;
    GameObject hp;

    bool isHit = false;
    float hitTime = 0.0f;
    [SerializeField]
    float hitInterval = 2.5f;

    float hitAniTime = 0.0f;
    [SerializeField]
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
    float healCoolTime = 0;
    float healCoolInterval = 1.0f;
    bool isHeal = true;

    ScoreManager scoreMgr;

    void Start()
    {
        Init();
        ReSet();
    }
    
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        Hitted();

        if (!isHeal)
        {
            healCoolTime += Time.deltaTime;
            if (healCoolTime >= healCoolInterval)
            {
                isHeal = true;
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

        rigid2D.velocity = new Vector2(0, jumpPower);
        
        ++jumpCount;
    }

    public bool isDead = false;
    void Hit()
    {
        if(isHit) { return; }

        scoreMgr.curEvent = ScoreManager.eEventState.COL;

        hp.transform.GetChild(--health).gameObject.SetActive(false);
        if(health <= 0)
        {
            isDead = true;
        }

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

    public int GetHp()
    {
        return health;
    }

    bool isInit = false;
    public void Init()
    {
        if (isInit) return;

        isInit = true;

        rigid2D = GetComponent<Rigidbody2D>();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();

        hitAniInterval = hitInterval / 6;

        scoreMgr = GameObject.Find("UI").GetComponent<ScoreManager>();

        hp = GameObject.Find("Hp");
    }

    public void ReSet()
    {
        health = 3;
        isDead = false;
        for (int i = 0; i < health; ++i) 
        {
            hp.transform.GetChild(i).gameObject.SetActive(true);
        }
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
