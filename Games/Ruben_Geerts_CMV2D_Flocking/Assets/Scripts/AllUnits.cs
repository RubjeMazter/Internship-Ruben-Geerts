using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllUnits : MonoBehaviour {
    // variables: unit array, prefab, amount of units, and range around the gamemaster
    public GameObject[] units;
    public GameObject prefab;
    public int numUnits = 10;
    public Vector3 range = new Vector3(5, 5, 5);

	[Range (0, 200)]
	public int neighbourDistance = 50;

	[Range (0, 10)]
	public float maxForce = 0.5f;

	[Range (0, 20)]
	public float maxVelocity = 2.0f;

    // function to show the range around the gamemaster, and a green circle in the middle
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(this.transform.position, range * 2);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, 0.2f);
    }



    void Start ()
    {
        // create the list with amount of spaces listed in the variables
        units = new GameObject[numUnits];
        // loop through the amount of units in the units array
        for (int i = 0; i < numUnits; i++)
        {
            // select a random position within the assigned range around the gamemaster
            Vector3 unitPos = new Vector3(Random.Range(-range.x, range.x), Random.Range(-range.y, range.y), Random.Range(0, 0));
            // instantiate a unit in the specific location as a gameobject
            units[i] = Instantiate(prefab, this.transform.position + unitPos, Quaternion.identity) as GameObject;
            // manager connected to the unit
			units[i].GetComponent<Unit>().manager = this.gameObject;
        }
	}
}
