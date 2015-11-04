using UnityEngine;
using System.Collections;

public class EnemyLooseHealthAndDie : MonoBehaviour {

    private float health;

	// Use this for initialization
	void Start () 
    {
        health = 100;	
	}
	
	// Update is called once per frame
	void Update () 
    {
        AmIDead();	
	}
    public void TakeDmg(float dmg)
    {
        health -= dmg;
        Debug.Log(health);
    }
    private void AmIDead()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
