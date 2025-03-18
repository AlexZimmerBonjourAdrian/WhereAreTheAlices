using UnityEngine;

[System.Serializable] // Para que se pueda serializar y guardar
public class CObjetoInventario : MonoBehaviour
{
    public string Nombre;
    public Sprite Icono;
    public int Cantidad;

     public bool IsConvining;

     public CObjetoInventario Fusionated;

     public CObjetoInventario Result;

     public enum TypeObject 
    {
        objectNormal,
        objectWeapon,

        objectBullets,

        objectItem,
    }

    public TypeObject Type = TypeObject.objectNormal;
    // Constructor para crear un nuevo objeto de inventario
  
    public CObjetoInventario(string nombre, Sprite icono, int cantidad = 1, bool isConvining = true, CObjetoInventario fusionated = null, CObjetoInventario result = null, TypeObject type = TypeObject.objectNormal)
    {
        Nombre = nombre;
        Icono = icono;
        Cantidad = cantidad;
        IsConvining=isConvining;
        Fusionated=fusionated;
        Result=result;   
        Type = type;
    }
}
