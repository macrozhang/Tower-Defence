using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map1 : MonoBehaviour {
    public Text HP;
    public Text Enemy;
    public Text Gold;
    public Button Exit;
    public GameObject lostgame; 
    void Start()
    {   
        Exit.onClick.AddListener(mainmenu);
        Cursor.visible = true;
        HP.text = "5";
        Enemy.text = "18";
        Gold.text="10";
    }

    public void Update()
    {
        //pass
        if (int.Parse(Enemy.text) == 0)
        {
            //通过，储存，进下一关
            GameSave("Game_map_2");
            SceneManager.LoadScene("Game_map_2");
        }
        //failed
        if (int.Parse(HP.text) == 0)
        {
            //游戏结束，重新开始或者退出
            Debug.Log("game over");
            SceneManager.LoadScene("Start_menu");
        }
    }

    public void GameSave(string s)
    {
        string save;

        save = s + " " + DateTime.Now.ToLocalTime().ToString();

        PlayerPrefs.SetString("Gameload", save);
    }

    private void mainmenu()
    {
        SceneManager.LoadScene("Start_menu");
        
    }


    public void decreaseGold(int price)
    {   if((int.Parse(Gold.text) - price) > 0)
        {
            Gold.text = (int.Parse(Gold.text) - price).ToString();
        }
        else
        {
            Debug.Log("Your gold is not enough!!!");
        }
    }


    public void sell_Gold(int sell)
    {
        Gold.text = (int.Parse(Gold.text) + sell).ToString();
    }

}
