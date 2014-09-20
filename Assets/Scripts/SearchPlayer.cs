using UnityEngine;
using System.Collections;

public class SearchPlayer : MonoBehaviour {
	FOV2DEyes eyes;
	FOV2DVisionCone visionCone;
    public int suspicious = 0;
    Animator animator;
    public TextMesh status = null;

    bool playerInView = false;

	void Start()
	{
		eyes = GetComponentInChildren<FOV2DEyes>();
        animator = GetComponent<Animator>();
	}

	void Update()
	{
		bool found = false;

		foreach (RaycastHit hit in eyes.hits)
		{
			if (hit.transform && hit.transform.tag == "Player")
			{
				found = true;
			}
		}

		if (!playerInView && found){
            // found
            suspicious ++;
            animator.SetBool("Found", true);
            string s = "";
            for(int i = 0; i < suspicious; i++){ s += "?"; }
            status.text = s;
        }

        if(playerInView && !found) {
            // missing
            animator.SetBool("Found", false);
		}
        playerInView = found;

        if(suspicious >= 3) {
            Application.LoadLevel("GameOver");
        }
	}
}

