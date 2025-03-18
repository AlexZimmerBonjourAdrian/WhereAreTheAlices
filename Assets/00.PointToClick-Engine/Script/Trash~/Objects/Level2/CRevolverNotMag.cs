using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Not Mag Revolver", menuName = "Inventory/NotMagRevolver")]

public class CRevolverNotMag : CObjetoInventario, Iinteract
{
    [SerializeField]
    private int idRoom;


      public CRevolverNotMag(string nombre, Sprite icono, int cantidad = 1, bool isConvining = true, CObjetoInventario fusionated = null, CObjetoInventario result = null, TypeObject type = TypeObject.objectNormal) : base(nombre, icono, cantidad, isConvining, fusionated, result, type)
        {  
            Nombre = nombre;
            Icono = icono;
            Cantidad = cantidad;
            IsConvining=isConvining;
            Fusionated=fusionated;
            Result=result;   
            Type = type;
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
            CLevel2.Inst.SetIsRevolver(true);
            CManagerSFX.Inst.PlaySound(0);
            CLevel2.Inst.SetRoomActive(idRoom, true);
        }
        else
        {
            // El inventario está lleno, maneja esto de alguna manera (mensaje al usuario, etc.)
            Debug.LogWarning("¡El inventario está lleno!");
        }
    }

    // public void Oninteract()
    // {
    //     CLevel2.Inst.SetIsRevolver(true);
    //     CManagerSFX.Inst.PlaySound(0);
    //     CLevel2.Inst.SetRoomActive(idRoom, true);
    // }
}
