using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        } 
    }

    private void TakeDamage()
    {
        if(health -30 >0)
        {
            health--;
        }
        else
        {
            gameObject.SetActive(false);
            health = maxHealth;
        }

    }
}
