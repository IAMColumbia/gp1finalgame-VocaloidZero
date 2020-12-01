using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    //TO DO: Add highscore? Adjust variables.
    public Text ScoreText;

    public static int Score;



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
     public void AddScore(int pointsToAdd)
    {
        Score += pointsToAdd;
    }


}