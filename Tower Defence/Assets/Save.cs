using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //查看有没有存档
    public bool IfSave() {
        bool check = false;
        check = PlayerPrefs.HasKey("Gameload");
        return IfSave;
    }

    //存档，s为当前关卡数
    public void GameSave(string s) {
        string save;

        save = s + " " + DateTime.Now.ToLocalTime().ToString();

        PlayerPrefs.SetString("Gameload", save);
    }

    //读取存档地图
    public string GameLoad() {
        string save;
        if (IfSave) {
            save = PlayerPrefs.GetString("Gameload");
        }
        return save;
    }
}
