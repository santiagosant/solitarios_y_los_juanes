using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class inputExitScena : MonoBehaviour
{
  
    public string nombreScena;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player"){
            SceneManager.LoadScene(nombreScena);
        }
    }
}
