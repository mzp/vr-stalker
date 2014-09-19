using UnityEngine;
using System.Collections;

public class UnityAgent : MonoBehaviour {
    public GameObject target;
	protected NavMeshAgent		agent;
	protected Animator			animator;

    // 旋回速度
    public float rotateSpeed = 2.0f;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		animator = GetComponent<Animator>();
	}

	protected void SetupAgentLocomotion()
	{
		if (AgentDone()) {
            DoLocomotion(0,0);
		} else {
			Vector3 velocity = Quaternion.Inverse(transform.rotation) * agent.desiredVelocity;

            DoLocomotion(velocity.z, velocity.x);
		}
	}

    void DoLocomotion(float speed, float direction) {
        // Locomotion
        animator.SetFloat("Speed", speed);
        animator.SetFloat("Direction", direction);

        // Transform
        Vector3 velocity = new Vector3 (0, 0, speed);
		velocity = transform.TransformDirection (velocity);
		transform.localPosition += velocity * Time.fixedDeltaTime;

        transform.Rotate (0, direction * rotateSpeed, 0);
    }

    void OnAnimatorMove()
    {
        agent.velocity = animator.deltaPosition / Time.deltaTime;
		transform.rotation = animator.rootRotation;
    }

	protected bool AgentDone()
	{
		return !agent.pathPending && AgentStopping();
	}

	protected bool AgentStopping()
	{
		return agent.remainingDistance <= agent.stoppingDistance;
	}

	// Update is called once per frame
	void Update () {
        agent.destination = this.target.transform.position;
        SetupAgentLocomotion();
	}
}
