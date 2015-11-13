﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;
    Animator myAnimator;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
        myAnimator = GetComponent<Animator>();
    }


    void Update ()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            myAnimator.SetBool("Run", true);
            nav.SetDestination(player.position);
        }
        else
        {
            myAnimator.SetBool("Run", false);
            nav.enabled = false;
        }

    }
}
