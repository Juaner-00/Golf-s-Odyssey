using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

	public TouchCamera touchCamera;
	public GameObject[] buildings;
	private BuildingPlacement buildingPlacement;
	// Use this for initialization
	void Start () {
		buildingPlacement = GetComponent<BuildingPlacement> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PickBuildings(int number){
		touchCamera.isBuilding = true;
		buildingPlacement.SetItem (buildings[number]);
	}

}