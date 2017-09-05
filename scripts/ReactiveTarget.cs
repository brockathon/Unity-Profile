/* Daniel Mitchel-Slentz
 * ReactiveTarget.cs
 * This is attached to babmbi. 
 * the method, ReacToHit gets called by Chutem
 */

using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReactToHit() // called when bambi gets shot
    {
        TargetWanderer behavior = GetComponent<TargetWanderer>();
        if(behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die()); // implement bambi's death
    }

    private IEnumerator Die() // coroutine for bambi's death thows
    {
        this.transform.Rotate(-75, 50, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
