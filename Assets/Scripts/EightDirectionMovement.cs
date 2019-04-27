using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EightDirectionMovement : MonoBehaviour
{

    public bool canPlayerMove;

    [SerializeField] private float moveSpeed;

    [SerializeField] private Animator characterAnimator;
    [SerializeField] private Transform heroGraphics;

    private Rigidbody2D playerRigBdy;
    private bool facingRigth;

    private Vector2 direction;
    public Vector2 Direction
    {
        get
        {
            return direction;
        }
        set
        {
            direction = value;
        }
    }

    void Awake()
    {

        playerRigBdy = GetComponent<Rigidbody2D>();

        //if (heroGraphics == null)
        //{
        //    heroGraphics = transform.Find("GFX");
        //}

        //if (characterAnimator == null)
        //{
        //    characterAnimator = GetComponentInChildren<Animator>();
        //}

    }


    private void Start()
    {
        facingRigth = true;
        canPlayerMove = true;
    }


    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        MovementLogicVelocity();

        PlayerRunningAnims();

        if (Direction.x > 0 && !facingRigth)
        {
            Flip();
        }
        else if (Direction.x < 0 && facingRigth)
        {
            Flip();
        }
    }

    public void Flip() // TODO update Flip() Method to use the sprite flip insted of scale *-1
    {
        facingRigth = !facingRigth;
        Vector3 theScale = heroGraphics.localScale;
        theScale.x *= -1;
        heroGraphics.localScale = theScale;
    }

    private void PlayerRunningAnims()
    {
        if (Mathf.Abs(Direction.x) > 0 || Mathf.Abs(Direction.y) > 0)
        {
            characterAnimator.SetBool("Running", true);
            //Debug.Log("Run Anim");
        }
        else
        {
            characterAnimator.SetBool("Running", false);
            //Debug.Log("Idle Anim");
        }

    }

    void MovementLogicVelocity()
    {
        //playerRigBdy.velocity = new Vector2( Input.GetAxis("Horizontal") * moveSpeed,  Input.GetAxis("Vertical") * moveSpeed);
        playerRigBdy.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }

}
