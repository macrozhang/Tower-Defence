using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Tower_Attack5 : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> enemy; //which can be attack
    private GameObject targetObject;//攻击目标
    private float dis;
    private Transform head;//可旋转部位
    private float attack_CD;
    private GameObject bulletPrefab;
    private Transform firePos;
    public int att = 2;
    void Start()
    {
        attack_CD = 0;
        dis = 100;
        enemy = new List<GameObject>();
        targetObject = null;
        head = transform.GetChild(1);
        firePos = head.GetChild(0);
        bulletPrefab = Resources.Load<GameObject>("bullet1");
    }


    void Update()
    {
    

    }

    //Check is monster into attack range?
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {

            if (!enemy.Contains(other.gameObject))
            {
                enemy.Add(other.gameObject);
                other.gameObject.GetComponent<NavMeshAgent>().speed-=1;
            }
        }

    }

    //check is monster leave attack range
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {

            if (enemy.Contains(other.gameObject))
            {
                other.gameObject.GetComponent<NavMeshAgent>().speed += 1;
                enemy.Remove(other.gameObject);
            }

        }
    }

    
}
