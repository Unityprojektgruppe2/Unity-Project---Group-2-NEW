using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    public float moveForce = 5, boostMultiplier = 2;
    bool isAttacking = false;

    Rigidbody myRigidBody;
    private Animator myAnimator;
    [SerializeField]
    public BoxCollider mySwordBoxCollider;
    float currentSpeed = 0.0f;

    // Use this for initialization
    void Start()
    {
        myRigidBody = this.GetComponent<Rigidbody>();
        Input.multiTouchEnabled = true;
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Movement();
        Attack();
    }

    void Movement()
    {
        //http://answers.unity3d.com/questions/307150/rotate-an-object-toward-the-direction-the-joystick.html
        //Fix of rotation to and move in the direction of joystick

        float joyX = CrossPlatformInputManager.GetAxis("Horizontal");
        float joyY = CrossPlatformInputManager.GetAxis("Vertical");

        

        Vector3 moveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
        ////bool isBoosting = CrossPlatformInputManager.GetButton("LeButton");
        //bool isBoosting = false;


        if (moveVec.x != 0 && moveVec.z != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(-joyX, -joyY) * Mathf.Rad2Deg, transform.eulerAngles.z);
            
            //myRigidBody.transform.Rotate(0, moveVec.x * 25 * Time.deltaTime, 0);
        }

        if (moveVec.z > 0)
        {
            if (currentSpeed <= 2f)
            {
                currentSpeed += 0.1f;
            }
            myAnimator.SetFloat("Speed", currentSpeed);
        }
        else if (moveVec.z < 0)
        {
            if (currentSpeed <= 2f)
            {
                currentSpeed += 0.1f;
            }
            myAnimator.SetFloat("Speed", currentSpeed);
        }

        else
        {
            if (currentSpeed >= 0)
            {
                currentSpeed -= 0.1f;
            }
            myAnimator.SetFloat("Speed", currentSpeed);
        }
        //
        //myAnimator.SetFloat("Speed", moveVec.z * moveForce);

        //Debug.Log(moveVec);
        //Debug.Log(isBoosting.ToString());
        //Debug.Log(transform.position);

        //myRigidBody.AddForce(moveVec * (isBoosting ? boostMultiplier : 1));
    }

    void Attack()
    {
        isAttacking = CrossPlatformInputManager.GetButton("LeButton");
        
        if (isAttacking)
        {
            myAnimator.SetBool("testAttack", true);
            isAttacking = false;
            myAnimator.SetTrigger("Attack");
        }
        
    }








    //public void CollideWithEnemy(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        EnemyHealth enemyHp = other.GetComponent<EnemyHealth>();
    //        enemyHp.TakeDamage(10);

    //    }

    //}

}
