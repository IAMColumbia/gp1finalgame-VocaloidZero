using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneHandler : MonoBehaviour
{
    [SerializeField] private GameObject restartGame = null;
    private ScoreManager sm;
    //public bool timerActive;
    void Start()
    {
        sm = GetComponent<ScoreManager>();
        restartGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetScene()
    {
        //Want the scene to reset to the bottom of the screen if the player has fallen off the bottom screen.

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //sm.timerActive = true;
    }

    public void EnableButton()
    {
        restartGame.SetActive(true);
    }
}