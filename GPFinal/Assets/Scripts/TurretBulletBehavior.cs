using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletBehavior : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    PlayerControls PC;
    bool shot = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletBehavior();
        hitCheck();

    }

    void bulletBehavior()
    {
        rb.velocity = -transform.right * speed;
        StartCoroutine(BDP());
    }
    void hitCheck()
    {
        if (shot == true)
        {
            Destroy(gameObject);
        }
    }


    IEnumerator BDP()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PC.playerHP--;
            shot = true;
        }
        else if (collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }

    }

}
