using UnityEngine;
using System.Collections;

public class DistanceGameOver : MonoBehaviour {

	public GameObject target = null;
	public float threshold = 15.0f;

	void Update () {
	    float d = Vector3.Distance(target.transform.position, transform.position);
        if(d > threshold) {
            Application.LoadLevel("GameOver");
        }
	}
}
