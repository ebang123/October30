using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timerscript2 : MonoBehaviour
{

    Image timerBar;
    public float maxTime = 5f;
    public float max1Time = 4f;
    public float max2Time = 3f;
    public int CurrentScore;
    float timeLeft;
    float time1Left;
    float time2Left;
    public GameObject Timesuptext;
    [SerializeField]
    public InputField input;
    [SerializeField]
    private GameObject yesbtn;
    [SerializeField]
    private GameObject nobtn;
    [SerializeField]
    public Text text;
    [SerializeField]
    public Text Currentscoretext;

    // Use this for initialization
    public void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
       

    }

    // Update is called once per frame
    public void Update()
    {
        int.TryParse(Currentscoretext.text, out CurrentScore);
        if (CurrentScore >= 0)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timerBar.fillAmount = timeLeft / maxTime;
            }
            else
            {
                text.fontSize = 50;
                text.text = "Do you still want to play the game?";
                Timesuptext.SetActive(true);
                input.enabled = false;
                yesbtn.SetActive(true);
                nobtn.SetActive(true);
            }
        }
        
        }
    }
