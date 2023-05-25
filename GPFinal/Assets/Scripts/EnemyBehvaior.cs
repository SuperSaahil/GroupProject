using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehvaior : MonoBehaviour
{
    Animator anim;
    public bool ChaseToggle;
    public List<Transform> points;
    public int nextId;
    private int idChangeVal = 1;
    public Transform target;
    public float speed = 5;
    PlayerControls pc;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();

    }

    // Update is called once per frame
    void Update()
    {
        stateChange();
    }
    void MovePoint()
    {
        Transform goalpoint = points[nextId];
        if(goalpoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //move to goal point
        transform.position = Vector2.MoveTowards(transform.position, goalpoint.position, speed * Time.deltaTime);

        //distance check
        if(Vector2.Distance(transform.position, goalpoint.position) < 1f)
        {
            if (nextId == points.Count - 1)
            {
                idChangeVal = -1;
            }
            if (nextId == 0)
            {
                idChangeVal = +1;
            }
            nextId += idChangeVal;
        }
       
    }

    void stateChange()
    {
        if(ChaseToggle == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if(!ChaseToggle == true)
        {
            MovePoint();
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ChaseToggle = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pc.playerHP--;
        }
    }
}
