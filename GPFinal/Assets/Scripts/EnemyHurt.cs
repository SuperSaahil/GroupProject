using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    public int EnemyHP = 3;
    PlayerControls PC;
    Animator anim;
    bulletBehavior BB;
    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
        anim = GetComponent<Animator>();
        BB = GameObject.FindGameObjectWithTag("range").GetComponent<bulletBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDeath();

    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerArm" && PC.isReg == true)
        {
            EnemyHP--;
            anim.SetTrigger("Hurt");
            Debug.Log("Hit!");
        }
        else if (collision.gameObject.tag == "PlayerArm" && PC.isReached == true)
        {
            EnemyHP = EnemyHP - 3;
            anim.SetTrigger("Hurt");
            Debug.Log("Reached");
        }

    }

    void EnemyDeath()
    {
        if(EnemyHP <= 0 )
        {
            Destroy(gameObject);
            Debug.Log("Vanquished");
        }
    }
   public void GotShot(bool ehSignal)
    {
        if (ehSignal == true)
        {
            Debug.Log("test");
            anim.SetTrigger("Hurt");
            BB.ehSignal = false;
           
        }
    }

    public int TakeDamage(int dmg)
    {
        EnemyHP -= dmg;
        return EnemyHP;
    }
    
   
}
