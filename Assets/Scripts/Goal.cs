using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
    void OnTriggerEnter(Collider c) {
        if(c.tag == "Player") {
            Application.LoadLevel("Goal");
        }
    }
}
