using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public GameObject gObject;
   
    // Start is called before the first frame update
    void Start()
    {
        // StopAllCoroutines();
        //  Debug.Log("Anim Play");
        // StartCoroutine(enableButtonafter());
        // Invoke("enableButton", 5f);
        enableButton();

    }
    public void enableButton()
    {
        if (!gObject.activeSelf)
        {
            gObject.SetActive(true);
            gObject.GetComponent<Animator>().enabled = true;
            gObject.GetComponent<Animator>().Play("playbutton");
            
        }
    }
    IEnumerator enableButtonafter()
    {
        yield return new WaitForSeconds(3f);
        enableButton();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   public void Play()
    {
       // gObject.SetActive(false);
        SceneManager.LoadScene(1);

    }
}
