using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switching : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject[] weapon;
    int i = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Switch()
    {

       
        if (i == 0)
        {
            
            weapon[i].SetActive(false);
            i++;
            weapon[i].SetActive(true);
           
        }
        else
        {
          
            weapon[i].SetActive(false);
            i--;
            weapon[i].SetActive(true);
           
        }


    }

    
    }

