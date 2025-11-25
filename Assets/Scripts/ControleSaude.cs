using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;


public class ControleSaude : MonoBehaviour
{
    [Header("UI")]
    public Slider barraSaude;
    public GameObject parabensTexto;
    public string nomeCenaSalaEspera = "SalaEspera";

    [Header("Personagem (um dos dois)")]
    public Image personagemImage;           
    public SpriteRenderer personagemSprite; 
    public Sprite triste;
    public Sprite feliz;

    [Header("Balões de fala")]
    public GameObject balaoInjecao;
    public GameObject balaoCurativo;
    public GameObject balaoTermometro;

    [Header("Textos dos balões (TMP)")]
    public TMP_Text textoInjecao;
    public TMP_Text textoCurativo;
    public TMP_Text textoTermometro;

    [Header("Efeitos")]
    public GameObject confetes;

    [Header("Áudio")] 
    public AudioSource audioSource;         
    public AudioClip somInjecao;             
    public AudioClip somCurativo;           

    private float saude = 0f;
    private const float SAUDE_MAX = 100f;

    [HideInInspector] public bool injecaoDada = false;
    [HideInInspector] public bool curativoDado = false;
    [HideInInspector] public bool termometroUsado = false;

    void Start()
    {
        saude = 0f;
        if (barraSaude != null) barraSaude.value = 0f;
        if (parabensTexto != null) parabensTexto.SetActive(false);

        if (personagemImage != null) personagemImage.sprite = triste;
        if (personagemSprite != null) personagemSprite.sprite = triste;

        if (confetes != null) confetes.SetActive(false);

        EsconderTodosBaloes();
        MostrarBalaoInjecao();
    }

    public void AumentarSaude(float valor)
    {
        saude += valor;
        if (saude > SAUDE_MAX) saude = SAUDE_MAX;
        if (barraSaude != null) barraSaude.value = saude / SAUDE_MAX;
    }

    void EsconderTodosBaloes()
    {
        if (balaoInjecao != null) balaoInjecao.SetActive(false);
        if (balaoCurativo != null) balaoCurativo.SetActive(false);
        if (balaoTermometro != null) balaoTermometro.SetActive(false);
    }

    void MostrarBalaoInjecao()
    {
        EsconderTodosBaloes();
        if (balaoInjecao != null)
        {
            balaoInjecao.SetActive(true);
            if (textoInjecao != null) textoInjecao.text = "Hora da injeção!";
        }
    }

    void MostrarBalaoCurativo()
    {
        EsconderTodosBaloes();
        if (balaoCurativo != null)
        {
            balaoCurativo.SetActive(true);
            if (textoCurativo != null) textoCurativo.text = "Agora coloque o curativo!";
        }
    }

    void MostrarBalaoTermometro()
    {
        EsconderTodosBaloes();
        if (balaoTermometro != null)
        {
            balaoTermometro.SetActive(true);
            if (textoTermometro != null) textoTermometro.text = "Falta pouco, hora do termômetro!";
        }
    }

  
    public void AplicarInjecao()
    {
        if (injecaoDada) return;
        injecaoDada = true;

        if (audioSource != null && somInjecao != null)
            audioSource.PlayOneShot(somInjecao);   

        MostrarBalaoCurativo();
    }

    public void AplicarCurativo()
    {
        if (!injecaoDada || curativoDado) return;
        curativoDado = true;

        if (audioSource != null && somCurativo != null)
            audioSource.PlayOneShot(somCurativo);  

        MostrarBalaoTermometro();
    }

    public void AplicarTermometro()
    {
        if (!curativoDado || termometroUsado) return;
        termometroUsado = true;

        EsconderTodosBaloes();

        if (saude >= SAUDE_MAX)
        {
            Recuperado();
        }
    }

    void Recuperado()
    {
        if (personagemImage != null) personagemImage.sprite = feliz;
        if (personagemSprite != null) personagemSprite.sprite = feliz;

        if (parabensTexto != null) parabensTexto.SetActive(true);
        if (confetes != null) confetes.SetActive(true);

        Invoke(nameof(EsconderConfetes), 1.8f);
        Invoke(nameof(Voltar), 2f);
    }

    void EsconderConfetes()
    {
        if (confetes != null) confetes.SetActive(false);
    }

    void Voltar()
    {
        if (!string.IsNullOrEmpty(nomeCenaSalaEspera))
            SceneManager.LoadScene(nomeCenaSalaEspera);
    }
}
