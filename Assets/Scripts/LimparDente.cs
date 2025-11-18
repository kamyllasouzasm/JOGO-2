using UnityEngine;

public class LimparDente : MonoBehaviour
{
    public Sprite denteLimpo;   // arraste o sprite limpo no Inspector
    private SpriteRenderer sr;
    private bool limpo = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!limpo)
        {
            // quando qualquer ferramenta encostar → limpa
            sr.sprite = denteLimpo;
            limpo = true;
        }
    }
}

