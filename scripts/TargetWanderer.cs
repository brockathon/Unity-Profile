/* Daniel Mitchel-Slentz
 * TargetWanderer.cs
 * This script is attached to bambi prefab
 * handels the aimless wanderings of the bambi
 */

using UnityEngine;
using System.Collections;

public class TargetWanderer : MonoBehaviour {
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool alive;
	// Use this for initialization
	void Start () {
        alive = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (alive == true)
        {
            // move forward with respect to the local coord system
            transform.Translate(0, 0, speed * Time.deltaTime);

            // check if hit obsicle
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (hit.distance < obstacleRange) // obsticle encountered
                {
                    float angle = Random.Range(-110, 110); // is close enough to change direction
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }
    // from ReactiveTarget become false if shot
    public void SetAlive(bool currentLife) 
    {
        alive = currentLife;
    }
}
