using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;
    public Text quitText;
    public Text pauseText;

    private int level;
    private Rigidbody rb;
    private int count;
    public int win;
    public bool isPause = false;
    public bool isQuit = false;

    void Start()
    {

        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().buildIndex >= 6 && SceneManager.GetActiveScene().buildIndex < 10)
        {
            level = SceneManager.GetActiveScene().buildIndex - 4;
        }
        else if (SceneManager.GetActiveScene().buildIndex >= 10 && SceneManager.GetActiveScene().buildIndex < 14)
        {
            level = SceneManager.GetActiveScene().buildIndex - 8;
        }
        else if (SceneManager.GetActiveScene().buildIndex >= 14)
        {
            level = SceneManager.GetActiveScene().buildIndex - 12;
        }
        else
        {
            level = SceneManager.GetActiveScene().buildIndex + 1;
        }
        
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            if(winText.text == "You Win! \n Press 'Enter' To Go To Level " + level)
            {
                winText.text = "";
                loseText.text = "You lost after you won\nWhat's wrong with you\nPress 'R' to play again";
            }
            else
            {
                loseText.text = "YOU LOSE! \n Press 'R' To Play Again";
            }
            
        }
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("LockedDoor").SetActive(false);
        }
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Out"))
        {
            if (winText.text == "You Win! \n Press 'Enter' To Go To Level " + level)
            {
                winText.text = "";
                loseText.text = "You lost after you won\nWhat's wrong with you\nPress 'R' to play again";
            }
            else
            {
                loseText.text = "YOU LOSE! \n Press 'R' To Play Again";
            }

        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= win)
        {
            if (level == 5)
            {
                SceneManager.LoadScene("EndScene");
            }
            else if (SceneManager.GetActiveScene().buildIndex == 16)
            {
                winText.text = "Press 'Enter' To Go\nTo The Main Menu";
            }
            else
            {
                winText.text = "You Win! \n Press 'Enter' To Go To Level " + level;
            }



        }
    }
    void Update()
    {
        if (loseText.text == "YOU LOSE! \n Press 'R' To Play Again")
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (winText.text == "You Win! \n Press 'Enter' To Go To Level " + level)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (winText.text == "Press 'Enter' To Go\nTo The Main Menu")
            {
                SceneManager.LoadScene(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            if (loseText.text == "YOU LOSE! \n Press 'R' To Play Again")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (loseText.text == "You lost after you won\nWhat's wrong with you\nPress 'R' to play again")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
        if (Input.GetKeyDown(KeyCode.Q) && pauseText.text == "")
        {
            quitText.text = "Are you sure you want to quit?\nPress (Y/N)";
            Time.timeScale = 0;
            //Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Y) && quitText.text == "Are you sure you want to quit?\nPress (Y/N)")
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.N) && quitText.text == "Are you sure you want to quit?\nPress (Y/N)")
        {
            quitText.text = "";
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.P) && quitText.text == "")
        {
            isPause = !isPause;
            if (isPause)
            {
                pauseText.text = "The Game Is\nPaused\nPress P To Return";
                Time.timeScale = 0;
            }
            else
            {
                pauseText.text = "";
                Time.timeScale = 1;
            }
        }

    }
    /**
     *         
     *  if (Input.GetKeyDown(KeyCode.Q))
        {
            isQuit = !isQuit;
            if (isQuit)
            {
                quitText.text = "Are You Sure\nYou Want To Quit?\n(Y / N)";
                Time.timeScale = 0;

                if (Input.GetKeyDown(KeyCode.Y) && quitText.text == "Are You Sure\nYou Want To Quit?\n(Y / N)")
                {
                    quitText.text = "quicked y";
                    Application.Quit();
                }
                else if (Input.GetKeyDown(KeyCode.N) && quitText.text == "Are You Sure\nYou Want To Quit?\n(Y / N)")
                {
                    quitText.text = "";

                }
                

            }

            else
            {
                quitText.text = "";
                Time.timeScale = 1;
            }

        }
     */
}