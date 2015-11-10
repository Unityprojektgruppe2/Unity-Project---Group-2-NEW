using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    public float moveForce = 5, boostMultiplier = 2;
    bool attackBtnPressed = false;
    bool whirlwindBtnPressed = false;
    bool whirlwinding = false;

    Rigidbody myRigidBody;
    public Animator myAnimator;
    [SerializeField]
    public BoxCollider mySwordBoxCollider;
    float currentSpeed = 0.0f;

    public bool invulnerable = false;

    //Whirlwind Variables
    float rotationleft = 0;
    float rotationspeed = 1440; //rotation speed
    Vector3 angleBeforeWhirlwind;
    float whirlwindRange = 0.2f;
    float whirlwindSaveY; //Saves current Y before whirlwind to resume this (2-25 degree bug fix)

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
        if (!whirlwinding)
        {
            Movement();
        }
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
    }

    void Attack()
    {
        attackBtnPressed = CrossPlatformInputManager.GetButtonDown("LeButton");

        if (attackBtnPressed)
        {
            myAnimator.SetBool("dAttackSecurity", true);
            attackBtnPressed = false;
            myAnimator.SetTrigger("Attack");
        }

        whirlwindBtnPressed = CrossPlatformInputManager.GetButtonDown("Whirlwind");
        if (whirlwindBtnPressed && !whirlwinding)
        {
            whirlwinding = true;
            angleBeforeWhirlwind = Vector3.Normalize(transform.forward);
            whirlwindSaveY =  transform.eulerAngles.y;

            rotationleft = 1440;
            myAnimator.SetTrigger("Whirlwind");
        }

        if (whirlwinding)
        {
            float rotation = rotationspeed * Time.deltaTime;
            bool rotateMe = false;
            if (rotationleft > rotation)
            {
                rotationleft -= rotation;
                rotateMe = true;
            }
            else
            {
                rotateMe = false;
                rotation = rotationleft;
                rotationleft = 0;
                whirlwinding = false;
                myAnimator.SetTrigger("WhirlwindStanceEnd");
                transform.rotation = Quaternion.Euler(transform.rotation.x, whirlwindSaveY, transform.rotation.z);
            }
            if (rotateMe)
            {
                transform.parent.Translate(angleBeforeWhirlwind * whirlwindRange);   
                transform.Rotate(0, -rotation, 0);
                
            }

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
