using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float currenthealth = 0;
    public float maxhealth=100;
    public Slider healthslider;
    
    // Start is called before the first frame update
    void Start()
    {
       

        currenthealth = maxhealth;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHealth(float damage)
        
    {
        currenthealth = damage;
        healthslider.value = currenthealth;

    }
}
