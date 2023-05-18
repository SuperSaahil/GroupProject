using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 9;
    public float MoveDirection;
    public Rigidbody2D rb;
    public bool isGrounded = true;
    public int Damage;
    public bool RegPunch = false;
    public bool isReg = false;
    public bool canReg = true;
    public bool ReachPunch = false;
    public bool canReach = true;
    Animator anim;
    ArmCollider Arm;
    public int reachDMG = 5;
    public bool isReached = false;
    private bool facingRight = true;
    public Transform shootPos;
    public GameObject bulletPrefab;
    public int playerHP = 6;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Arm = GameObject.FindGameObjectWithTag("PlayerArm").GetComponent<ArmCollider>();


    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputSystem();
        BasicPunch();
        ReachATK();
        Jumping();
        Shooting();
        HorizontalAnimation();
        WaveAnimation();
    }
    private void FixedUpdate()
    {
        Move();
    }


    void PlayerInputSystem()
    {
        MoveDirection = Input.GetAxis("Horizontal");
        //  anim.SetTrigger("PlayerA");

    }

    void HorizontalAnimation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetTrigger("PlayerA");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetTrigger("PlayerA");
        }
    }
    void WaveAnimation()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Runner.Wave");
        }
    }
    void Jumping()
        {
            if (Input.GetKey(KeyCode.Space) && isGrounded == true)
            {
                rb.velocity = new Vector3(0, 9, 0);
                isGrounded = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "platform")
            {
                isGrounded = true;
            }
            else collision.gameObject.CompareTag("platform");
            {
                transform.parent = collision.transform;
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            transform.parent = null;
        }

        void PlayerFlip()
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
        private void Move()
        {


            //animate
            if (MoveDirection > 0 && !facingRight)
            {
                PlayerFlip();
            }
            else if (MoveDirection < 0 && facingRight)
            {
                PlayerFlip();
            }
            //Move
            rb.velocity = new Vector2(MoveDirection * speed, rb.velocity.y);
        }


        void BasicPunch()
        {
            if (Input.GetKey(KeyCode.E) && canReg == true)
            {
                canReg = false;
                isReg = true;
                anim.SetTrigger("AttackStart");
                StartCoroutine(punchCD());
            }

        }
        void ReachATK()
        {
            if (Input.GetKey(KeyCode.R) && canReach == true)
            {
                canReach = false;
                isReached = true;
                anim.SetTrigger("ReachAttack");
                StartCoroutine(reachCD());


            }
        }

        void Shooting()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Instantiate(bulletPrefab, shootPos.position, transform.rotation);
            }
        }





        IEnumerator punchCD()
        {
            yield return new WaitForSeconds(1f);
            canReg = true;
            isReg = false;

        }
        IEnumerator reachCD()
        {
            yield return new WaitForSeconds(3f);
            canReach = true;
            isReached = false;

        }







    
}
