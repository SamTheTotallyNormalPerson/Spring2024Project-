using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ParryBoxCollider : MonoBehaviour
{
    public string hitBoxTag;
    public Knock knock;
   public float paryForce;
    public TargetCheck target;
    public Transform playerObj;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == hitBoxTag)
        {
            print("Parry");
            knock.knockBack = false;
            other.gameObject.GetComponentInParent<Knock>().knockBackVel = paryForce;
            other.gameObject.GetComponentInParent<Knock>().KnockBack(transform);
           
        }
    }
}
