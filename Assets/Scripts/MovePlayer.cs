using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 lastPosClick;
    public bool moving;
    public bool dialogo;
    void Update()
    {
        if (!Dialogos.GetIntance().is_dialogo && Input.GetMouseButtonDown(0)){
            lastPosClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }

        if (moving && (Vector2)transform.position != lastPosClick){
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastPosClick, step);
        } else {
            moving = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Fondo" || col.gameObject.tag == "NPC"){
            moving = false;
            dialogo = true;
        }
    }

    private void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.tag == "Fondo"){
            moving = false;
        }
    }

    private void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.tag == "NPC"){
            dialogo = false;
        }
    }

}
