using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Fps
{
public class CWeaponPickup : MonoBehaviour
{
 public GameObject weaponPrefab; // Asigna el prefab del arma en el Inspector

    private void OnCollisionStay(Collision other) {
  
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            CManagerWeapon weaponManager = other.gameObject.GetComponent<CManagerWeapon>();
            if (weaponManager != null)
            {
                // Agregar el arma a la lista de armas disponibles
               // weaponManager.AddWeapon(weaponPrefab); 
                Destroy(gameObject); // Destruir el objeto de recolección
            }
        }
    }
      }
}

}
