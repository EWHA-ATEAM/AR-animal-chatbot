using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void goToGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
