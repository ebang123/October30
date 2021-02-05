using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController2 : MonoBehaviour
{
    private static string[] WordList = { "RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "VIOLET", "PINK", "WHITE", "GRAY" };
    private static Color[] colors = { Color.white, Color.gray, Color.green, Color.red, Color.yellow, Color.blue, Color.magenta };
    private int randomColorIndex;
    private int countScore2;
    private int highScore2;
    private string randomWord;
    public string currentColor;
    public Color colorYellow;
    public Color colorViolet;
    public Color colorPink;
    public Color colorGreen;
    public Color colorWhite;
    public Color colorBlue;
    public Color colorGray;
    public Color colorRed;
    public Color colorOrange;
    [SerializeField]
    private GameObject yesbtn;
    [SerializeField]
    private GameObject nobtn;
    [SerializeField]
    public InputField input;
    [SerializeField]
    public Text text;
    [SerializeField]
    public Text text1;
    [SerializeField]
    public Text Highscoretext;
    [SerializeField]
    public Text Currentscoretext;
    [SerializeField]
    public Text ColorInst;
    [SerializeField]
    public Text WordInst;
    public Timerscript2 Timer;
    public GameObject Timesuptext;
    public static string PreviousScene = "";
    string stringEdit = "";
    void Awake()
    {
        countScore2 = 0;
        highScore2 = PlayerPrefs.GetInt("highscore", highScore2);
        Highscoretext.text = "HIGH SCORE" + "\n" + highScore2.ToString();
        randomColorIndex = Random.Range(0, colors.Length);
        text1.color = colors[randomColorIndex];
        SetRandomText();
        SetRandomColor();
        input.Select();
        input.ActivateInputField();
        input.characterLimit = 6;
    }
    public void OnEditting()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
        {
            stringEdit = input.text;
        }
    }

    public void OnEndEdit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            input.text = stringEdit;
        }
    }
    public void GetInput(string answer)
    {
        CompareAnswer(answer);
        input.text = "";

    }
    public void CompareAnswer(string answer)
    {
        answer = answer.ToUpper();
        answer = answer.Replace(" ", "");
        if (answer == currentColor)
        {
            countScore2++;
            Currentscoretext.text = countScore2.ToString();
            PlayAgain();
        }
        else
        {
            Timer.enabled = false;
            text.fontSize = 80;
            text.text = " The correct answer is " + currentColor + "\n" + " Do you want to play again?";
            if (countScore2 >= highScore2)
            {
                highScore2 = countScore2;
                Highscoretext.text = "HIGH SCORE" + "\n" + countScore2;
                PlayerPrefs.SetInt("highscore", highScore2);
                Timer.Start();
            }
            countScore2 = 0;
            yesbtn.SetActive(true);
            nobtn.SetActive(true);
        }
    }
    public void PlayAgain()
    {
        Currentscoretext.text = countScore2.ToString();
        input.enabled = true;
        Timer.enabled = true;
        Timesuptext.SetActive(false);
        Timer.Start();
        yesbtn.SetActive(false);
        nobtn.SetActive(false);
        randomColorIndex = Random.Range(0, colors.Length);
        text1.color = colors[randomColorIndex];
        SetRandomText();
        SetRandomColor();
        input.ActivateInputField();
        input.Select();
        input.characterLimit = 6;
    }
    void SetRandomText()
    {
        int randomIndex0 = Random.Range(0, WordList.Length);
        randomWord = WordList[randomIndex0];
        text.text = randomWord;
        text.fontSize = 80;

    }
    void SetRandomColor()
    {
        int index = Random.Range(0, 9);
        switch (index)
        {
            case 0:
                currentColor = "GRAY";
                text.color = colorGray;
                break;
            case 1:
                currentColor = "YELLOW";
                text.color = colorYellow;
                break;
            case 2:
                currentColor = "VIOLET";
                text.color = colorViolet;
                break;
            case 3:
                currentColor = "PINK";
                text.color = colorPink;
                break;
            case 4:
                currentColor = "RED";
                text.color = colorRed;
                break;
            case 5:
                currentColor = "BLUE";
                text.color = colorBlue;
                break;
            case 6:
                currentColor = "WHITE";
                text.color = colorWhite;
                break;
            case 7:
                currentColor = "GREEN";
                text.color = colorGreen;
                break;
            case 8:
                currentColor = "ORANGE";
                text.color = colorOrange;
                break;
        }
    }
    public void MainMenu(string Main)
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Main");
    }
}