using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Final : MonoBehaviour
{
    public Text kill;
    public GameObject gObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Kills();
    }
    public void PlayAgain()
    {
        gObject.SetActive(false);
        SceneManager.LoadScene(1);

    }
    public void Home()
    {
        gObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
    void Kills()
    {
        kill.text = PlayerPrefs.GetInt("Kill").ToString();
    }
}
