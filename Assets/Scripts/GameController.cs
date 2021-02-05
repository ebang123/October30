using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    private static string[] NeutralList = 
    { "B A S I C", "U N O", "D O S", "T R E S", "E N T R E P", "E T H I C S", "B E E", "S U B J E C T", "C A T", "D O G",
      "C E T O F F I C E", "R E G U L A R", "F R E S H", "G O O D", "C O W", "L I P S T I C K", "C O U R S E", "T U R T L E",
     "P A S S", "4 M", "G V 3 0 7", "C A N T E E N", "G E", "U N I F O R M", "S H O E S", "S O C K S", "W O R D"};
    private static string[] NegativeList = 
    { "H A R D", "M A D N E S S", "H E L L", "S L E E P L E S S", "M U R D E R E D", "I M P A T I E N T","S I N G K O",
    "A G O N Y", "V I O L E N T", "F U R I O U S", "B R U T A L", "I R R E G", "T O U G H","F A I L E D",
    "B R E A K", "B U S Y", "D R A I N E D", "H A R S H", "C R I T I C A L", "C R A M", "C R A Z Y","5 . 0",
    "D I S A S T E R", "A L L - O U T", "F A I L E D", "I N T E N S E", "D R O P P E D", "T R U S T", "S I N G K O",
    "D S P", "N U M E T H S", "D E S P R O","S A D","E L E C S","F T S","A D M A T H","S T R E - M A", "C O M P R O G 2"};
    private static Color[] colors = { Color.white, Color.gray, Color.green, Color.red, Color.yellow, Color.blue, Color.magenta };
    private int randomColorIndex;
    private int countScore;
    private int highScore;
    private string randomPositivename;
    private string randomNegativename;
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
    public Timerscript Timer;
    public GameObject Timesuptext;
    public static string PreviousScene = "";
    string stringEdit = "";
    void Awake()
    {
        countScore = 0;
        highScore = PlayerPrefs.GetInt("highscore", highScore);
        Highscoretext.text = "HIGH SCORE" + "\n" + highScore.ToString();
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
            countScore++;
            Currentscoretext.text = countScore.ToString();
            PlayAgain();
        }
        else
        {
            Timer.enabled = false;
            text.fontSize = 50;
            text.text = " The correct answer is " + currentColor + "\n" +" Do you want to play again?";
            if (countScore >= highScore)
            {
                highScore = countScore;
                Highscoretext.text = "HIGH SCORE" + "\n" + countScore;
                PlayerPrefs.SetInt("highscore", highScore);
                Timer.Start();
            }
            countScore = 0;
            yesbtn.SetActive(true);
            nobtn.SetActive(true);
        }
    }
    public void PlayAgain()
    {
        Currentscoretext.text = countScore.ToString();
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
        if (countScore % 2 == 0)
        {
            int randomIndex0 = Random.Range(0, NeutralList.Length);
            randomPositivename = NeutralList[randomIndex0];
            text.text = randomPositivename;
            text.fontSize = 102;
        }
        if (countScore % 2 == 1){
        int randomIndex1 = Random.Range(0, NegativeList.Length);
        randomNegativename = NegativeList[randomIndex1];
        text.text = randomNegativename;
        text.fontSize = 102;
        } 
    }
    void SetRandomColor()
    {
        int index = Random.Range(0, 8);
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