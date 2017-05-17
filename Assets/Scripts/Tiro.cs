using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tiro : MonoBehaviour {

    private AudioSource somDisparo;
    private bool disparo;
    private WaitForSeconds duracaoDisparo = new WaitForSeconds(0.07f);

    // Use this for initialization
    void Start () {
        somDisparo = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            disparo = false;
            StartCoroutine(EfeitoDisparo());

        }
		
	}

    public void Disparo()
    {
        disparo = true;
        print("Teste");
    }

    private IEnumerator EfeitoDisparo()
    {
        somDisparo.Play();
        yield return duracaoDisparo;
    }
}
