using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
     [SerializeField] private string NomeLevelJogo;
     [SerializeField] GameObject painelMenuPrincipal;
    public void JogarButton()
    {
        SceneManager.LoadScene(NomeLevelJogo);
    }

    public void SairButton()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }

}
