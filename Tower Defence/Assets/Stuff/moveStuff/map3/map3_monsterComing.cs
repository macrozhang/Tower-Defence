using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map3_monsterComing : MonoBehaviour
{
    public GameObject monster;
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
                createMon(-5.76f, 2.79f, 17.9f);
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

    public void createMon(float x, float y, float z)
    {
        GameObject obj = (GameObject)Instantiate(monster);
        obj.transform.position = new Vector3(x, y, z);
    }
}
