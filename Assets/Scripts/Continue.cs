using UnityEngine;
using System.Collections;

public class Continue : MonoBehaviour {
	void Update () {
        if(Input.GetKeyDown("c")) {
            Application.LoadLevel("Main");
        }
	}
}
