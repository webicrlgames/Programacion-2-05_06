using UnityEngine;

public class Enemigo : MonoBehaviour, IPresentacion, ITakeDamage
{
    public EnemyData datos;
    public int vidaActual;

    private void Start()
    {
        if (datos != null)
        {
            vidaActual = datos.vida;
            Debug.Log($"Soy {datos.nombre} y tengo {vidaActual} de vida.");
        }
    }

    public void Accion()
    {
        if (datos != null)
            Debug.Log($"{datos.nombre} dice: {datos.saludo}");
    }

    public void RecibirDaño(int cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log($"{datos.nombre} ha recibido {cantidad} de daño. Vida restante: {vidaActual}");

        if (vidaActual <= 0)
        {
            Debug.Log($"{datos.nombre} ha sido derrotado.");
            Destroy(gameObject);
        }
    }
}