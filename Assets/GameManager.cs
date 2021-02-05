using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Question[] questions;

    private static List<Question> unansweredquestions;
    private Question currentQuestion;
    private Sprite spriteui;

    [SerializeField]
    private Image m_image;
    [SerializeField]
    private Text trueAnswerText;
    [SerializeField]
    private Text falseAnswerText;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float timebetweenQuestions = 0f;
    [SerializeField]
    public static int score;
    [SerializeField]
    public Text scoreText;
    [SerializeField]
    public static int timer = 10;
    [SerializeField]
    public Text timertext;
    [SerializeField]
    public Button TrueButton;
    [SerializeField]
    public Button FalseButton;

    public static int originalscore;

    void Start()
    {
        StartCoroutine(TimeLeft());
        UpdateScore();
        UpdateTimer();
        if (unansweredquestions == null || unansweredquestions.Count == 0)
        {
            unansweredquestions = questions.ToList<Question>();
        }
        GetCurrentQuestion();
    }

//////////////TIMER SECTION//////////////
    IEnumerator TimeLeft()
    {
    while(true)
        {
            
            yield return new WaitForSeconds(1f);
            timer--;
            UpdateTimer();
            TimersUp();

        }
    }

    void UpdateTimer()
    {
        timertext.text = "TIME LEFT: " + timer;
    }

    public void TimersUp()
    {
        if (timer <= 0)
        {
            timertext.text = "0";
            StopCoroutine(TimeLeft());
            SceneManager.LoadScene(3);

            TimesUp.lastscore = score;
        }
    }

//////////////SCORING SECTION//////////////
    public void AddScore(int newScore)
    {
        score += newScore;
        originalscore=score;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "SCORE: " + score;
    }

   
    //////////////GAME SETTINGS SECTION//////////////

    public void BtnOnClick(){
        TrueButton.interactable = false;
        FalseButton.interactable = false;
    }

    void GetCurrentQuestion()
    {
        
        int randomQuestionIndex = Random.Range(0, unansweredquestions.Count);
        currentQuestion = unansweredquestions[randomQuestionIndex];

        spriteui = currentQuestion.sprite;
        m_image.sprite = spriteui;

        unansweredquestions.RemoveAt(randomQuestionIndex);

        if (currentQuestion.isTrue)
        {
          
            trueAnswerText.text = "Correct!";
            falseAnswerText.text = "Wrong!";
        }
        else
        {
            trueAnswerText.text = "Wrong!";
            falseAnswerText.text = "Correct!";
        }
    }

    IEnumerator TransitionToTextQuestion()
    {
        unansweredquestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timebetweenQuestions);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UserSelectTrue()
    {
        animator.SetTrigger("True");
        animator.speed = 3f;
        if (currentQuestion.isTrue)
        { 
            AddScore(1);
            Debug.Log("Correct");
            BtnOnClick();
            StartCoroutine(TransitionToTextQuestion());
        }
        else
        {
            Debug.Log("False");
            BtnOnClick();
            StartCoroutine(TransitionToTextQuestion());
        }
    }

    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        animator.speed = 3f;
        if (!currentQuestion.isTrue)
        {
            AddScore(1);
            Debug.Log("Correct");
            StartCoroutine(TransitionToTextQuestion());
            BtnOnClick();
        }
        else
        {
            Debug.Log("False");
            StartCoroutine(TransitionToTextQuestion());
            BtnOnClick();
        }
    }

}
