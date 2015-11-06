using UnityEngine;
using System.Collections;

public class SetRagdollActive : MonoBehaviour
{
    public Rigidbody rb;
    public int health;
    GameObject player;
    GameObject enemy;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    Vector3 enemyPos;

    // Use this for initialization
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        rb = GetComponent<Rigidbody>();
        playerHealth = GetComponent<PlayerHealth>();
        Rigidbody[] rigidBody = GetComponentsInChildren<Rigidbody>();
        enemyHealth = GetComponent<EnemyHealth>();
        foreach (Rigidbody item in rigidBody)
        {
            item.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.GetComponent<EnemyHealth>().isDead == true || enemyHealth.currentHealth <= 0)
        {
            OnDeath();
        }
    }
        
       
        // noget kode der gør at karakterne flyver i den rigtig retning og ikke bare "forward"
        // player.position - enemy.position = position
        // addforce(position)


    
    void OnDeath()
    {
        Rigidbody[] rigidBody = GetComponentsInChildren<Rigidbody>();

        //player.GetComponent<SetRagdollActive>().enabled = false; // deaktivere movement
            foreach (Rigidbody item in rigidBody)
            {
                item.isKinematic = false;
               //item.AddForce(Vector3.forward * 5);
            }
            //enemy.transform.Translate();
        
        
        
    }
    void DisableRagdoll()
    {
        Rigidbody[] rigidBody = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody item in rigidBody)
        {
            rb.isKinematic = true;
            rb.detectCollisions = false;
        }
    }
}
