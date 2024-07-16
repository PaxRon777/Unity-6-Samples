using UnityEngine;

[CreateAssetMenu(fileName = "Game", menuName = "Add SO/Game")]

public class SO_Game : ScriptableObject
{
    [Header("Game Data")]
    [SerializeField] private int _coins;
    [SerializeField] private int _health;

    public int Coins { get; set ; }
    public int Health { get; set; }
   
}
