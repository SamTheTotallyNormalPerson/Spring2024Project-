using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    public Animator anim;
    [SerializeField] string[] animName;
    [SerializeField] Player playerMovement;
    [SerializeField] Slash2 playerSlash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if(Player_Manager.GetInstance().canMove == true && playerMovement.inputVector != Vector2.zero && playerSlash.attackInput == 0)
        {
          
                anim.SetFloat(animName[0], 1);
            
        }
        else
        {
            anim.SetFloat(animName[0], 0);
        }

        anim.SetInteger(animName[1], playerSlash.attackInput);
        
        if(playerSlash.attackInput != 0)
        {
            anim.SetBool(animName[2], true);
        } else
        {
            anim.SetBool(animName[2], false);
        }

        anim.SetBool(animName[3], playerSlash.parry);
       
    }

}
