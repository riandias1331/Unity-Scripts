using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
	public int damage;
	public float range;
	public int bullets = 30;
	public int mag = 3;
	private int startBullets;
	public Camera maincamera;
    
	public Animator animator;

	public float firerate;
	private float currentRateToFire;
	public float timeToReload;
	private float currentTimeToReload;
	public bool canShoot = true;
	public bool isDrawn;
	
    public GameObject MiraCrossHair;
    public TextMeshProUGUI textoReload;

	public AudioSource gunAudio;
	public AudioClip shootSound;
	public ParticleSystem muzzleflashfogo;
	public ParticleSystem cartridgebala;
	public GameObject [] impactEffects; 

	// Use this for initialization
	void Start () {
		currentRateToFire = firerate;
		currentTimeToReload = timeToReload;
		startBullets = bullets;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
       
	   
	   animator.SetBool("fire", false);
       animator.SetBool("reload", false);
       animator.SetBool("reload++", false);
       animator.SetBool("mira", false);
       animator.SetBool("mirafire", false);
       animator.SetBool("run", false);
       animator.SetBool("walk", false);

	   MiraCrossHair.SetActive (true);
       textoReload.text = bullets + "/" + mag;
       muzzleflashfogo.Stop ();


		

		currentRateToFire += Time.deltaTime;
		currentTimeToReload += Time.deltaTime;

		if (currentTimeToReload >= timeToReload) {
			canShoot = true;
		}

		if (Input.GetButton ("Fire1") && currentRateToFire >= firerate && canShoot && isDrawn == false && bullets > 0 ) {
			shoot ();

		} else if (Input.GetButton ("Fire1") && bullets == 0 && mag > 0) {

			reload ();
		}
		if (Input.GetKeyDown (KeyCode.R) && mag > 0 && bullets < 30) {
			reload ();
		}
		if (Input.GetKey (KeyCode.Mouse1)) {
			mira ();
		}
		if (Input.GetKey (KeyCode.Mouse1) && Input.GetButton ("Fire1")) {
			mirafiree ();
		}else if (Input.GetButton ("Fire1") && bullets == 0 && mag > 0) {

			reload ();
		
		}	
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.W)) {
			run ();
		}
		
		if (Input.GetKey(KeyCode.W)){
         andar();
        }
        if (Input.GetKey(KeyCode.S)){
        andar();
        } 
        if (Input.GetKey(KeyCode.D)){
         andar();
        }
        if (Input.GetKey(KeyCode.A)){
        andar();
        } 
			
	}

	void shoot (){
		bullets--;
		muzzleflashfogo.Play ();
		cartridgebala.Play ();
        if (Input.GetButton("Fire1")) {
        animator.SetBool("fire", true);
        }
		gunAudio.clip = shootSound;
		gunAudio.Play ();
		currentRateToFire = 0;
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
		MiraCrossHair.SetActive (true);
		
	}
	void reload(){
		currentTimeToReload = 0;
		canShoot = false;
		animator.SetBool("reloadplus", true);
		mag--;
		bullets = startBullets;
		MiraCrossHair.SetActive(false);

	}
	void mira (){
		if (Input.GetKey(KeyCode.Mouse1)) {

        animator.SetBool("mira", true);
        }
        else
        {
          animator.SetBool("mira", false);
        }
        animator.SetBool("fire", false);
        MiraCrossHair.SetActive (false);	
		
	}
	void mirafiree () {

		if (Input.GetKey(KeyCode.Mouse1) && Input.GetButton("Fire1")) {
        animator.SetBool("mirafire", true);
        }
        else
        {
          animator.SetBool("mirafire", false);
        }
        animator.SetBool("mira", true);

        gunAudio.clip = shootSound;
		gunAudio.Play ();

        MiraCrossHair.SetActive (false);
		
	}
	void run (){
		animator.SetBool("run", true);
        
		currentTimeToReload = 3.0f;
		canShoot = false;
        MiraCrossHair.SetActive (true);
    }
	void andar (){
			
       animator.SetBool("walk", true);
      
       if (Input.GetKey(KeyCode.W) && Input.GetButton("Fire1")) {
       animator.SetBool("walk", false);
       animator.SetBool("fire", true);
	   
      }
       if (Input.GetKey(KeyCode.S) && Input.GetButton("Fire1")) {
       animator.SetBool("walk", false);
       animator.SetBool("fire", true);
       
      }
      if (Input.GetKey(KeyCode.A) && Input.GetButton("Fire1")) {
       animator.SetBool("walk", false);
       animator.SetBool("fire", true);
	   
      }
       if (Input.GetKey(KeyCode.D) && Input.GetButton("Fire1")) {
       animator.SetBool("walk", false);
       animator.SetBool("fire", true);
	   
      }
      if(Input.GetKey(KeyCode.Mouse1)){
        animator.SetBool("mira", false);
        MiraCrossHair.SetActive(true);
		
      
      }
	  
	}
	
	
	

	
}



		
