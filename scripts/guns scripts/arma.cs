using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class arma : MonoBehaviour
{
	public int damage;
	public float range;
	public int bullets = 30;
	public  int mag = 3;
	private int startBullets;
	public Camera maincamera;
	
	public  int vidaenemy;
	private int totalvidaenemy;
	
	public Animator animator;

	public float firerate;
	private float currentRateToFire;
	public float timeToReload;
	private float currentTimeToReload;
	public bool canShoot = true;
	
	
    public GameObject MiraCrossHair;
    public TextMeshProUGUI textoReload;

	public AudioSource gunAudio;
	public AudioClip fireAudio;
	public AudioClip reloadAudio;
	public ParticleSystem muzzleflashfogo;
	public ParticleSystem cartridgebala;
	public GameObject blood;

	public recoil recoil;
	

	// Use this for initialization
	void Start () {
		currentRateToFire = firerate;
		currentTimeToReload = timeToReload;
		startBullets = bullets;
		animator = GetComponent<Animator>();
		gunAudio = GetComponent<AudioSource>();
		totalvidaenemy = vidaenemy;
	    
        
		
	}
	
	// Update is called once per frame
	void Update () {
       
	   animator.SetBool("idle", true);
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
	   

	   

       if (mag <= 0){
		 mag = 3;
	   }

		currentRateToFire += Time.deltaTime;
		currentTimeToReload += Time.deltaTime;

		if (currentTimeToReload >= timeToReload) {
			canShoot = true;
		}

		if (Input.GetButton ("Fire1") && currentRateToFire >= firerate && canShoot && bullets > 0 ) {
			shoot ();
            recoil.Fire ();
		} 
		if (Input.GetKeyDown (KeyCode.R) && mag > 0 && bullets < 30) {
			reload ();
		}
		if (Input.GetKey (KeyCode.Mouse1)) {
			mira ();
		}
		if (Input.GetKey (KeyCode.Mouse1) && Input.GetButton ("Fire1") && bullets > 0 ) {
			mirafiree ();
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
		gunAudio.clip = fireAudio;
		gunAudio.Play ();
		currentRateToFire = 0;
		RaycastHit hit;
		if (Physics.Raycast (maincamera.transform.position, maincamera.transform.forward, out hit, range)) {
			
			if (hit.transform.tag == "enemy") {
				Instantiate (blood, hit.point, Quaternion.LookRotation (hit.normal));
				
			}
			
			
		   if (hit.transform.tag == "enemy"){
			   hit.transform.GetComponent<enemy>().lifezombie -= damage;
		   }

		   if (hit.transform.tag == "headshoot"){
			   hit.transform.GetComponentInParent<enemy>().lifezombie -= totalvidaenemy;
		   }
		
		}

		MiraCrossHair.SetActive (true);
		animator.SetBool("idle", false);
	}
	void reload(){
        gunAudio.clip = reloadAudio;
		gunAudio.Play ();
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
		animator.SetBool("idle", false);
	}
	void mirafiree () {
		currentRateToFire = 0;

		if (Input.GetKey(KeyCode.Mouse1) && Input.GetButton("Fire1")) {
        animator.SetBool("mirafire", true);
        }
        else
        {
          animator.SetBool("mirafire", false);
        }
        animator.SetBool("mira", true);
		animator.SetBool("idle", false);

       
		gunAudio.Play ();
        
        MiraCrossHair.SetActive (false);
		animator.SetBool("idle", false);
	}
	void run (){
		animator.SetBool("run", true);
		animator.SetBool("idle", false);
        currentTimeToReload = 0;
		canShoot = false;
        MiraCrossHair.SetActive (false);
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.W) && Input.GetButton("Fire1")) {
			animator.SetBool("fire", true);
		}
		
    }
	void andar (){
	  currentTimeToReload = 3.0f;
	  canShoot = false;
      animator.SetBool("walk", true);
	  animator.SetBool("idle", false);
      if(Input.GetKey(KeyCode.Mouse1)){
        animator.SetBool("mira", true);
        MiraCrossHair.SetActive(false);
		animator.SetBool("walk", false);
      }
	  if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.W)) {
		animator.SetBool("run", true);
		}
   }
   
        
    

}  
 
	

   
        
    

   





