﻿using UnityEngine;
using System.Collections;

public class RotatorX : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (1, 0, 0));
	}
}
