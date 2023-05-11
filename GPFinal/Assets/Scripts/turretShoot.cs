using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShoot : MonoBehaviour
{
    public Transform shootPos;
    public GameObject bulletPrefab;
    BossBehavior BossB;
    public bool shot = false;
   
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

    void ActiveTurret()
    {
       /* if(BossB.phase1 == true)
        {
            
            Instantiate(bulletPrefab, shootPos.position, transform.rotation);
            StartCoroutine(P1Spawn());
        }*/

        if (shot == true)
        {

            Instantiate(bulletPrefab, shootPos.position, transform.rotation);
            StartCoroutine(P1Spawn());
            
            
        }
      
    }
    IEnumerator P1Spawn()
    {
        shot = false;
        yield return new WaitForSeconds(.25f);
        shot = true;

    }
   
}
