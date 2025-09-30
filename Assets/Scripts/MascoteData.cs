using UnityEngine;

[CreateAssetMenu(fileName = "MascoteData", menuName = "Mascote/Data")]
public class MascoteData : ScriptableObject
{
    public string mascoteId;
    public Sprite spriteWaiting;
    public Sprite spriteExam;
    public GameObject prefabDentes;   // <<--- GameObject
    public GameObject prefabExame;    // <<--- GameObject
    public Vector3 examPosition = Vector3.zero;
    public Vector3 examScale = Vector3.one;
}


