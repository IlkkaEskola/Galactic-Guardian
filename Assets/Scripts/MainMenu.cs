using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public InputField playerNameInput;
    public static string playerName;

    public void StartGame()
    {
        playerName = playerNameInput.text;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
