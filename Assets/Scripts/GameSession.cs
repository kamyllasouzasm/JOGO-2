using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static GameSession I;
    public MascoteData selectedMascot;

    void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject); // não destruir ao trocar de cena
    }
}

