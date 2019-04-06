using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScene : MonoBehaviour
{
   

    // Update is called once per frame
    public void ClickToRestartScene()
    {
        SceneManager.LoadScene("DartsGameARBuild");

    }
}
