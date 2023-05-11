using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShoot : MonoBehaviour
{
    public Transform shootPos;
    public GameObject bulletPrefab;
    BossBehavior BossB;
    bool shot = true;
 
    // Start is called before the first frame update
    void Start()
    {
        BossB = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossBehavior>();
      
    }

    // Update is called once per frame
    void Update()
    {
        ActiveTurret();
    }
    public void ActiveTurret()
    {

       
        if (BossB.phase1 && shot)
        {
            Debug.Log("test");
            Instantiate(bulletPrefab, shootPos.position, transform.rotation);
            shot = false;
            StartCoroutine(P1Spawn());


        }
    }


        IEnumerator P1Spawn()
        {
           
            yield return new WaitForSeconds(.1f);
            shot = true;

        }


    }


