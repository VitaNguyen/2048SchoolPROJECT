using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Button Play;
    public Button LevelUp;
    public Button Exit;

    private void Start()
    {
        Play.onClick.AddListener(() => { SceneManager.LoadScene("Main"); });
        LevelUp.onClick.AddListener(() => { SceneManager.LoadScene("LevelUp"); });
        Exit.onClick.AddListener(() => { Application.Quit(); });
    }

}
