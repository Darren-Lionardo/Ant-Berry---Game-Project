using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class homeManager : MonoBehaviour
{
    public void onClickStart(){
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void onClickExit(){
        Application.Quit();
    }
}
