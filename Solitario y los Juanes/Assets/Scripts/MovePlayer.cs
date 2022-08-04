using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 10f;
    Vector2 lastPosClick;
    bool moving;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
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
}
