using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] platformPosition = new Transform[2];
    int direction = 1;
    public float speed = 1f;
    Vector2 target;
    // Update is called once per frame
    void Update()
    {
        target = CurrentMovementTarget();

        platformPosition[0].position = Vector2.Lerp(platformPosition[0].position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)platformPosition[0].position).magnitude;


        if (distance <= 0.25f)
        {
            direction *= -1;

        }

    }

    private void FixedUpdate()
    {
        platformPosition[0].position = Vector2.Lerp(platformPosition[0].position, target, speed * Time.deltaTime);
    }

    Vector2 CurrentMovementTarget()
    {
        if (direction == 1)
        {
            return platformPosition[1].position;
        }
        else
        {
            return platformPosition[2].position;
        }
    }
    private void OnDrawGizmos()
    {
        //checks to see references are null if not draw lines
        if (platformPosition[0] != null && platformPosition[1] != null && platformPosition[2] != null)
        {
            Gizmos.DrawLine(platformPosition[0].transform.position, platformPosition[1].transform.position);
            Gizmos.DrawLine(platformPosition[0].transform.position, platformPosition[2].transform.position);
        }

    }
}
