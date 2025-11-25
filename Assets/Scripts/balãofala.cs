using UnityEngine;
using UnityEngine.UI;

public class BalaoDeFala : MonoBehaviour
{
    [Header("Configurações do Balão")]
    public GameObject balaoObjeto; 
    public Text textoMensagem;    
    public Transform personagem;   
    public Vector3 offset = new Vector3(0, 2f, 0); 

    void Update()
    {
        if (balaoObjeto.activeSelf && personagem != null)
        {
            
            Vector3 posTela = Camera.main.WorldToScreenPoint(personagem.position + offset);
            balaoObjeto.transform.position = posTela;
        }
    }

    public void MostrarMensagem(string mensagem)
    {
        textoMensagem.text = mensagem;
        balaoObjeto.SetActive(true);
    }

    public void EsconderMensagem()
    {
        balaoObjeto.SetActive(false);
    }
}

