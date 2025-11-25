using UnityEngine;

public class LimparDente : MonoBehaviour
{
    public Sprite denteLimpo;   
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
            
            sr.sprite = denteLimpo;
            limpo = true;
        }
    }
}

