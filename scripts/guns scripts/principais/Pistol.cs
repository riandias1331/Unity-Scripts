using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pistol : MonoBehaviour
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
	public ParticleSystem muzzleflashfogo;
	public ParticleSystem cartridgebala;
	public GameObject blood;
	

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

       

		currentRateToFire += Time.deltaTime;
		currentTimeToReload += Time.deltaTime;

		if (currentTimeToReload >= timeToReload) {
			canShoot = true;
		}

		if (Input.GetButton ("Fire1") && currentRateToFire >= firerate && canShoot && bullets > 0 ) {
			shoot ();

		} 
		if (Input.GetKeyDown (KeyCode.R) && mag > 0 && bullets < 30) {
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
			
		
		}
		MiraCrossHair.SetActive (true);
		animator.SetBool("idle", false);
	}
	void reload(){
		currentTimeToReload = 0;
		canShoot = false;
		animator.SetBool("reloadplus", true);
		mag--;
		bullets = startBullets;
		MiraCrossHair.SetActive(false);

	}
	
	
	void run (){
		animator.SetBool("run", true);
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
