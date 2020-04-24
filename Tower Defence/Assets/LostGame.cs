using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LostGame : MonoBehaviour
{
    public Button restart;
    public Button exit;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        exit.onClick.AddListener(mainmenu);
        restart.onClick.AddListener(re);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void mainmenu()
    {
        SceneManager.LoadScene("Start_menu");

    }
    private void re()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
