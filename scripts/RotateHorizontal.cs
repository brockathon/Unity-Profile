/* Daniel Mitchel-Slentz
 * RotateHorizontal.cs
 * this is attached to player box
 * rotates around the Y-axis by moving the mouse side to side
 */

using UnityEngine;
using System.Collections;

public class RotateHorizontal : MonoBehaviour {

    public float sensitivityHor = 9.0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //rotate left or right with mouse movement
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0.0f);
    }
}
