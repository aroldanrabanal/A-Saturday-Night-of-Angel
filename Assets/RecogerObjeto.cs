using UnityEngine;
using TMPro;

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
        Transform iconoExistente = contenedorUI.Find(nombreItem);

        if (iconoExistente != null)
        {
            TMP_Text textoCantidad = iconoExistente.GetComponentInChildren<TMP_Text>();
            
            int cantidad = int.Parse(textoCantidad.text.Replace("x", "")) + 1;
            textoCantidad.text = "x" + cantidad;
        }
        else
        {
            GameObject nuevoIcono = Instantiate(prefabDelIcono, contenedorUI);
            nuevoIcono.name = nombreItem; 
            
            TMP_Text textoCantidad = nuevoIcono.GetComponentInChildren<TMP_Text>();
            textoCantidad.text = "x1";
        }
    }
}