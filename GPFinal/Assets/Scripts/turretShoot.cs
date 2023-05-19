using System.Collections;
using UnityEngine;

public class turretShoot : MonoBehaviour
{
    public Transform shootPos;
    public GameObject bulletPrefab;
    BossBehavior BossB;
    public bool shot = true;
    public bool FinalShot = true;

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

       
        
        if (BossB.phase1 && shot )
        {

            Instantiate(bulletPrefab, shootPos.position, transform.rotation);
            shot = false;
            StartCoroutine(P1Spawn());

        }
        else if(BossB.phase3 && FinalShot == true)
        {
            
            Instantiate(bulletPrefab, shootPos.position, transform.rotation);
            FinalShot = false;
            StartCoroutine(FinalTurret());
        }

    }


    IEnumerator P1Spawn()
    {

        yield return new WaitForSeconds(.1f);
        shot = true;

    }
    IEnumerator FinalTurret()
    {
        yield return new WaitForSeconds(.15f);
        FinalShot = true;
    }


}


