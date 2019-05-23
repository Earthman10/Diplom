using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL : MonoBehaviour {

    
    public GameObject Win;
    public LoadScene ls;
    [SerializeField]
    private int lives = 5;
    public LivesBarE livesbar;
    public int Lives_b
    {
        get { return lives; }
        set
        {
            if (value < 5) lives = value;
            livesbar.Refresh2();
            Debug.Log("Refresh");
            Debug.Log(lives);
        }
    }

    //private LoadScene ls;
    // PauseS ps1;
    [SerializeField]
    private float ForceValue = 8.0f;
    //[SerializeField]
    public float speed = 3F;
    [SerializeField]
    private float jumpForce = 15.0F;

    private bool isGrounded = false;

    private CharStage State
    {
        get { return (CharStage)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private int checkHitDelay;

    private void Awake()
    {
        //ls = new LoadScene();

        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        //ls = new LoadScene();
        livesbar = new LivesBarE();
        livesbar = FindObjectOfType<LivesBarE>();
        checkHitDelay = 0;

        //  ps1 = new PauseS();
    }
    private void FixedUpdate()
    {

    }
    private bool block = false;
    private bool atack = false;
    private void Update()
    {
       
    }
    void HitDelay()
    {
        checkHitDelay = 1;
        InvokeRepeating("RemoveHitDelay", 2, 0);
    }

    void RemoveHitDelay()
    {
        checkHitDelay = 0;
    }

    public void isForce(Vector3 poz)
    {
        rigidbody.velocity = Vector3.zero;
        Vector3 dir = (transform.position - poz);
        rigidbody.AddForce(dir.normalized * ForceValue * 2.5F, ForceMode2D.Impulse);
    }

    public void Atack()
    {
        Vector3 at = new Vector3(0.7F, 0.5F, 0);
        State = CharStage.Atack;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position - at, 0.1F);
        foreach (Collider2D b in colliders)
        {
            PlayerScript en = FindObjectOfType<PlayerScript>();
            if (en)
            {
                en.ReceiweDamage();
            }
        }
    }

    public void Block()
    {
        State = CharStage.Block;
    }

    public void ReceiweDamage1()
    {
        if (checkHitDelay == 0)
        {
            Lives_b--;
            Debug.Log(lives);
            Dead();
            HitDelay();
        }
    }

    private void Dead()
    {
        if (Lives_b == 0)
        {
            State = CharStage.Dead;
          
            
        }

    }
    private void Dead1()
    {
 
            Time.timeScale = 0;
            Win.SetActive(true);


    }

    private void Run()
    {


        //float h = Input.GetAxisRaw("Horizontal");


        // Vector2 tempVect = new Vector2(h,0);
        //tempVect = tempVect.normalized * transform.right* speed * Time.fixedDeltaTime;
        //rigidbody.MovePosition((Vector2)transform.position + tempVect);
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.Translate(direction.x * speed * Time.deltaTime, 0, 0);
        // transform.position = Vector3.Lerp(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;
        // sprite.flipX = tempVect.x < 0.0F;

    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        State = CharStage.Jump;
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1F);

        isGrounded = colliders.Length > 1;

    }
}
public enum CharStage1
{
    Idle,
    Run,
    Jump,
    Atack,
    Block,
    Dead
}

