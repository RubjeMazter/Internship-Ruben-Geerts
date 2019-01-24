using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    // connect the manager to this script
    public GameObject manager;
    // location
    public Vector2 location = Vector2.zero;
    // velocity
    public Vector2 velocity;
    // goal position
    Vector2 goalPos = Vector2.zero;
    // force added to the units, to push units around
    Vector2 currentForce;


	// Use this for initialization
	void Start ()
    {
        // give it a very small velocity
        velocity = new Vector2(Random.Range(0.01f, 0.1f), Random.Range(0.01f, 0.1f));
        // the location of the unit
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
	}

    // get the target location vector: the direction the unit has to go
    Vector2 seek(Vector2 target)
    {
        return (target - location);
    }
    // apply the force to the unit
    void applyForce (Vector2 f)
    {
        // force is a new vector
        Vector3 force = new Vector3(f.x, f.y, 0);
		// if the force is bigger than the maxForce we set in the AllUnits script
		if (force.magnitude > manager.GetComponent<AllUnits> ().maxForce) {
			// normalize the force, and multiply it with the maxforce (which results in turning the force into the maxforce value
			force = force.normalized;
			force = force * manager.GetComponent<AllUnits> ().maxForce;
		}
        // add the force to the unit
		this.GetComponent<Rigidbody2D>().AddForce(force);
		// repeat previous if-statement but for the velocity
		if (this.GetComponent<Rigidbody2D> ().velocity.magnitude > manager.GetComponent<AllUnits> ().maxVelocity) {
			this.GetComponent<Rigidbody2D> ().velocity = this.GetComponent<Rigidbody2D> ().velocity.normalized;
			this.GetComponent<Rigidbody2D> ().velocity = this.GetComponent<Rigidbody2D> ().velocity * manager.GetComponent<AllUnits> ().maxVelocity;
		}

		// draw a line which represents the force in-game
        Debug.DrawRay(this.transform.position, force, Color.white);
    }

	Vector2 align()
	{
		// store the neighbour distance value from the allunits script in a float in this script
		float neighbordist = manager.GetComponent<AllUnits> ().neighbourDistance;
		// new variable sum (sum of all directions the units are moving towards)
		Vector2 sum = Vector2.zero;
		// variable to divide the sum by, to determine the middle of the vectors
		int count = 0;
		// loop through all the units in the manager
		foreach (GameObject other in manager.GetComponent<AllUnits>().units) 
		{
			// if the gameobject we find is ourself, do nothing
			if (other == this.gameObject) continue;
			// determine the distance between selected units
			float d = Vector2.Distance(location, other.GetComponent<Unit>().location);
			// if the distance is less than the neighbourdistance ... 
			if (d < neighbordist)
			{
				// get the units velocity, and add it to the sum
				sum = sum + other.GetComponent<Unit> ().velocity;
				// add 1 to the amount of units processed
				count++;
			}	
		}
		// if the units processed is more than 0
		if (count > 0) {
			// divide the sum by the count (to get the average vector)
			sum = sum / count;
			// add the average heading of the group to a new vector, but take the current velocity from the unit out of it
			Vector2 steer = sum - velocity;
			return steer;
		}
		// no neighbors = no velocity change
		return Vector2.zero;

	}

	Vector2 cohesion()
	{
		// store the neighbour distance value from the allunits script in a float in this script
		float neighbordist = manager.GetComponent<AllUnits> ().neighbourDistance;
		// new variable sum (sum of all directions the units are moving towards)
		Vector2 sum = Vector2.zero;
		// variable to divide the sum by, to determine the middle of the vectors
		int count = 0;
		// loop through all the units in the manager
		foreach (GameObject other in manager.GetComponent<AllUnits>().units) {
			// if the gameobject we find is ourself, do nothing
			if (other == this.gameObject)
				continue;
			// determine the distance between selected units
			float d = Vector2.Distance (location, other.GetComponent<Unit> ().location);
			// if the distance is less than the neighbourdistance ... 
			if (d < neighbordist) {
				// get the units location, and add it to the sum
				sum = sum + other.GetComponent<Unit> ().location;
				// add 1 to the amount of units processed
				count++;
			}	
		}
		// if the units processed is more than 0
		if (count > 0) {
			// divide the sum by the count (to get the average vector)
			sum = sum / count;
			// get the vector towards the goal location
			return seek (sum);
		}
		// no neighbors = no velocity change
		return Vector2.zero;
	}

    void flock()
    {
        // set the location of the unit
        location = this.transform.position;
        // set te velocity to the rigidbody of the component
		velocity = this.GetComponent<Rigidbody2D>().velocity;
        // to make sure the recalculations of the values doesnt happen every update, add a random range to make the code not too heavy
		if (Random.Range (0, 25) <= 1) {
			// vector for the align value
			Vector2 ali = align();
			// vector for the choesion value
			Vector2 coh = cohesion();
			// goal position variable
			Vector2 goal;
			// set the goal position variable
			goal = seek (goalPos);
			// set the force to be the vector that has been sought in the seek function
			currentForce = ali + coh + goal;
			// normalize this vector to get length 1, and have every unit move at the same speed
			currentForce = currentForce.normalized;
		}
		// add the force to the rigidbody
        applyForce(currentForce);
    }

	// Update is called once per frame
	void Update ()
    {
		// run the flock function
        flock();
		// set the goal position to be the manager's position, and put it in the update function so you can play with it in the unity editor. 
        goalPos = manager.transform.position;
	}
}
