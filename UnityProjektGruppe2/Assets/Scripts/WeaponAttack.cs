using UnityEngine;
using System.Collections;

public class WeaponAttack : MonoBehaviour {

    EnemyHealth enemyHealth;
    GameObject enemy;

	// Use this for initialization
	void Awake () {
        enemyHealth = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (other.gameObject == enemy)
        {
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(40);
            }
        }
    }
}
