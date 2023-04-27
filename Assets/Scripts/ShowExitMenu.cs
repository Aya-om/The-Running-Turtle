using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowExitMenu : MonoBehaviour
{
    public GameObject exitMenu;
    public GameObject gameOverMenu;
    bool isActive;
    //bool isGameOverMenuActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        //isGameOverMenuActive = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!isActive && !gameOverMenu.activeSelf)
            {
                exitMenu.SetActive(true);
                isActive = true;
                Time.timeScale = 0;
            }
            else if (isActive)
            {
                exitMenu.SetActive(false);
                isActive = false;
                Time.timeScale = 1;
            }

        }
    }
}
