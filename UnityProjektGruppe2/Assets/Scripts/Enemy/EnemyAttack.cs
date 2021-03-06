﻿using UnityEngine;
using System.Collections;
    

public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 1.5f;     // The time in seconds between each attack.
	public int attackDamage = 10;               // The amount of health taken away per attack.
    private int attackModifier;
    public bool attacking = false;
    [SerializeField]
    private int amountOfDifferentAttacks = 1;

    [SerializeField]
    private AudioSource enemyAudio;

    [SerializeField]
    private AudioClip[] clipAttack = new AudioClip[2];

	private Animator myAnimator;                        // Reference to the animator component.
    private GameObject player;                          // Reference to the player GameObject.
    private PlayerHealth playerHealth;                  // Reference to the player's health.
    private EnemyHealth enemyHealth;                    // Reference to this enemy's health.
	bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
	float timer;                                // Timer for counting up to the next attack.
	
	
	void Awake ()
	{
        // Setting up the references.
        enemyAudio.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent<EnemyHealth>();
		myAnimator = GetComponent <Animator> ();
        attackModifier = PlayerPrefs.GetInt("enemyDmgModifier");
	}
	
	
	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if(other.gameObject == player)
		{
			// ... the player is in range.
			playerInRange = true;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		// If the exiting collider is the player...
		if(other.gameObject == player)
		{
			// ... the player is no longer in range.
			playerInRange = false;
		}
	}
	
	
	void Update ()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;
		
		// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
		if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0 && attacking == false)
		{
            attacking = true;
			// ... attack.
			Attack();
		}
		
		// If the player has zero or less health...
		if(playerHealth.currentHealth <= 0)
		{
            myAnimator.SetBool("Run", false);
            // ... tell the animator the player is dead.
            //anim.SetTrigger ("PlayerDead");
        }
	}
	
	
	void Attack ()
	{
		// Reset the timer.
		timer = 0f;

		// If the player has health to lose...
		if(playerHealth.currentHealth > 0)
		{

            enemyAudio.PlayOneShot(clipAttack[Random.Range(0,clipAttack.Length)]);

            int MaxAttackMoves = Random.Range(1, amountOfDifferentAttacks + 1);

            myAnimator.SetFloat("AttackMove", MaxAttackMoves);

            myAnimator.SetTrigger("Attack");
            // ... damage the player.
            if ((attackDamage + attackModifier) - 10 < 5 )
            {
                playerHealth.TakeDamage(5);
            }
            else
            {
                playerHealth.TakeDamage(Random.Range((attackDamage + attackModifier) - 10, attackDamage + attackModifier));
            }
            //playerHealth.TakeDamage(attackDamage + attackModifier);
		}
	}
}