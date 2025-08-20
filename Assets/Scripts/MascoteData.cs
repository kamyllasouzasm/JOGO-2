using UnityEngine;

[CreateAssetMenu(menuName="Bichinhos/Mascote Data")]
public class MascoteData : ScriptableObject
{
    public string mascotId;
    public Sprite spriteWaiting; // sentado
    public Sprite spriteExam;    // boca aberta
}

