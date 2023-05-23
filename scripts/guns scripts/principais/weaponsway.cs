using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponsway : MonoBehaviour {

	public float value;
	public float maxAmount;
	public float smooth;
	Vector3 initalPostion;

	// Use this for initialization
	void Start () {
		initalPostion = transform.localPosition;	
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Mouse X") * value;
		float y = Input.GetAxis ("Mouse Y") * value;
		x = Mathf.Clamp (x, -maxAmount, maxAmount);
		y = Mathf.Clamp (y, -maxAmount, maxAmount);

		Vector3 finalPosition = new Vector3 (x, y, 0);
		transform.localPosition = Vector3.Lerp (transform.localPosition, finalPosition + initalPostion, Time.deltaTime * smooth);
	}

}
