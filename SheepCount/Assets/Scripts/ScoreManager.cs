using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance { get; private set; }
    public static int Score;


    public Text ScoreText;

    Vector2 scoreLoc, livesLoc, levelLoc;

    private static void SetupNewGame()
    {
        Score = 0;
    }



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }

        ScoreManager.SetupNewGame();

    }

    // Use this for initialization
    void Start()
    {
        ScoreText.text = "Score: " + ScoreManager.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        ScoreText.text = "Score: " + ScoreManager.Score.ToString();

       // EndConditions();

    }

    //public void ClockStart()
    //{

    //    if (this.timerActive == true)
    //    {
    //        Time.timeScale = 1f;
    //        currentTime -= 1 * Time.deltaTime;

    //    }
    //    if (this.timerActive == false)
    //    {

    //        Time.timeScale = 0f;
    //    }
    //}


    private void Lose()
    {
       
    }

    public void Win()
    {
       

    }


}