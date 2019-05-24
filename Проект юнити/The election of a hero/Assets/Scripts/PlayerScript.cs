using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public GameObject GameOver;
    [SerializeField]
    private int lives = 5;
    public LivesBarL livesbar;
    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 5) lives = value;
            livesbar.Refresh();
            Debug.Log("Refresh");
        }
    }
    public AudioSource Menu;

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
        livesbar = new LivesBarL();
        livesbar = FindObjectOfType<LivesBarL>();
        checkHitDelay = 0;

        //  ps1 = new PauseS();
    }
    private void FixedUpdate()
    {
        if (!De)
        {
            CheckGround();

            if (!block && Input.GetButton("Horizontal")) Run();
        }
    }
    private bool block = false;
    private bool atack = false;
    private bool De = false;
    private void Update()
    {
        if (!De)
        {

            if (Input.GetButton("Fire2"))
            {
                Block();
                block = true;
            }
            else block = false;
            if (!block)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Atack();
                    atack = true;
                }
                else atack = false;
                if (!atack)
                {
                    if (isGrounded) State = CharStage.Idle;
                    if (Input.GetButton("Horizontal")) State = CharStage.Run;
                    if (isGrounded && Input.GetButtonDown("Jump")) Jump();
                }

            }
        }
    }
    //void HitDelay()
    //{
    //    checkHitDelay = 1;
    //    InvokeRepeating("RemoveHitDelay", 2, 0);
    //}

    //void RemoveHitDelay()
    //{
    //    checkHitDelay = 0;
    //}

    //public void isForce(Vector3 poz)
    //{
    //    rigidbody.velocity = Vector3.zero;
    //    Vector3 dir = (transform.position - poz);
    //    rigidbody.AddForce(dir.normalized * ForceValue * 2.5F, ForceMode2D.Impulse);
    //}

    public void Atack()
    {
        State = CharStage.Atack;
    }
    public void AtackR()
    {
        Vector3 at = new Vector3(0.7F, 0.5F, 0);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + at, 0.3F);
        foreach (Collider2D b in colliders)
        {
            EnemyL en = FindObjectOfType<EnemyL>();
            if (en)
            {
                en.ReceiweDamage1();
            }
        }
    }

    public void Block()
    {
        State = CharStage.Block;
    }

    public void ReceiweDamage()
    {

            Lives--;
            Debug.Log(lives + " Player");
            Dead();
            //HitDelay();
 
    }

    private void Dead()
    {
        if (Lives == 0)
        {
            De = true;
            State = CharStage.Dead;
        }

    }
    public void Dead1()
    {
        Time.timeScale = 0;
        Menu.Stop();
        GameOver.SetActive(true);
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
public enum CharStage
{
    Idle,
    Run,
    Jump,
    Atack,
    Block,
    Dead
}