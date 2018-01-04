using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public Button startButton;
    public Button difficulty;
    // Use this for initialization
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            startButton.gameObject.SetActive(false);
            difficulty.gameObject.SetActive(true);
            //gameObject.active = false; 
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && startButton.gameObject.activeSelf == false)
        {
            SceneManager.LoadScene("scene1b");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && startButton.gameObject.activeSelf == false)
        {
            SceneManager.LoadScene("scene1m");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && startButton.gameObject.activeSelf == false)
        {
            SceneManager.LoadScene("scene1");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("tut1");
        }

    }
    
    public void OnClick()
    {
        Debug.Log("Clicked OnClick");
           // SceneManager.LoadScene("scene1");
    }

}
