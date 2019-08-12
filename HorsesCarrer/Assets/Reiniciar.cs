using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Reiniciar : MonoBehaviour
{
   public void cargarNivel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }
        
    
}
