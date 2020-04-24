using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;

/// <summary>
/// 敌人脚本
/// </summary>
public class Enemy : MonoBehaviour
{
    public int way;
    public float x;
    public float z;

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
        


        switch (way)
        {
            case 1:

                if (gameObject.transform.position.z < z && gameObject.transform.position.x < x)
                {

                    Text HP = GameObject.Find("Canvas/PrintHP").GetComponent<Text>();
                    HP.text = (int.Parse(HP.text) - 1).ToString();
                    Text enemy = GameObject.Find("Canvas/PrintEnemy").GetComponent<Text>();
                    enemy.text = (int.Parse(enemy.text) - 1).ToString();
                    Destroy(gameObject);
                }
                break;
            case 2:

                if (gameObject.transform.position.z > 0 && gameObject.transform.position.z <4 && gameObject.transform.position.x > 2.3 && gameObject.transform.position.x < 10)
                {

                    Text HP = GameObject.Find("Canvas/PrintHP").GetComponent<Text>();
                    HP.text = (int.Parse(HP.text) - 1).ToString();
                    Text enemy = GameObject.Find("Canvas/PrintEnemy").GetComponent<Text>();
                    enemy.text = (int.Parse(enemy.text) - 1).ToString();
                    Destroy(gameObject);
                }
                break;
            case 4:

                if (gameObject.transform.position.z > z && gameObject.transform.position.x > x)
                {
                    
                    Text HP = GameObject.Find("Canvas/PrintHP").GetComponent<Text>();
                    HP.text = (int.Parse(HP.text) - 1).ToString();
                    Text enemy = GameObject.Find("Canvas/PrintEnemy").GetComponent<Text>();
                    enemy.text = (int.Parse(enemy.text) - 1).ToString();
                    Destroy(gameObject);
                }
                break;
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

