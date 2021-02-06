using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void nextLevel()
    {
        int _currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(_currentScene + 1);
    }
    public void tryAgain()
    {
        int _currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(_currentScene);
    }
}
