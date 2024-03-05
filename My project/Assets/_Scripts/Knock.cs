using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knock : MonoBehaviour
{
    public bool knockBack;  
    public Transform center;
  public Rigidbody rB;
    public float knockBackVel;
    public float knockBackTime;
   
    public Vector3 knockBackDir;


    
    

    private void Start()
    {
     //   rB = GetComponent<Rigidbody>();
    }
    public void KnockBack(Transform t)
    {
        var dir = center.position - t.position;

        rB.velocity = new Vector3(dir.x, 0, dir.z).normalized * knockBackVel;
        
       
        knockBack = true;
        knockBackDir = dir;
      
       
   //     print(dir);
        StartCoroutine(Unkockback());
    }

    public void KnockBackY(Transform t)
    {
        var dir = center.position - t.position;
        
           
            rB.velocity = new Vector3(0, dir.y * knockBackVel, 0);
       
           
        
      
        knockBack = true;
        knockBackDir = dir;


     //   print(dir);
        StartCoroutine(Unkockback());
    }

    

    private IEnumerator Unkockback()
    {
        yield return new WaitForSeconds(knockBackTime);
        knockBack = false;
    }
}
