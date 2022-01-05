using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public static Target target;
    public GameObject gameobject,page;
    public  EnemyHealth currentEnemy;
    public Slider enemyslider,playerslider;
    public ParticleSystem bloddeffect;
    public Animator anim;
    int killnum = 0;
    public Text kill;
    public float minimum_dis;
   
    
    void Start()
    {
        


        playerslider.value = 100;
        Recreate();
       
        target = this;
        
    }
    void Update()
    {
       
        if (minimum_dis>3)
        {
            EndAnim();
        }
    }
   
    public void TakeDamage(int amount)
    {

        Debug.Log("Enemy hit");
         currentEnemy.SetHealth(amount);
        enemyslider.value -= amount;

        if (currentEnemy.currenthealth < 0)
        {
            EndAnim();
            killnum +=1;
            currentEnemy.DestroyEnemy();
            kill.text = killnum.ToString();
            Invoke("Recreate", 3);
        }

    }
    public void Recreate()
    {
        Debug.Log("Instantiate");
       GameObject cloneobject=Instantiate(gameobject, gameobject.transform.position, gameobject.transform.rotation);
       currentEnemy = cloneobject.GetComponent<EnemyHealth>();
        enemyslider.value = 100;
      
       
    }
    public void Playerhealth()
    {

        playerslider.value -=20*Time.deltaTime;
        anim.SetBool("Blood", true);



        if (playerslider.value <= 0)
        {
            PlayerPrefs.SetInt("Kill", killnum);
            page.SetActive(true);
            Time.timeScale = 0;
        }


    }
    public void EndAnim()
    {
        anim.SetBool("Blood", false);
    }
    



}


