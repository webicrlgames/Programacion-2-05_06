using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string nombre;
    public int vida;
    public string saludo;
}
