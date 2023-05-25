using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveToken : MonoBehaviour
{
    PlayerControls pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pc.WaveCoin = true;
            Destroy(gameObject);
        }
    }
}
