using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public int bulletDMG = 2;
    public float bulletSpeed = 12f;
    public Rigidbody2D rb;
    EnemyHurt eh;
    public bool ehSignal;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        eh = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHurt>();               
    }

    // Update is called once per frame
    void Update()
    {
        BulletBehavior();
      
    }

    void BulletBehavior()
    {
        rb.velocity = transform.right * bulletSpeed;
        StartCoroutine(BDP());
       
    }

    IEnumerator BDP()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            eh.TakeDamage(2);
            ehSignal = true;     
            Destroy(gameObject);
            eh.GotShot(ehSignal);         
        }
    }





}
