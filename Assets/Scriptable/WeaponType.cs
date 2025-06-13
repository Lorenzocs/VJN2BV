
using UnityEngine;

[CreateAssetMenu(fileName ="NuevoTipoArma",menuName ="Inventario/TipoArma")]
public class WeaponType : ScriptableObject
{
    public enum TipoArma
    {
        Melee,
        Magical,
        Range
    }

    public string nombre;

    [TextArea] public string descripcion;
    public int daño;
    public int costo;
    public int rango;
    public Sprite imagen;
    public TipoArma tipo;
   
}
