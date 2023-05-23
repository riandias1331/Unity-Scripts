using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pegaritem : MonoBehaviour 
{
	public GameObject sword;

	private void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "player") {
			sword.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}
}
