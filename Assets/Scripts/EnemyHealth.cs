using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int currenthealth = 0;
    public int maxhealth = 100;
    // public Slider healthslider;
    //public Animator anim;

    void Start()
    {
        currenthealth = maxhealth;
        // healthslider.value = 100;
      //  anim.SetBool("attack", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHealth(int damage)

    {
        currenthealth = currenthealth-damage;
        Debug.Log(currenthealth);
    

    }
    public void DestroyEnemy()
    {
        
        gameObject.SetActive(false);
       
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
