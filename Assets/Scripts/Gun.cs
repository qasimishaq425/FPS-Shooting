using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Text bulletText;
    public static Gun gunRef;
    public int pistoldamage = 23, gundamage = 33;
    public float range = 100;
    public Camera camfsp;

    public int gunbullets;
    public int pistolbullets;
    public bool pistol, guns;

    public AudioClip[] audioclip;
    public AudioSource audiosorce;
    public GameObject pistolob, gunobj;
    public Animator gun_animator;
    public ParticleSystem pistolmuzzle, gunmuzzle;

    bool isFiring = false;
    bool stopFire = false;
    public Vector3 originalpos, aimpos;
    public Transform pos;

    float fireRate = .2f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        originalpos = gunobj.transform.localPosition;
        aimpos = originalpos;

        gunRef = this;

    }

   

    // Update is called once per frame
    void Update()
    {
        if (pistolob.activeSelf)
        {
            bulletText.text = pistolbullets.ToString() + " /" + "10";
        }
        if (gunobj.activeSelf)
        {
            bulletText.text = gunbullets.ToString() + " /" + "24";
        }
        
    }

    public void Fire()
    {
        if (pistolob.activeSelf && pistolbullets > 0)
        {
            
            PistolShoot();
        }
        else if (gunobj.activeSelf && gunbullets > 0)
        {
            GunShoot();
        }
    }
    void PistolShoot()
    {
        audiosorce.clip = audioclip[0];
        audiosorce.PlayOneShot(audiosorce.clip);
        pistolmuzzle.Play();

        Shoot(20);
        pistolbullets--;
        bulletText.text = pistolbullets.ToString() + " /" + "10";
       

    }
    void GunShoot()
    {
        if (gunbullets > 0)
        {
            audiosorce.clip = audioclip[1];
            audiosorce.PlayOneShot(audiosorce.clip);
            gunmuzzle.Play();
            Shoot(33);
            gunbullets--;
            bulletText.text = gunbullets.ToString() + " /" + "24";
            Invoke("setGunanim", 0.3f);
        }
    } 
    public void Shoot(int damag)
    {

        RaycastHit hit;
        if (Physics.Raycast(camfsp.transform.position, camfsp.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);
            if (hit.transform.gameObject.tag == "Enemy")
            {
               
                Target.target.TakeDamage(damag);
            }
         }

    }
    public void Relood()

    {
        if (pistolbullets <= 4)
        {

            audiosorce.clip = audioclip[2];
            audiosorce.PlayOneShot(audiosorce.clip);
            pistolbullets = 10;
            bulletText.text = pistolbullets.ToString() + " /" + " 10";
        }
        else if (gunbullets <= 10)
        {

            audiosorce.clip = audioclip[2];
            audiosorce.PlayOneShot(audiosorce.clip);
            gunbullets = 24;
            bulletText.text = gunbullets.ToString() + " /" + "24";
        }
    }
    public void jumped()
    {
        PlayerMovement.movement.Jump();
    }
   

    public void pointerUp()
    {
        
        gun_animator.SetBool("lerp", false);
        CancelInvoke("GunShoot");
    }
    public void pointerDown()
    {

        if (gunbullets > 0)
        {
            gun_animator.SetBool("lerp", true);
            Invoke("fireTrue", 0f);
        }
    }
    void fireTrue()
    {
        
        if(gunobj.activeSelf && gunbullets > 0)
        {
            isFiring = true;
            InvokeRepeating("GunShoot", .001f, fireRate);
        }
    }
   
}

