using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPrincipal : MonoBehaviour
{
[SerializeField] private string startgame;
[SerializeField] private string menu;
[SerializeField] private GameObject painelMenuInicial;
[SerializeField] private GameObject Opções;

private bool audioON = true; 

public void  Start() {
    unlockmouse();
}

public void  Update() {
    
    

}
public void unlockmouse()
{
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}

public void jogar()
{
    SceneManager.LoadScene(startgame);
    Time.timeScale = 1;
    AudioListener.volume = 1;
}

public void menuprimario (){
    SceneManager.LoadScene("menu");
}
public void AbrirOpções(){
    painelMenuInicial.SetActive(false);
    Opções.SetActive(true);
}
public void FecharOpções(){
    Opções.SetActive(false);
    painelMenuInicial.SetActive(true);
}
public void SairDoJogo(){
    Debug.Log("Saiu do jogo");
    Application.Quit();
}


public void resoluçao1(){
    Screen.SetResolution (1920, 1080, true);
}
public void resoluçao2(){
    Screen.SetResolution (1280, 960, true);
}
public void resoluçao3(){
    Screen.SetResolution (640, 480, true);
}


public void low(){
    QualitySettings.SetQualityLevel (0);
}
public void medium(){
    QualitySettings.SetQualityLevel (1);
}
public void high(){
    QualitySettings.SetQualityLevel (2);
}

public void volumeGame(){
         audioON =! audioON;
         if(audioON==true)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    } 


}