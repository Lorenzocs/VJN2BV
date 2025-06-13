using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static WeaponType;

public class Arma : MonoBehaviour
{
    public string nombre;

    [TextArea] public string descripcion;
    public int daño;
    public int costo;
    public int rango;
    public TipoArma tipo;

    public WeaponType type;
    public Image laImagen;
    void Start()
    {
        laImagen = GetComponent<Image>();
        laImagen.sprite = type.imagen;
        laImagen.SetNativeSize();
    }

    // Update is called once per frame
    void Update()
    {
        nombre = type.nombre;
        daño = type.daño;
        rango = type.rango;
    }
}
