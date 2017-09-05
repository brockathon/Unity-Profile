/* Daniel Mitchel-Slentz
 * RotateVertical.cs
 * This is attached the main camera.
 * move mouse forward and backward to look up and down at a limited angle
 */
using UnityEngine;
using System.Collections;

public class RotateVertical : MonoBehaviour {

    public float sensitivityVert = 9.0f;
    public float minimumVert = -30.0f;
    public float maximumVert = 30.0f;
    private float _rotationX = 0.0f;
    private float _rotationY = 0.0f;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update () {
        // rotate camera on x-axis based on mouse movement
        // limited by mathf.clamp
        _rotationY = transform.localEulerAngles.y;
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0.0f);
    }
}
