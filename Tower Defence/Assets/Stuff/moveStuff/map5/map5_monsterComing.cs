using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map5_monsterComing : MonoBehaviour
{
    public GameObject monster;
    public GameObject monster1;
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
                createMon(-19.55194f, 2.53f, 7.339243f, monster);
                createMon(-19.55194f, 2.53f, -6.1f, monster1);
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
