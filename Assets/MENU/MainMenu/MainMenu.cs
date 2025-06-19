
    using System.Collections;  
    using System.Collections.Generic;  
    using UnityEngine;  
    using UnityEngine.SceneManagement;  
    
    public class MainMenu: MonoBehaviour {  
        public void PlayGame() {  
            SceneManager.LoadScene("NewScene");  
        }  

    public void QuitGame() {  
        Debug.Log("QUIT");  
        Application.Quit();
    }

    public void MenuScreen()
    {
        Debug.Log("BackToMenu");  
        SceneManager.LoadScene("menu_scene");
    }  
      
    }   
