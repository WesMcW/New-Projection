using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public void StartGame(string s)
    {
       UnityEngine.SceneManagement.SceneManager.LoadScene( s );
    }
}
