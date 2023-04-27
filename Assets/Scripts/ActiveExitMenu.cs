using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveExitMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReplayFun()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }
    public void QuitFun()
    {
        Application.Quit();
    }
}
