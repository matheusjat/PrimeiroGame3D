using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour {

    private Camera fpsCam;

    public float distanciaDisparo = 50f;

    // Use this for initialization
    void Start () {

        fpsCam = GetComponentInParent<Camera>();
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 origemLinha = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        Debug.DrawRay(origemLinha, fpsCam.transform.forward * distanciaDisparo);

	}
}
