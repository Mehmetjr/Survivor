
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Zombiescript : MonoBehaviour
{
    Animator Zombianim;

    [HideInInspector]
    public Transform hedef;
    [SerializeField] float StoppingDistance = 0;


    NavMeshAgent Agent;
   [SerializeField] float damage;

    public float health;
    public bool scoreCalculated = false;

    void Start()
    {
        Zombianim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        Zombianim.SetFloat("hız", Agent.velocity.magnitude);
        Zombianim.SetFloat("can", health);
        float mesafe = Vector3.Distance(transform.position, hedef.transform.position);

       if (health > 0)
        {
            if (mesafe > StoppingDistance)
            {
                Agent.SetDestination(hedef.transform.position);
                Agent.enabled = true;
            }
            else
            {
                Agent.enabled = false;
            }
        }
        else
        {
            Destroy(gameObject, 5f);
        }
    }
}
