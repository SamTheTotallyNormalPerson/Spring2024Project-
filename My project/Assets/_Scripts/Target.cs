using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;

public class Target : MonoBehaviour
{
  public List<GameObject> targets = new List<GameObject>();

  public string targetName;
    public float checkRadius;
    public LayerMask targetLayer;
    public bool isTargeting;
    public string TargetTag;
    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            isTargeting = true;
        } else
        {
            isTargeting = false;
        }

        if (!isTargeting)
        {
            targets.RemoveAll(t => t.name == targetName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isTargeting && other.gameObject.tag == TargetTag)
        {
            targets.Add(other.gameObject);
        }
    }
}
