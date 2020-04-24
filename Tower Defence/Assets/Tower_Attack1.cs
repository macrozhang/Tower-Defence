using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Tower_Attack1 : MonoBehaviour
{   [HideInInspector]
    public List<GameObject> enemy; //which can be attack
    private GameObject targetObject;//攻击目标
    private float dis;
    private Transform head;//可旋转部位
    private float attack_CD;
    private GameObject bulletPrefab;
    private Transform firePos;
    public int att=1;
    private int att1=1;
    void Start()
    {
        attack_CD = 2;
        dis = 8;
        enemy = new List<GameObject>();
        targetObject = null;
        head = transform.GetChild(1);
        firePos = head.GetChild(0);
        bulletPrefab = Resources.Load<GameObject>("bullet1");
    }


    void Update()
    {
        
        //Debug.Log(enemy.Count);
         if (enemy.Count > 0)
         {
             if (targetObject == null)
             { 
                 //choose target
                 targetObject= SelectTarget();
             }
         }
         //attack
         if (targetObject != null)
         {
             LookTarget();
            //Debug.Log(att+":1");
             if (att == 0)
             {
                 Destroy(targetObject);
                 enemy.Remove(targetObject);
                //decrease enemy
                 Text enemy1 = GameObject.Find("Canvas/PrintEnemy").GetComponent<Text>();
                 enemy1.text = (int.Parse(enemy1.text) - 1).ToString();
                //increase gold
                 Text Gold = GameObject.Find("Canvas/PrintGold").GetComponent<Text>();
                 Gold.text = (int.Parse(Gold.text) + 1).ToString();
                 att = att1;
         }

        }
    }
    public void datt()
    {
        att -= 1;
    }
    //Check is monster into attack range?
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (!enemy.Contains(other.gameObject))
            {                
                enemy.Add(other.gameObject); 
            }
        }

    }

    //check is monster leave attack range
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            
            if (targetObject != null && other.name == targetObject.name)
            {
                    targetObject = null;
            }
            if (enemy.Contains(other.gameObject))
            {              
                enemy.Remove(other.gameObject);
            }
            
        }
    }

    private GameObject SelectTarget()
    {
        GameObject temp = null;
        float distance = 0;
        //use loop to find min distance between tower and enemy
        for (int i = 0; i < enemy.Count; i++)
        {   
            if (enemy[i]!= null)
            {          
                distance = Vector3.Distance(transform.position, enemy[i].transform.position);
                if (distance <= dis)
                {
                    dis = distance;
                    temp = enemy[i];
                }
            }           
        }
        return temp;
    }

    private void LookTarget()
    {
        Vector3 pos = targetObject.transform.position;        
        pos.y = head.position.y;//to make sure it will not look up or down    
        head.LookAt(pos);//follow enemies Rotate
        attack_CD += Time.deltaTime;
        if (attack_CD >= 2)//1s cd
        {
            //Attack
            attack_CD = 0;
            Attack();
        }
    }

    private void Attack()
    {
        GameObject bullets = Instantiate(bulletPrefab, firePos.position,Quaternion.identity);
        //add bullet script
        bullets.AddComponent<BulletMove1>().target=targetObject;
        bullets.transform.LookAt(targetObject.transform.position);

        bullets.GetComponent<BulletMove1>().scripts = gameObject.GetComponent<TowerContribute>();
        bullets.GetComponent<BulletMove1>().scripts1 = targetObject.GetComponent<Enemy>();
        bullets.GetComponent<BulletMove1>().attack1 = this;
    }
}
