using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSidewaysMovement : MonoBehaviour
{
    [Range(0, 10f)][SerializeField] private float movementDistance;
    [Range(0, 10f)][SerializeField] private float movementSpeed;
    [SerializeField] private bool startFromLeft = true;

    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;

        movingLeft = startFromLeft;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }
}
