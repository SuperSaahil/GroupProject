using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmCollider : MonoBehaviour
{
   public BoxCollider2D armThingy;
    // Start is called before the first frame update
    void Start()
    {
        armThingy = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
