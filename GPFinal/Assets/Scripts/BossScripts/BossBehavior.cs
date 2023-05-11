using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public int BossHP = 10;
    public bool phase1;
    public bool phase2;
    public bool phase3;
    public bool death = false;
    public Transform target;
    public Transform bossPos;

    public Transform shootPos;
    public GameObject bossPrefab1;
    bossBulletBehavior BBB;
    Animator anim;
    public bool p1shoot = false;
    // Start is called before the first frame update
    void Start()
    {
       // BBB = GameObject.FindGameObjectWithTag("bossBullet1").GetComponent<bossBulletBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        PhaseSwitch();
        firstStage();
    }

    void PhaseSwitch()
    {
        if(BossHP <= 10 && BossHP >= 7)
        {
            phase1 = true;
            phase3 = false;
            death = false;
            phase2 = false;
        }
        else if(BossHP >= 6 && BossHP <= 4)
        {
            phase1 = false;
            phase3 = false;
            death = false;
            phase2 = true;
        }
        else if(BossHP >=3 && BossHP > 0)
        {
            phase1 = false;
            phase2 = false;
            death = false;
            phase3 = true;
        }
        else if(BossHP<=0)
        {
            phase1 = false;
            phase2 = false;
            phase3 = false;
            death = true;
        }
    }
    void firstStage()
    {
        if (phase1 == true)
        {
            if(p1shoot == true)
            {
                Instantiate(bossPrefab1, shootPos.position, transform.rotation);
                StartCoroutine(P1Spawn());
            }
            
            //anim.SetTrigger("phase1");
        }
    }

   

    IEnumerator P1Spawn()
    {
        p1shoot = false;
        yield return new WaitForSeconds(2f);
        p1shoot = true;
        

    }
}
