using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public static Player_Manager instance;
    [Space]
    [Header("Player Actions")]
    public bool canMove;
    public bool canAttack;
    public bool isDashing;
  //  public bool isAttacking;
    [Space]
    [Header("Player Input")]
    public Vector2 inputVector;
    [Space]
    [Header("RigidBody")]
    public Rigidbody rb;
    [Header("Transform")]
    public Transform playerModel;
    [Header("Floats")]
    public float dashFroce;

    [Space]
    [Header("Scripts")]
    public Player movement;
    public Slash2 slash;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)

        {
            Debug.LogWarning("Found more than one Player Manager");
        }
        instance = this;
    }
    public static Player_Manager GetInstance()
    {
        return instance;
    }

    // Update is called once per frame
    void Update()
    {
       

       
        if (!canMove)
            inputVector = Vector2.zero;
        else
        {
            
            
                inputVector.x = Input.GetAxisRaw("Horizontal");
                inputVector.y = Input.GetAxisRaw("Vertical");
            
        }

        if (GetComponent<Knock>().knockBack == true)
        {
            canMove = false;
            movement.enabled = false;
        }
        else
        {
            canMove = true;
            movement.enabled = true;
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            inputVector = Vector2.zero;
            canMove = false;
            rb.velocity = playerModel.forward * dashFroce;
        }
        else
            return;
    }
}
