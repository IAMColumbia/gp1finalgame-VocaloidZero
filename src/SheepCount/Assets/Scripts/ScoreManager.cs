using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public Text ScoreText;
    public int Score;


    private  void SetupNewGame()
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

        SetupNewGame();

    }

    // Use this for initialization
    void Start()
    {
        ScoreText.text = "Score: " + Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        ScoreText.text = "Score: " + Score.ToString();


    }
     public void AddScore(int pointsToAdd)
    {
        Score += pointsToAdd;
    }


}