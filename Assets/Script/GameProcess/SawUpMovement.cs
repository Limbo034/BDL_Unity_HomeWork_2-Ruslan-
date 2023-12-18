using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawUpMovement : MonoBehaviour
{
    [Range(0, 10f)][SerializeField] private float movementDistance;
    [Range(0, 10f)][SerializeField] private float movementSpeed;
    [SerializeField] private bool startFromBottom = true;

    private bool movingUp;
    private float topEdge;
    private float bottomEdge;

    private void Awake()
    {
        topEdge = transform.position.y - movementDistance;
        bottomEdge = transform.position.y + movementDistance;

        movingUp = startFromBottom;
    }

    private void Update()
    {
        if (movingUp)
        {
            if (transform.position.y > topEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - movementSpeed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingUp = false;
            }
        }
        else
        {
            if (transform.position.y < bottomEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + movementSpeed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingUp = true;
            }
        }
    }
}
