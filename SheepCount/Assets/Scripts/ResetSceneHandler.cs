using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneHandler : MonoBehaviour
{
    private Scene restartGame;

    void Start()
    {
        restartGame = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetScene()
    {
        //Want the scene to reset to the bottom of the screen if the player has fallen off the bottom screen.

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }



}