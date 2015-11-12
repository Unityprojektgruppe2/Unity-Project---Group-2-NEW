﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    public float moveForce = 5, boostMultiplier = 2; //Old code?
    bool attackBtnPressed = false;

    bool whirlwindBtnPressed = false;
    bool whirlwinding = false; //If or not the player is currently Whirlwinding

    bool dashBtnPressed = false;
    bool dashing = false; //If or not the playe ris currently Dashing

    Rigidbody myRigidBody;
    public Animator myAnimator;

    [SerializeField]
    CanvasGroup myAnalogStick;

    [SerializeField]
    public BoxCollider mySwordBoxCollider; //Needed for enabling the boxCollider when starting/ending attack/s animation/s
    float currentSpeed = 0.0f;

    //Attack Move Variables
    Vector3 angleBeforeAttackMove; ////Save the character view angle (Where he is pointing) for later reference (Before whirlwinding / dashing)
    float AttackMoveSaveY; //Saves current Y before whirlwind/dash to resume this (2-25 degree bug fix)


    //Whirlwind Variables
    float rotationleft = 0; //instantiates the rotationleft
    float rotationspeed = 1440; //rotation speed

    float whirlwindRange = 0.1f; //How far whirlwind is moving player


    //Dash Variables
    float dashRange = 0.3f; //How far whirlwind is moving player

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
        if (myAnimator.GetBool("Alive"))
        {

            if (!whirlwinding) //Prevents player to move while whirlwinding
            {
                Movement();
            }
            Attack();
        }

    }

    void Movement()
    {
        //http://answers.unity3d.com/questions/307150/rotate-an-object-toward-the-direction-the-joystick.html
        //Fix of rotation to and move in the direction of joystick

        float joyX = CrossPlatformInputManager.GetAxis("Horizontal");
        float joyY = CrossPlatformInputManager.GetAxis("Vertical");

        //Saves the axis values for reference 
        Vector3 moveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;

        //Rotates the player depending on joystick angle
        if (moveVec.x != 0 && moveVec.z != 0)
        {
            //Old code for reference
            ///transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(-joyX, -joyY) * Mathf.Rad2Deg, transform.eulerAngles.z);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(-moveVec.x, -moveVec.z) * Mathf.Rad2Deg, transform.eulerAngles.z);

            //myRigidBody.transform.Rotate(0, moveVec.x * 25 * Time.deltaTime, 0);
            
        }

        //Sets the player in forward moving, if joystick is being dragged
        if (moveVec.z != 0 || moveVec.z != 0)
        {
            if (currentSpeed <= 2f)
            {
                myAnalogStick.alpha = 0.3f;
                currentSpeed += 0.1f; //Slowly speeds up (Animation Wise) for blending
            }
            myAnimator.SetFloat("Speed", currentSpeed);
        }

        else
        {
            if (currentSpeed >= 0)
            {
                myAnalogStick.alpha = 1.0f;
                currentSpeed -= 0.1f; //Slowly speeds down (Animation Wise) for blending
            }
            myAnimator.SetFloat("Speed", currentSpeed);
        }
    }

    void Attack()
    {
        MeleeAttack();
        WhirlwindAttack();
        DashAttack();
    }


    /// <summary>
    /// Whirlwind Attack
    /// Modified from: http://answers.unity3d.com/questions/31477/rotate-the-object-only-360degree-for-once.html
    /// </summary>
    private void WhirlwindAttack()
    {
        whirlwindBtnPressed = CrossPlatformInputManager.GetButtonDown("Whirlwind"); //Button Check if pressed
        if (whirlwindBtnPressed && !whirlwinding && !dashing && myAnimator.GetBool("Alive")) //If btn is pressed, not whirlwinding and alive
        {
            whirlwinding = true; //Now currently Whirlwinding
            angleBeforeAttackMove = Vector3.Normalize(transform.forward); //Save the character view angle (Where he is pointing) for later reference
            AttackMoveSaveY = transform.eulerAngles.y; //Save the Y axe specificly

            rotationleft = 1440; //Rotate left for 1440 degrees
            myAnimator.SetTrigger("Whirlwind"); //Set the animationtrigger Whirlwind
        }

        if (whirlwinding)
        {
            float rotation = rotationspeed * Time.deltaTime; //Get the amount of rotation
            bool rotateMe = false; //Defaults the rotateMe to false, for check if/not to rotate more
            if (rotationleft > rotation)
            {
                rotationleft -= rotation; //rotationLeft decreases as player rotates
                rotateMe = true; //Player will be rotated
            }
            else //Will cease the whirlwinding
            {
                rotateMe = false; //Not going to rotate
                rotation = rotationleft;
                rotationleft = 0;
                whirlwinding = false; //Sets player out of whirlwind action
                myAnimator.SetTrigger("WhirlwindStanceEnd"); //Starts the end animation for Whirlwind
                transform.rotation = Quaternion.Euler(transform.rotation.x, AttackMoveSaveY, transform.rotation.z); //Fixes a potential rotation bug with a degree of 10-30
            }
            if (rotateMe)
            {
                transform.parent.Translate(angleBeforeAttackMove * whirlwindRange); //Moves the parent object in the direction the player was pointing before whirlwind (To make the player move)
                transform.Rotate(0, -rotation, 0); //Rotates the player object

            }

        }
    }

    private void MeleeAttack()
    {
        attackBtnPressed = CrossPlatformInputManager.GetButtonDown("LeButton");

        if (attackBtnPressed && myAnimator.GetBool("Alive")) //If button pressed and Alive
        {
            myAnimator.SetBool("dAttackSecurity", true); //fixes a doubble attack bug, ensures only one attack as dAttackSecurity will be set to false when leaving attackState -> AttackAnimationBehaviour.cs
            myAnimator.SetTrigger("Attack"); //Starts the Attack move
        }
    }

    private void DashAttack()
    {
        //Code almost copied from Whirlwind!
        //If this can be optimized feel free!

        dashBtnPressed = CrossPlatformInputManager.GetButtonDown("Dash"); //Button Check if pressed
        if (dashBtnPressed && !whirlwinding && !dashing && myAnimator.GetBool("Alive")) //If btn is pressed, not whirlwinding and alive
        {
            dashing = true; //Now currently Dashing
            angleBeforeAttackMove = Vector3.Normalize(transform.forward); //Save the character view angle (Where he is pointing) for later reference
            AttackMoveSaveY = transform.eulerAngles.y; //Save the Y axe specificly

            rotationleft = 1440; //Rotate left for 1440 degrees
            myAnimator.SetTrigger("Dash"); //Set the animationtrigger Whirlwind
                                           //transform.rotation = Quaternion.Euler(transform.rotation.x, AttackMoveSaveY, transform.rotation.z); //Fixes a potential rotation bug with a degree of 10-30

        }

        if (dashing)
        {
            float rotation = rotationspeed * Time.deltaTime; //Get the amount of rotation
            bool moveMe = false; //Defaults the moveMe to false, for check if/not to move more
            if (rotationleft > rotation)
            {
                rotationleft -= rotation; //rotationLeft decreases as player rotates
                moveMe = true; //Player will be rotated

            }
            else //Will cease the dashing
            {
                moveMe = false; //Not going to move
                rotation = rotationleft;
                rotationleft = 0;
                myAnimator.SetTrigger("DashStanceEnd"); //Starts the end animation for Whirlwind
                dashing = false; //Sets player out of dashing action
                transform.rotation = Quaternion.Euler(transform.rotation.x, AttackMoveSaveY, transform.rotation.z); //Fixes a potential rotation bug with a degree of 10-30
            }
            if (moveMe)
            {
                //myRigidBody.AddForce(transform.forward.x * 30 * rotation,transform.forward.y,transform.forward.z * 30 * rotation);
                //myParentsRigidBody.AddForce(400, transform.forward.y, 400);
                transform.parent.Translate(angleBeforeAttackMove * dashRange); //Moves the parent object in the direction the player was pointing before dashing (To make the player move)
                //transform.Rotate(0, -rotation, 0); //Rotates the player object

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
