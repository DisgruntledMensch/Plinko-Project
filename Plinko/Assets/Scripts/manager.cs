using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class manager : MonoBehaviour
{

    [SerializeField]
    int victoryScore = 1000;
    public GameObject Score;
    public GameObject Victory;
    public GameObject Ball;
    public int getScore;
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
          }

        if (getScore >= victoryScore)
        {
            Score.SetActive(false);
            Victory.SetActive(true);
            Destroy(Ball);
            //Display victory screen and prompt for restart
            if (Victory.activeSelf && Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


    }
}
        
   
