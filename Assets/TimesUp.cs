using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class TimesUp : MonoBehaviour
{


    [SerializeField]
    private Button PlayAgain;
    [SerializeField]
    private Button ReturnHome;
    [SerializeField]
    private Text yourscore;
    [SerializeField]
    private Text levelscore;

    public static int lastscore;

    public void loadlevel()
    {
        GameManager.score = 0;
        GameManager.timer = 10;
        SceneManager.LoadScene(2);
       
    }

    public void returnhome()
    {
        GameManager.score = 0;
        GameManager.timer = 10;
        SceneManager.LoadScene(0);
    }



    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.score == 0 )
        {
            levelscore.text = "Retention level: 0, Better Try Again! ";
        }

        if (GameManager.score >= 1 && GameManager.score <= 2)
        {
            levelscore.text = "Retention level: 1, Doing good! ";
        }


        if (GameManager.score >= 3 && GameManager.score <= 5)
        {
            levelscore.text = "Retention level: 2, You did great! ";
        }

        if (GameManager.score >= 6 && GameManager.score <= 8)
        {
            levelscore.text = "Retention level: 3, Excellent!";
        }
        if (GameManager.score >= 8 && GameManager.score <= 10)
        {
            levelscore.text = "Retention level: 4, Wow!";
        }


        yourscore.text = "YOUR SCORE: " + lastscore;

    }
}