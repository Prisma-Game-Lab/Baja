using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleScript : MonoBehaviour
{
	public GameObject CarDustParticles;

	private void Start()
	{
		CarDustParticles.SetActive(false);
	}

	private void Update()
	{
		if (this.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1)
			CarDustParticles.SetActive(true);
		else
			CarDustParticles.SetActive(false);
	}
}
