using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_menu : MonoBehaviour {

    public Button NewGame;
    public Button Introduction;
    public Button GameExit;
    public Button LOAD;
    private bool check=false;
    private string save;

    void Start()
    {
        
        NewGame.onClick.AddListener(begin);
        LOAD.onClick.AddListener(load);
        Introduction.onClick.AddListener(Introduction_page);
        GameExit.onClick.AddListener(Exit);
        
    }

    private void Exit()
    {   Debug.Log("exit");
        Application.Quit();
    }
    public void load()
    {       
        if (IsSave())
        {
            string[] mm = Regex.Split(GameLoad(), "\\s+", RegexOptions.IgnoreCase);
            SceneManager.LoadScene(mm[0]);
        }
        
    }
    public bool IsSave()
    {

        check = PlayerPrefs.HasKey("Gameload");
        return check;
    }
    private void Introduction_page()
    {
        SceneManager.LoadScene("Introduction_menu");
    }

    private void begin()
    {
        
        SceneManager.LoadScene("Game_map_1");
    }
    public string GameLoad()
    {

        if (check)
        {
            save = PlayerPrefs.GetString("Gameload");
        }
        return save;
    }
}
