using UnityEngine;

[CreateAssetMenu(menuName="Bichinhos/Mascote Data")]
public class MascoteData : ScriptableObject
{
    public string mascotId;
    public Sprite spriteWaiting; // sentado
    public Sprite spriteExam;    // boca aberta NO CONSULTORIO
    public GameObject prefabDentes;
    public Vector3 examPosition;
    public Vector3 examScale;
    public string nome;
}

