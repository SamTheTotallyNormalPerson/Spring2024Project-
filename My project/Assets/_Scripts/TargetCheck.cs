using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering;

public class TargetCheck : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();
    public string targetName; 
    public GameObject targetTransform;
    public bool isTargeting;
    public string TargetTag;
    public float checkRadius;
    public bool lookForTarget;
    public SphereCollider targetTrigger;
    public void Update()
    {
        if (Input.GetButton("Target") && isTargeting == false)
        {
           lookForTarget = true;
           targetTrigger.enabled = true;

        }
        
        else
        {
            targetTrigger.enabled = false;
            lookForTarget= false;

        } 
        
        if (Input.GetButtonUp("Target") && isTargeting == true)
        {
            isTargeting = false;
            targets.Clear();
            targetName = null;
            targetTransform = null;
        }

       
       

      
        if (lookForTarget)
        {
            
            
        
            for (int i = 0; i < targets.Count; i++)
                {
                    Vector3 targetDist = targets[i].transform.position;
                float td = Vector3.Distance(targetDist, transform.position);
                    if ((td < (checkRadius)))
                    {
                        targetName = targets[i].name;
                        targetTransform = targets[i];
                        isTargeting = true;
                        lookForTarget = false;
                        targetTrigger.enabled = false;
                    }

                }
        }

       
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (lookForTarget && other.gameObject.tag == TargetTag)
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.yellow;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }

}
