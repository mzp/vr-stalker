using UnityEngine;
using System.Collections;

public class Preserve : MonoBehaviour {
	void Awake() {
        DontDestroyOnLoad(this);
    }
}
