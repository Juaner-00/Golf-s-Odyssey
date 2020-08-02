using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableBuilding : MonoBehaviour {

	public List<Collider> colliders = new List<Collider> ();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Building") {
			colliders.Add (Collider);
		}
	}
	void OnTriggerExit(Collider collider){
		if (collider.tag == "Building") {
			colliders.Remove (collider);
		}
	}
}