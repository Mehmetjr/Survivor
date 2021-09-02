using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class Gunscript : MonoBehaviour
{
    public GameObject ScoreUpdater;
    //Görünmez bir ışın oluşturduk raypointin ucundan çıkacak ışın
    RaycastHit hit;
    //silahın ucunda
    public GameObject RayPoint;
    //ateş ediyor mu?
    public bool Canfire;
    //silahı nekadar sıklıkla ateş edeceği
    float gunTimer;
    //Geçiş süresi
    public float gunCooldown;

    public ParticleSystem MuzzleFlash;

    AudioSource SesKaynak;
    public AudioClip FireSound;
    //mesafe
    public float range;
    public float damage;

    Animator GunAnimset;

    private void Awake()
    {
        LevelManager levelManager = LevelManager.GetInstance();
        switch (levelManager.currentLevel)
        {
            case 0:
                damage = levelManager.easyDamage;
                break;

            case 1:
                damage = levelManager.mediumDamage;
                break;

            default:
                Debug.Log("There is an issue with the Level Manager Script");
                break;
        }
    }
    void Start()
    {
        SesKaynak = GetComponent<AudioSource>();

    }



    // Update is called once per frame
    void Update()
    {


        //Sol tık ve guntimer ile o aralıkta bişey yapamamayı sağlıyor
        if (Input.GetKey(KeyCode.Mouse0) && Canfire == true && Time.time > gunTimer)
        {
            Fire();
            gunTimer = Time.time + gunCooldown;
        }
    }

    void Fire()
    {    //Raycastimiz raypointin pozisyonundan önüne doğru 
        if (Physics.Raycast(RayPoint.transform.position, RayPoint.transform.forward, out hit, range))
        {
            MuzzleFlash.Play();
            SesKaynak.Play();

            SesKaynak.clip = FireSound;


            if (hit.collider.tag == "zombie")
            {
                GameObject target = hit.collider.gameObject;
                Zombiescript zombiescript = target.GetComponent<Zombiescript>();
                zombiescript.health -= damage;
                Debug.Log("hit" + zombiescript.health);
                if(!zombiescript.scoreCalculated)
                {
                    zombiescript.scoreCalculated = true;
                    ScoreUpdater.GetComponent<ScoreUpdater>().UpdateScore();

                    
                }
            }
        }
    }
}
