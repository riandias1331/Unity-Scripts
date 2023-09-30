using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public float tempo;
    public GameObject inimigo;
    //local exato do spawn
    public Transform localEnemy;
    public GameObject horda;

    float conta;
   
   void NovoInimigo(){
       
     if(!GameObject.Find("Orc"))
     {
        conta += Time.deltaTime;
        if(conta > tempo ){
            Instantiate(inimigo, localEnemy.position, localEnemy.rotation);
            conta = 0;
        }

     }
   }

    void Update()
    {
        NovoInimigo();
       // Novahorda();
    }
