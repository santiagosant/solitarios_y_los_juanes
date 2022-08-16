using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{
    public bool is_dialogo = false;
    public GameObject player;
    public TextAsset inkJson;

    private void OnMouseDown() {
        if (gameObject.tag == "NPC")
        {
            Debug.Log(inkJson.text);;
        }
    }
}
