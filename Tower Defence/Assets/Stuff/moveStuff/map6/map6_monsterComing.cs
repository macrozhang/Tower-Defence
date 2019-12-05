using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map6_monsterComing : MonoBehaviour
{
    public GameObject monster;
    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    private float time = 5f;
    private int many = 6;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0 && many > 0)
        {
            for (int y = 0; y < 3; y++)
            {
                createMon(-20f, 1.84f, 6.56f, monster);
                createMon(-20f, 3.25f, -10.26f, monster1);
                createMon(16.3f, 3.08f, -14.0f, monster2);
                createMon(17.0f, 0.52f, 14.7f, monster3);
            }
            time = 5f;
            many -= 1;
        }
    }

    public void waitTime(float t)
    {
        float times = 10f;
        if (times < 0)
        {
            return;
        }
        else
        {
            t -= Time.deltaTime;
        }
    }

    public void createMon(float x, float y, float z, GameObject mon)
    {
        GameObject obj = (GameObject)Instantiate(mon);
        obj.transform.position = new Vector3(x, y, z);
    }
}
