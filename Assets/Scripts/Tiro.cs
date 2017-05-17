using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tiro : MonoBehaviour {

    private AudioSource somDisparo;
    private bool disparo;
    private WaitForSeconds duracaoDisparo = new WaitForSeconds(0.07f);
    private Camera fpsCam;
    public float distanciaDisparo = 5000f;
    public float forcaDisparo = 1000f;
    public GameObject canoArma;
    private LineRenderer laser;

    // Use this for initialization
    void Start () {
        somDisparo = GetComponent<AudioSource>();
        fpsCam = GetComponent<Camera>();
        laser = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            disparo = false;
            StartCoroutine(EfeitoDisparo());
            
            Vector3 origemLinha = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            laser.SetPosition(0, canoArma.transform.position);

            RaycastHit pontoColisao;

            if (Physics.Raycast(origemLinha, fpsCam.transform.forward,
                out pontoColisao, distanciaDisparo))
            {
                laser.SetPosition(1, pontoColisao.point);
                if (pontoColisao.rigidbody != null)
                {
                    pontoColisao.rigidbody.AddForce(-pontoColisao.normal * forcaDisparo);
                }
            }else
            {
                laser.SetPosition(1, canoArma.transform.position + fpsCam.transform.forward * distanciaDisparo);
            }


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
        laser.enabled = enabled;
        yield return duracaoDisparo;
        laser.enabled = false;
    }
}
