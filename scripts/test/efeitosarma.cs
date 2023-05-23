using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efeitosarma : MonoBehaviour
{
    public int damage;
	public float range;

    public GameObject [] impactEffects; 
    public GameObject bullet;
    public Animation bulletAnim;
    public AnimationClip balas;
    public ParticleSystem muzzleflashfogo;
    public Camera maincamera;



    public AudioSource GunAudio;
    public AudioClip fireSound;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    if(Input.GetButton("Fire1")) 
    {
     RaycastHit hit;
		if (Physics.Raycast (maincamera.transform.position, maincamera.transform.forward, out hit, range)) {
			if (hit.transform.tag == "muro") {
				Instantiate (impactEffects [0], hit.point, Quaternion.LookRotation (hit.normal));
			}
			if (hit.transform.tag == "sangue") {
				Instantiate (impactEffects [1], hit.point, Quaternion.LookRotation (hit.normal));
			}
			if (hit.transform.tag == "metal") {
				Instantiate (impactEffects [2], hit.point, Quaternion.LookRotation (hit.normal));
			}
        }

    if (Input.GetButton ("Fire1")) {
       efects ();
    }

    if (Input.GetButton ("Fire1")) {
       bullets ();
    }
       
    }

    void efects ()
    {
        
        muzzleflashfogo.Play();

        GunAudio.clip = fireSound;
		GunAudio.Play ();

    }
    void bullets () {

     if (Input.GetButton ("Fire1")){
            bullet.SetActive(true);
        } else {
            bullet.SetActive(false);
        }
        bulletAnim.clip = balas;
		bulletAnim.Play ();
       
       }

    }
}