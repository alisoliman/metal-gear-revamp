﻿using UnityEngine;
using System.Collections;

public class RotatorZ : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, 1));
	}
}
