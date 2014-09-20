using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 1.0f;
    private CharacterController controller = null;
    public GameObject follow;

    public void Start() {
        this.controller = GetComponent<CharacterController>();
    }

    public void Update() {
        Vector3 v = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		v = transform.TransformDirection(v);
		v *= speed;
        this.controller.Move(v);

        transform.LookAt(follow.transform);
    }
}
