using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Completed
{
    public class PauseScript : MonoBehaviour
    {

        public static bool isPause = false;
        public GameObject mainUI;
        public GameObject pauseMenuUI;
        public GameObject startMenuUI;
        public GameObject actualLevel;
        public Button pauseButton;
        public int level;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPause)
                {
                    Resume();
                    Debug.Log("Resume");
                    return;
                }
                else
                {
                    Pause();
                    Debug.Log("Pause");
                    return;
                }

            }
        }

        public void RestartGame(int level)
        {
            level = GameManager.instance.level;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            startMenuUI.SetActive(true);
            mainUI.SetActive(false);
            actualLevel.SetActive(false);            
        }

        public void OnClick()
        {
            if (isPause)
            {
                Resume();
                Debug.Log("yo mama gay");
            }
            else
            {
                Pause();
            }
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            mainUI.SetActive(true);
            Time.timeScale = 1f;
            isPause = false;
        }

        void Pause()
        {
            mainUI.SetActive(false);
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            isPause = true;
        }

        /*public void LoadMenu(){
            Time.timeScale = 1f;
            Debug.Log("Load menu");
            SceneManager.LoadScene ("Menu");
        }*/

    }
}