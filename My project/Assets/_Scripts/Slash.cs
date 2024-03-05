using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public int attackInput;
    public int maxSlashes = 3;
    public float attackTimer;
    public float attackTimeAmount;
    public float inputDelay;
    public bool comboComplete;
    public Vector2 inputVector;
    // Start is called before the first frame update
    void Start()
    {
        inputVector = Player_Manager.GetInstance().inputVector;
    }

    // Update is called once per frame
    void Update()
    {
        //Start Timer
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;               
        }

        //Player Input
        if (Input.GetButtonDown("Fire1") && Player_Manager.GetInstance().canAttack)
        {
            attackInput += 1;
            StartCoroutine(Slashy());
            if(inputVector != Vector2.zero)
            {
              inputVector = Vector2.zero;
            }
        }    

       
      

        //Reset Timer
        if(attackTimer <= 0 && attackInput != maxSlashes)
        {
            attackTimer = 0;
            attackInput = 0;

            if (comboComplete == false)
            {
                Player_Manager.GetInstance().canMove = true;
               // StartCoroutine(CombatCoolDown());
            }
         
        }
      

        if(attackInput >= maxSlashes)
        {
            comboComplete = true;
          //  attackInput = maxSlashes;
            Player_Manager.GetInstance().canAttack = false;
            if (comboComplete)
            {
                Player_Manager.GetInstance().canMove = false;
                StartCoroutine(ComboCoplete());
            } else
            {
                return;
            }
        }
       
    }

   

    private IEnumerator ComboCoplete()
    {
        
        attackTimer = attackTimeAmount + 2f;
        print("DontAttack");
        yield return new WaitForSeconds(attackTimeAmount);
        attackInput = 0;      
        attackTimer = 0;
      
        yield return new WaitForSeconds(.25f);
      //  Player_Manager.GetInstance().canMove = true;
        yield return new WaitForSeconds(.1f);
        Player_Manager.GetInstance().canAttack = true;
        comboComplete = false;
        print("Can Attack");
    }

   
    private IEnumerator Slashy()
    {
        Player_Manager.GetInstance().canMove = false;
       
        Player_Manager.GetInstance().canAttack = false;
        attackTimer = attackTimeAmount;
        yield return new WaitForSeconds(inputDelay);
        Player_Manager.GetInstance().canAttack = true;
    }
}
