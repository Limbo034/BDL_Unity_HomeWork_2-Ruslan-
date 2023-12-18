using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateActive : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("PressurePlate", true);
        }
        //test еще не закончил
    }
}
