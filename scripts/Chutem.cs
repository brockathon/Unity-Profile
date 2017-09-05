/* Daniel Mitchel-Slentz comments
 * Chutem.cs aka shoot them
 * This is attached to main camera
 * Shooting using raycasting.
 * Gets location that is selected by clicking the left mouse button and indicates the position with a sphere
 * Targeting aided center screen astrix
 */
using UnityEngine;
using System.Collections;

public class Chutem : MonoBehaviour {
    public Camera _camera; //make camera accessable

    // Use this for initialization
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked; // fix cursor to center of screen
        Cursor.visible = true; // cursor visible
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // what happens when left click mouse button
        {
            // define a vector to hold the screen coordinates of the center of the view 
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            Ray ray = _camera.ScreenPointToRay(point); // aim ray with center of screen
            RaycastHit hit; // declaire variable container from raycast method
            if (Physics.Raycast(ray, out hit)) // check if ray hits something
            {
                GameObject hitObject = hit.transform.gameObject; // where hit
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>(); // check if reactive target hit
                if (target != null) // if target is hit
                {
                    Debug.Log("Target Hit"); // debug lets us know the target is hit
                    target.ReactToHit(); // calls ReactoHit on target
                }

                StartCoroutine(SphereIndicator(hit.point)); // start coroutine SphereIndicator at the point that got hit
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos) // called as coroutine to draw a sphere at vector3 position indicated by hit
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere); // create a sphere
        sphere.transform.localScale *= 0.5f; // set size of sphere
        sphere.transform.position = pos; // set vector position of sphere

        yield return new WaitForSeconds(0.1f); // wait .1 seconds

        Destroy(sphere); // destroy sphere
    }

    void OnGUI() // sets targeting asterix in the middle of the screen
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;

        GUI.Label(new Rect(posX, posY, 20, 20), "*");
    }
}
