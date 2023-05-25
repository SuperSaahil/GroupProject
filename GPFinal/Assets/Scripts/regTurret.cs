using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regTurret : MonoBehaviour
{

    public bool shot;
    public GameObject bulletPrefab;
    public Transform shootPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shooting();
    }

    void shooting()
    {
        if (shot == true)
        {
            Instantiate(bulletPrefab, shootPos.position, transform.rotation);
            shot = false;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2f);
        shot = true;
    }
}
