using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeadManager : MonoBehaviour
{

    GameObject scoreText;

    GameObject accuracyText;


     InputAction restartAction;
     InputAction quitAction;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score");
        accuracyText = GameObject.FindGameObjectWithTag("Health");

        scoreText.GetComponent<TextMeshProUGUI>().SetText("Final Score: " + GameManager.GM.score);
        accuracyText.GetComponent<TextMeshProUGUI>().SetText("Accuracy: " + GameManager.GM.accuracy);

        restartAction = InputSystem.actions.FindAction("Restart");
        quitAction = InputSystem.actions.FindAction("Quit");

        

    }

    private void quit(){
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if(restartAction.IsPressed()){
            GameManager.GM.alive();
        }
        else if(quitAction.IsPressed()){
            quit();
        }
    }
}
