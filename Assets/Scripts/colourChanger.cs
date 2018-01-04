using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourChanger : MonoBehaviour {

    GameObject ball;
    public Material white;
    public Material brown;
    public Material blue;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        int colCounter = GameObject.Find("settingHolder").GetComponent<sceneTransition>().colCount;

        if (Input.GetKeyDown("."))
        {
            Next();
        }

        if (Input.GetKeyDown(","))
        {
            Prev();
        }



        ball = this.gameObject;
        if (colCounter == 0)
        {
            ball.GetComponent<Renderer>().material = white;
        }

        else if (colCounter == 1)
        {
            ball.GetComponent<Renderer>().material = brown;
        }

        else if (colCounter == 2)
        {
            ball.GetComponent<Renderer>().material = blue;
        }
    }

    public void Next()
    {
        if (GameObject.Find("settingHolder").GetComponent<sceneTransition>().colCount == 2)
        {
            GameObject.Find("settingHolder").GetComponent<sceneTransition>().colCount = 0;
        }
        else
        {
            GameObject.Find("settingHolder").GetComponent<sceneTransition>().colCount += 1;
        }
    }

    public void Prev()
    {
        if (GameObject.Find("settingHolder").GetComponent<sceneTransition>().colCount == 0)
        {
            GameObject.Find("settingHolder").GetComponent<sceneTransition>().colCount = 2;
        }
        else
        {
            GameObject.Find("settingHolder").GetComponent<sceneTransition>().colCount = GameObject.Find("settingHolder").GetComponent<sceneTransition>().colCount - 1;
        }
    }
}
