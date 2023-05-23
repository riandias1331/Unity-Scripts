using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testrecoil : MonoBehaviour 
{
	public recoil recoil;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")) {
			recoil.Fire ();
		}
	}
}
