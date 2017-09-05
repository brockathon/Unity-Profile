/* Daniel Mitchel-Slentz
 * SceneControler.cs
 * This script is called by the controller object to
 * instantiate the prefab that is the wandering object.
 * if wandering object destroyed, gets reinstatiated
 */

using UnityEngine;
using System.Collections;

public class SceneControler : MonoBehaviour {

    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject _enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = transform.position;
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0); // set facing for bambi
        }
	
	}
}
