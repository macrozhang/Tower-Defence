using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_m2 : MonoBehaviour
{
    public int Hp;

    public void Update()
    {

        if (Hp <= 0)
        {
            Text Gold = GameObject.Find("Canvas/PrintGold").GetComponent<Text>();
            Gold.text = (int.Parse(Gold.text) + 1).ToString();
            Text enemy = GameObject.Find("Canvas/PrintEnemy").GetComponent<Text>();
            enemy.text = (int.Parse(enemy.text) - 1).ToString();
            Destroy(gameObject);
        }
        if (gameObject.transform.position.z < -12 && gameObject.transform.position.x < -18)
        {

            Text HP = GameObject.Find("Canvas/PrintHP").GetComponent<Text>();
            HP.text = (int.Parse(HP.text) - 1).ToString();
            Text enemy = GameObject.Find("Canvas/PrintEnemy").GetComponent<Text>();
            enemy.text = (int.Parse(enemy.text) - 1).ToString();
            Destroy(gameObject);
        }
    }

    public float getHP()
    {
        return Hp;
    }

    public void modifHP(int dmg)
    {
        Hp -= dmg;
    }
}
