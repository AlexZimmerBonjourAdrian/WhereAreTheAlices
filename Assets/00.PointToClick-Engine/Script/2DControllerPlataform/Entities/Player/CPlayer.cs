using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Font https://www.youtube.com/watch?v=PlT44xr0iW0&list=PLFt_AvWsXl0f0hqURlhyIoAabKPgRsqjz&index=3
/// </summary>
/// 

//[RequireComponent (typeof (CController2d))]
public class CPlayer : MonoBehaviour
{
    /*
 
    public float jumpHeight = 4;
    public float timeToJumpApex=.4f;
    float moveSpeed = 6;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocitySmothing;

    CController2d controller;

    void Start()
    {
        controller = GetComponent<CController2d>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + " jump Velocity:" + jumpVelocity);
       

    }
    void Update()
    {
        if(controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // velocity = input.x = moveSpeed;
        if(Input.GetKeyDown(KeyCode.Space)&& controller.collisions.below)
        {
            velocity.y = jumpVelocity;
        }
        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocitySmothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    /*
    const float skinwidth = .015f;
    BoxCollider2D collider;
    RayCastOrigin rayCastOrigin
    */



    /*
   private CMoveSystem controller;
    [SerializeField]private float _Speed =200f;
     float horizontalMove = 3;
    bool jump = false;
    [SerializeField]
    private float DelayStateFall = 1f;
    #region States mACHINE
    private const int STATE_STAND = 0;
    private const int STATE_MOVE = 1;
    private const int STATE_JUMP = 2;
    private const int STATE_FALL = 3;
    private const int STATE_HIT = 4;
    private const int STATE_DIYNG = 5;
    private const int STATE_DIE = 6;
   // [SerializeField]
    private int _aState = 0;
    #endregion

    [SerializeField]private float _dashSpeed = 30f;
    //private float vel = 10f;
   // private int MaxHealth=3;
   // private int currentHealth = 3;
    private Transform _positionShoot;
    
    

    //private bool isBool = false;




    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CMoveSystem>();


        //Transform shoot
        _positionShoot = transform.Find("Shoot");
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.X))
        {
            //CBulletManager.Inst.Spawn(_positionShoot.position,Vector2.right * vel * 2);

           
        }
        //Debug.Log("Estado" + _aState);
        if (Input.GetButton("Horizontal"))
        {
            setState(STATE_MOVE);
        }
        else if(!Input.GetButton("Horizontal"))
        {
            setState(STATE_STAND);
        }

        if (Input.GetKeyDown(KeyCode.Z) && jump == false ) 
        {
           
            setState(STATE_JUMP);
        }

      

        if(_aState==STATE_JUMP)
        {
            for (float i = DelayStateFall*Time.deltaTime; i > 0; i--)
            {
                if (i == DelayStateFall)
                {

                    setState(STATE_FALL);
                }
            }
        }

    }
    void FixedUpdate()
    {
        
        jump = false;
    }
    private void setState(int aState)
    {
        _aState = aState;
        
        if(aState== STATE_STAND)
        {
            if(Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D))
            {
                setState(STATE_MOVE);
            }
            jump = true;

            controller.MovePlayer(horizontalMove * Time.deltaTime, jump);
        }
        else if(aState == STATE_MOVE)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * _Speed;
           
            if (!Input.GetKeyDown(KeyCode.A)|| !Input.GetKeyDown(KeyCode.D))
            {
                setState(STATE_STAND);

            }
            jump = true;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                setState(STATE_JUMP);
            }

        }
        else if(aState == STATE_JUMP)
        {


            jump = false;
            controller.MovePlayer(horizontalMove * Time.deltaTime, jump);
            //controller.MovePlayer(horizontalMove * Time.deltaTime, jump);
            setState(STATE_FALL);




        }
        else if(aState== STATE_FALL)
        {
            
        }
        else if(aState == STATE_HIT )
        {

        }
        else if(aState == STATE_DIE)
        {

        }
        else if(aState == STATE_DIYNG)
        {

        }
        
    }
    public void TakeDamage()
    {
     
    }
    public void Die()
    {

    }
   public void Shoot()
    {
        
    }
   

    */

}
