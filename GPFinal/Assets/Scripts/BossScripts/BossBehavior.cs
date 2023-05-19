using System.Collections;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    float MaxTP = 50f;
    float MinTP = 25f;
    public int BossHP = 10;
    public bool phase1;
    public bool phase2;
    public bool phase3;
    public bool death = false;
    public Transform target;
    public Transform bossPos;
    public bool TP = true;
    public Transform shootPos;
    public GameObject bossPrefab1;
    bossBulletBehavior BBB;
    Animator anim;
    PlayerControls PC;
    float speed = 5f;
    GameObject platform;
    Rigidbody2D rb;
    public bool chasing;
    public bool turretTime;
    GameObject TS;


    public GameObject turret;
    public bool p1shoot = false;
    // Start is called before the first frame update
    void Start()
    {
        // BBB = GameObject.FindGameObjectWithTag("bossBullet1").GetComponent<bossBulletBehavior>();
        turret = GameObject.FindGameObjectWithTag("turret");
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
        platform = GameObject.FindGameObjectWithTag("bossPlat");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
 
    }

    // Update is called once per frame
    void Update()
    {
        PhaseSwitch();
        FirstStage();
        SecondStage();
        ThirdStage();

    }

    void PhaseSwitch()
    {
        if (BossHP <= 10 && BossHP >= 7)
        {
            phase1 = true;
            phase3 = false;
            death = false;
            phase2 = false;
        }
        else if (BossHP <= 6 && BossHP >= 4)
        {
            phase1 = false;
            phase3 = false;
            death = false;
            phase2 = true;
        }
        else if (BossHP <= 3 && BossHP >= 1)
        {
            phase1 = false;
            phase2 = false;
            death = false;
            phase3 = true;
        }
        else if (BossHP <= 0)
        {
            phase1 = false;
            phase2 = false;
            phase3 = false;
            death = true;
        }
    }
    public void FirstStage()
    {
        turretTime = true;
        if (phase1 || phase3)
        {

            // TS.ActiveTurret();
            turret.SetActive(true);

        }
        else
        {
            turret.SetActive(false);
        }
        Teleport();
    }
    public void SecondStage()
    {
        if (phase2 || phase3)
        {
            ChasingMode();
        }

    }
    public void ThirdStage()
    {
        if(phase3)
        {
            
        }
        FirstStage();
        SecondStage();
    }
    public void ChasingMode()
    {

        if (chasing)
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, rb.position.y), speed * Time.deltaTime);
            StartCoroutine(ChaseTime());

        }
        else if (!chasing)
        { 
            StartCoroutine(ChaseWait()); 
        }

    }
    public void Teleport()
    {
        if (phase1 && TP == true)
        {
            // transform.position
            transform.position = new Vector2(Random.Range(MinTP, MaxTP), bossPos.position.y);
            TP = false;
            StartCoroutine(BossTP());


        }
    }


    IEnumerator BossTP()
    {
        yield return new WaitForSeconds(.5f);
        TP = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerArm" && PC.isReg == true)
        {
            BossHP--;
            Debug.Log("Boss Hit!");
        }
        else if (collision.gameObject.tag == "PlayerArm" && PC.isReached == true)
        {
            BossHP -= 2;
            Debug.Log("Boss Hit2");
        }
        else if (collision.gameObject.tag == "Player")
        {

            PC.playerHP -= 2;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "range" && PC.isShot == true)
        {

            BossHP--;
        }
    }

    IEnumerator ChaseWait()
    {
        yield return new WaitForSeconds(1f);
        //Instantiate(bossPrefab1, shootPos.position, transform.rotation);
        chasing = true;
    }
    IEnumerator ChaseTime()
    {


        yield return new WaitForSeconds(4f);
        chasing = false;
        Debug.Log(chasing);
    }

}
