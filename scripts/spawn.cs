using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public float tempo;
    public GameObject inimigo;

    float conta;
   
   void NovoInimigo(){
       
     if(!GameObject.Find("Orc"))
     {
        conta += Time.deltaTime;
        if(conta > tempo ){
            Instantiate(inimigo);
            conta = 0;
        }

     }
   }

    void Update()
    {
        NovoInimigo();
    }
}