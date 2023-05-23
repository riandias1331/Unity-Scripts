using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class playerFps : MonoBehaviour

{
    public string gameover;
    public Animator Anim;
    public int lifeplayer = 100;
    public GameObject sanguetela;
    public TextMeshProUGUI lifetext;
    public int danoEnemy = 40;
   


    void Start() 
    {
        Anim = GetComponent<Animator>();
        sanguetela.SetActive(false);     
    }   


    void update ()
    {
       lifetext.text = lifeplayer.ToString();

       if (lifeplayer <= 0){
        SceneManager.LoadScene("GameOver");
          StartCoroutine ("Morte");
        }

        //if(lifeplayer > 80){
          //  sanguetela.SetActive(false);
        //}
        
        
        
 
        
    } 

    void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.tag == "maodoinimigo"){
        lifeplayer -= danoEnemy;
        //lifeplayer -= danoEnemy;
        sanguetela.SetActive(true);
        } else if (GetComponent<enemy>().lifezombie <= 0){
          sanguetela.SetActive(false);
        } 
          
        if(Input.GetKeyDown(KeyCode.F) && collider.gameObject.tag == "box"){
			  GetComponent<arma>().mag++;
		}
        
    }
    IEnumerator Morte(){
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(3);
    }

   
}
