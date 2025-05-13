using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    private Enemigo enemigoEnContacto;

    public float rangoAtaque = 2f;
    public int daño = 10;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontal * velocidad * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (enemigoEnContacto != null)
            {
                enemigoEnContacto.Accion();
            }
            else
            {
                Debug.Log("No estás en contacto con ningún enemigo.");
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            AtacarEnemigosCercanos();
        }
    }

    private void AtacarEnemigosCercanos()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, rangoAtaque);

        foreach (Collider col in colliders)
        {
            ITakeDamage enemigo = col.GetComponent<ITakeDamage>();
            if (enemigo != null)
            {
                enemigo.RecibirDaño(daño);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemigo enemigo = other.GetComponent<Enemigo>();
        if (enemigo != null)
        {
            enemigoEnContacto = enemigo;
            if (enemigo.datos != null)
                Debug.Log("Entraste en contacto con: " + enemigo.datos.nombre);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemigo enemigo = other.GetComponent<Enemigo>();
        if (enemigo != null && enemigo == enemigoEnContacto)
        {
            enemigoEnContacto = null;
            Debug.Log("Saliste del contacto con el enemigo.");
        }
    }
}