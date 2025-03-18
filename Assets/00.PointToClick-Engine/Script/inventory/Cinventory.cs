using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CInventario : MonoBehaviour
{
    public static CInventario Instancia { get; private set; } // Singleton

    public int CapacidadMaxima = 10; // Capacidad máxima del inventario
    public List<CObjetoInventario> Objetos { get; private set; } = new List<CObjetoInventario>();

    // Eventos para notificar cambios en el inventario
    public UnityEvent<CObjetoInventario> OnObjetoAgregado;
    public UnityEvent<CObjetoInventario> OnObjetoUsado;
    public UnityEvent<CObjetoInventario> OnObjetoEliminado;

    private void Awake()
    {
        // Singleton
        if (Instancia != null && Instancia != this)
        {
            Destroy(gameObject);
            return;
        }
        Instancia = this;
        // DontDestroyOnLoad(gameObject); // Si quieres que persista entre escenas
    }

    // Método para agregar un objeto al inventario
    public bool AgregarObjeto(CObjetoInventario objeto)
    {
        if (Objetos.Count < CapacidadMaxima)
        {
            Objetos.Add(objeto);
            OnObjetoAgregado.Invoke(objeto);
            return true;
        }
        else
        {
            Debug.LogWarning("Inventario lleno.");
            return false;
        }
    }

    // Método para usar un objeto del inventario
    public void UsarObjeto(CObjetoInventario objeto)
    {
        // Lógica para usar el objeto (reducir cantidad, aplicar efecto, etc.)
        objeto.Cantidad--;
        OnObjetoUsado.Invoke(objeto);

        if (objeto.Cantidad <= 0 && objeto.Type != CObjetoInventario.TypeObject.objectWeapon)
        {
            EliminarObjeto(objeto);
        }
    }

    // Método para eliminar un objeto del inventario
    public void EliminarObjeto(CObjetoInventario objeto)
    {
        Objetos.Remove(objeto);
        OnObjetoEliminado.Invoke(objeto);
    }

    public void FusionatedObject(CObjetoInventario Input, CObjetoInventario Output)
    {
        AgregarObjeto(Output.Result);
        EliminarObjeto(Input);
        EliminarObjeto(Output);
    }

    public void SumarUnaCantidad(CObjetoInventario Input, int Cantidad)
    {
        Input.Cantidad += Cantidad;
    }
    public void ReloadWeapon(CObjetoInventario Input, CObjetoInventario Output)
    {
        if(Input.Type == CObjetoInventario.TypeObject.objectBullets)
        {
               SumarUnaCantidad(Output, Input.Cantidad);
               EliminarObjeto(Input);
        }
    
       
    }

    
}
