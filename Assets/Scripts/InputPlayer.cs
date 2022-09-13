using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public GameObject UI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !UI.activeSelf){
            UI.SetActive(true);
        } else if(Input.GetKeyDown(KeyCode.Escape) && UI.activeSelf){
            UI.SetActive(false);
        }
    }
}
