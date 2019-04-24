using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame( int index )
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame( )
    {
        Debug.Log("You Have Quit The Game");
        Application.Quit();
    }

}
