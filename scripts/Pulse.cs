/* Daniel Mitchel-Slentz
 * Pulse.cs
 * This is attached to the player box and lets you move
 * forward, backward, left, and right using WASD or arrow keys
 */
using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {


    private Rigidbody _rb;

    public float impulse_speed = 1.0f;

    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () { 
        // push button for impulse force to push player box that direction
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _rb.AddForce(transform.forward * impulse_speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _rb.AddForce(transform.forward * -1 * impulse_speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(transform.right * -1 * impulse_speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(transform.right * impulse_speed, ForceMode.Impulse);
        }
    }
}
