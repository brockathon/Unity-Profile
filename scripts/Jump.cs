/* Daniel Mitchel-Slentz
 * Jump.cs
 * This is attached to the player box
 * When space bar pressed and character is touching the ground,
 * impulse pushes character up
 */

using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    public Rigidbody _rb;
    public float initialBoost = 12.0f;
    private float boost = 0.0f;
    private float boostFallOff = 1.5f;
	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        // when the button first pressed, apply an initial impulse
        // force value to the player box, if the player box is currently
        // grounded
        // this if statement is executed once per button-down,
        // button-held, button-up sequence
	    if(Input.GetButtonDown("Jump") == true)
        {
            Debug.Log("GetButtonDown");
            if(Physics.Raycast (transform.position, Vector3.down, 1.1f))
            {
                boost = initialBoost;
            }
        }

        // if the button is held down, then this if statement will execute.
        // it will execute 0 or more times
        if (Input.GetButton("Jump"))
        {
            Debug.Log("GetButton");
            if(boost > 0.0f)
            {
                _rb.AddForce(Vector3.up * boost, ForceMode.Impulse);
                boost = Mathf.Max((boost - boostFallOff), 0.0f);
            }
        }

        // regardless of whether or not the button is held,
        // this executes once
        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log("GetButtonUp");
            boost = 0.0f;
        }
	}
}
