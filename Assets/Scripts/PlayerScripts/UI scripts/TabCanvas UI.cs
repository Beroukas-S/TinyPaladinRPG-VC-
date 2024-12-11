using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuCanvasUI : MonoBehaviour
{
    public CanvasGroup menuCanvas;
    private bool menuOpen;
    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.alpha = 0;
        menuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ToggleStats"))
        {
            if (menuOpen)
            {
                Time.timeScale = 1;
                menuCanvas.alpha = 0;
                menuOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                menuCanvas.alpha = 1;
                menuOpen = true;
            }
        }

        //να φτιαξω τα κουμπια
    }
}
