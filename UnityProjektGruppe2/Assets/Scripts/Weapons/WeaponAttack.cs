using UnityEngine;
using System.Collections;

public class WeaponAttack : MonoBehaviour {

    EnemyHealth enemyHealth;
    GameObject enemy;
    public int damage = 20;

	// Use this for initialization
	void Awake () {
        damage = PlayerPrefs.GetInt("Strength");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.gameObject;
            enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }
}
