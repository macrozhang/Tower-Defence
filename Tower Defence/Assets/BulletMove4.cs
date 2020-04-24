using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BulletMove4 : MonoBehaviour
{
    public GameObject target = null;
    private float times;
    public TowerContribute scripts = null;
    public Enemy scripts1 = null;
    public Tower_Attack4 attack1;
    void Start()
    {
        times = 0;
    }

    void Update()
    {
        times += Time.deltaTime;
        if (times <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * 20);

        Attack();
    }

    private void Attack()
    {
        if (target != null)
        {
            //Debug.Log(Vector3.Distance(transform.position, target.transform.position));
            if (Vector3.Distance(transform.position, target.transform.position) < 1f) //if bullet and target close less than 0.5f
            {
                switch (SceneManager.GetActiveScene().name)
                {
                    case "Game_map_6":
                        if ((attack1.gameObject.transform.position - target.transform.position).z > 0)
                        {
                            target.transform.position = attack1.gameObject.transform.position + (attack1.gameObject.transform.position - target.transform.position) / 2;
                            if (target.transform.position.x < 10)
                            {
                                attack1.enemy.Remove(scripts1.gameObject);
                                Destroy(target);
                                Destroy(gameObject);
                            }
                        }
                        else
                        {
                            target.transform.position = attack1.gameObject.transform.position + (attack1.gameObject.transform.position - target.transform.position) / 2;
                            if (target.transform.position.x > -2)
                            {
                                attack1.enemy.Remove(scripts1.gameObject);
                                Destroy(target);
                                Destroy(gameObject);
                            }
                        }
                        break;
                    case "Game_map_7":

                            target.transform.position = attack1.gameObject.transform.position + (attack1.gameObject.transform.position - target.transform.position)/2;
                            if (target.transform.position.z < 4&& target.transform.position.z >0&& target.transform.position.x > -4&& target.transform.position.z < 0)
                            {
                                attack1.enemy.Remove(scripts1.gameObject);
                                Destroy(target);
                                Destroy(gameObject);
                            }
                        
                        break;
                    case "Game_map_8":
                        
                            target.transform.position = attack1.gameObject.transform.position + (attack1.gameObject.transform.position - target.transform.position) / 2;
                            if (target.transform.position.z < 0 && target.transform.position.z > -4 && target.transform.position.x > 4 && target.transform.position.z < 8)
                            {
                                attack1.enemy.Remove(scripts1.gameObject);
                                Destroy(target);
                                Destroy(gameObject);
                            }
                        
                        break;
                }


                
            }
        }
        else
        {
            //destroy it self if no one to attack
            Destroy(gameObject);
        }
    }
}
