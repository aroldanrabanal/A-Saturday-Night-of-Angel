using UnityEngine;
using TMPro; // Si usas TextMeshPro

public class RecogerAcumulable : MonoBehaviour
{
    public string nombreItem;
    public GameObject prefabDelIcono;
    private Transform contenedorUI;

    void Start() {
        contenedorUI = GameObject.Find("ContenedorIconos").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GestionarInventarioUI();
            Destroy(gameObject);
        }
    }

    void GestionarInventarioUI()
    {
        // 1. Buscamos si ya existe un icono con este nombre en el panel
        Transform iconoExistente = contenedorUI.Find(nombreItem);

        if (iconoExistente != null)
        {
            // 2. Si existe, buscamos el texto y actualizamos el número
            // Buscamos en los hijos del icono el que tenga el Tag "CantidadTexto"
            TMP_Text textoCantidad = iconoExistente.GetComponentInChildren<TMP_Text>();
            
            // Extraemos el número actual (quitando la 'x') y le sumamos 1
            int cantidad = int.Parse(textoCantidad.text.Replace("x", "")) + 1;
            textoCantidad.text = "x" + cantidad;
        }
        else
        {
            // 3. Si no existe, lo creamos y le ponemos el nombre para encontrarlo luego
            GameObject nuevoIcono = Instantiate(prefabDelIcono, contenedorUI);
            nuevoIcono.name = nombreItem; // Muy importante para el paso 1
            
            // Aseguramos que empiece en x1
            TMP_Text textoCantidad = nuevoIcono.GetComponentInChildren<TMP_Text>();
            textoCantidad.text = "x1";
        }
    }
}