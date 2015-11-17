using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    #region Variables
    private bool scoreSet = false;
    private bool highcal1 = false;
    private bool highcal2 = false;
    private int tempscore = 0;
    private int tempscore2 = 0;
    public static int maxHealth = 100;
    public float currentHealth = 100;
    public float timesMaxHealth = 0.2f;
    public int defensestat;
    public Slider healthSlider;   // Reference to the UI's health bar.

    GameObject enemy;
    EnemyAttack enemyAttack;
    Animator myAnimator;

    [SerializeField]
    private AudioSource playerAudio;

    [SerializeField]
    private AudioClip clipLaugh;


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
        defensestat = PlayerPrefs.GetInt("Defence");
    }
    #endregion

    #region Take damage method

    //If method is run, takes integer amount as damage from other script

    public void TakeDamage(int amount)
    {
        if (!myAnimator.GetBool("Whirlwinding"))
        {
            amount -= defensestat;
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
            healthSlider.value = currentHealth;
        }

    }

    #endregion

    #region Death
    //destroys gameobject if health is below certain number.

    public void Death()
    {
        if (currentHealth <= 0 || !myAnimator.GetBool("Alive"))
        {
            //playerAudio.PlayOneShot(clipLaugh);
            GameOver();
            //Destroy(this.gameObject);

            if (PlayerPrefs.HasKey("Highscore") && scoreSet == false)
            {
                if (PlayerPrefs.GetInt("Highscore") < ScoreManager.score)
                {
                    tempscore = PlayerPrefs.GetInt("Highscore");
                    PlayerPrefs.SetInt("Highscore", ScoreManager.score);
                    highcal1 = true;
                    Debug.Log(PlayerPrefs.GetInt("Highscore"));
                }

            }
            if (PlayerPrefs.HasKey("Highscore2") && scoreSet == false)
            {
                if (PlayerPrefs.GetInt("Highscore2") < ScoreManager.score && PlayerPrefs.GetInt("Highscore2") < PlayerPrefs.GetInt("Highscore"))
                {
                    if (highcal1 == true)
                    {
                        tempscore2 = PlayerPrefs.GetInt("Highscore2");
                        PlayerPrefs.SetInt("Highscore2", tempscore);
                        highcal1 = false;
                        highcal2 = true;
                    }
                    else
                    {
                        tempscore2 = PlayerPrefs.GetInt("Highscore2");
                        PlayerPrefs.SetInt("Highscore2", ScoreManager.score);
                        highcal2 = true;
                    }

                    Debug.Log(PlayerPrefs.GetInt("Highscore2"));
                }

            }
            if (PlayerPrefs.HasKey("Highscore3") && scoreSet == false)
            {
                if (PlayerPrefs.GetInt("Highscore3") < ScoreManager.score && PlayerPrefs.GetInt("Highscore3") < PlayerPrefs.GetInt("Highscore2"))
                {

                    if (highcal2 == true)
                    {
                        PlayerPrefs.SetInt("Highscore3", tempscore2);
                        highcal2 = false;

                    }
                    else
                    {
                        PlayerPrefs.SetInt("Highscore3", ScoreManager.score);
                    }
                    Debug.Log(PlayerPrefs.GetInt("Highscore3"));
                }

            }
            else
            {
                PlayerPrefs.SetInt("Highscore", ScoreManager.score);
                PlayerPrefs.SetInt("Highscore2", ScoreManager.score);
                PlayerPrefs.SetInt("Highscore3", ScoreManager.score);
                //Debug.Log(ScoreManager.score);
            }

            scoreSet = true;
            PlayerPrefs.SetInt("Score", ScoreManager.score);

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
