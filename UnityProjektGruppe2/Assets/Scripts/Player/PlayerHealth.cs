using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    #region Variables
    private bool isAlive = true;
    public static int maxHealth = 100;
    public float currentHealth = 100;
    public float timesMaxHealth = 0.1f;
    public Slider healthSlider;   // Reference to the UI's health bar.

    GameObject enemy;
    EnemyAttack enemyAttack;
    Animator myAnimator;

    #endregion

    #region methods

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    #region Awake method
    //sets the variables and find tag.
    void awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyAttack = enemy.GetComponent <EnemyAttack> ();
    }
    #endregion

    #region Take damage method

    //If method is run, takes integer amount as damage from other script

    public void TakeDamage(int amount)
    {
        if (!myAnimator.GetBool("Whirlwinding"))
        {
            currentHealth -= amount;
            healthSlider.value = currentHealth;
        }
        
    }
    #endregion

    #region Trigger method
    //If collider is entered by other, trigger if sentence.

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUpHealth")
        {
            currentHealth += (maxHealth * timesMaxHealth);
        }

    }

    #endregion

    #region Death
    //destroys gameobject if health is below certain number.

    public void Death()
    {
        if (currentHealth <= 0 || !isAlive)
        {
            GameOver();
            //Destroy(this.gameObject);
            
        }
    }
    #endregion

    #region Gameover (empty script)
    public void GameOver()
    {
        if (myAnimator.GetBool("Alive"))
        {
            myAnimator.SetBool("Alive", false);
            myAnimator.SetTrigger("Death");
        }
        //Application.LoadLevel("Level1");
        
    }

    #endregion

    #region Update
    // Update is called once per frame
    void Update ()
    {
        Death();
	}
    #endregion


    #endregion

}
