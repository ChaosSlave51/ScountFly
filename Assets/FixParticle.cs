using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FixParticle : MonoBehaviour {
    ParticleSystem _particle;

	// Use this for initialization
	void Start () {
        _particle = GetComponent<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update () {
        var rot = _particle.main;
   rot.startRotationY = transform.localToWorldMatrix.rotation.eulerAngles.y * Mathf.Deg2Rad; 
       //sr.constant  



    }
}
