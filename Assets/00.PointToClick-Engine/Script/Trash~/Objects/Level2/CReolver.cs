using UnityEngine;
using PointClickerEngine;

[CreateAssetMenu(fileName = "New Revolver Not Mag", menuName = "Inventory/Revolver")]
//public class CRevolver : CInventoryItemData, Iinteract
public class CRevolver : CObjetoInventario, Iinteract
{
    public CRevolver(string nombre, Sprite icono, int cantidad = 1, bool isConvining = true, CObjetoInventario fusionated = null, CObjetoInventario result = null, TypeObject type = TypeObject.objectNormal) : base(nombre, icono, cantidad, isConvining, fusionated, result, type)
    {  
    }


    // public override void Use()
    // {
    //     Debug.Log($"Disparando el {Name}");
    //     // Lógica específica para usar el revólver
    // }




   public void Oninteract() 
    {
        // Agrega este revólver al inventario
        if (CInventario.Instancia.AgregarObjeto(this))
        {
            // Si se agregó correctamente, puedes opcionalmente destruir el objeto del mundo
           // Destroy(this.gameObject); 
             Debug.LogWarning("PickUp dialog");
           
        }
        else
        {
            // El inventario está lleno, maneja esto de alguna manera (mensaje al usuario, etc.)
            Debug.LogWarning("¡El inventario está lleno!");
        }
    }
}
