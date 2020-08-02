using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour {

	private PlaceableBuilding placeableBuilding;
	private Transform currentBuilding;
	
	void Start () {
	}
	
	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			switch (touch.phase) {
			case TouchPhase.Began:
				Vector3 m = touch.position;
				break;
			case TouchPhase.Moved:
				m = new Vector3 (touch.position.x, touch.position.y, transform.position.y);
				Vector3 pos = GetComponent<Camera> ().ScreenToWorldPoint (m);
				currentBuilding.position = new Vector3 (pos.x / 2, 0, pos.y * 5);
				GetComponent<Camera> ().transform.position = new Vector3 (pos.x / 2, transform.position.y, pos.y * 5);
				break;
			case TouchPhase.Ended:
				break;
			}
		}
	}

	public void SetItem(GameObject building){
		currentBuilding = (Instantiate (building, new Vector3(0, 0, 0), Quaternion.identity)).transform;
		GetComponent<Camera>().transform.position = new Vector3 (0, GetComponent<Camera>().transform.position.y, -30);
		placeableBuilding = currentBuilding.GetComponent<PlaceableBuilding> ();

	}
}