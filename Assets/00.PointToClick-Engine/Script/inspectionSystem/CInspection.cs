using UnityEngine;
using PointClickerEngine;

public class CInspection : MonoBehaviour,Iinteract
{
    /// <summary>
    /// Quiero realizar un sistema de inspeccion para objetos.
    /// De esta manera a la hora de hacer click en un se activa la interaccion con este objeto.
    /// El objeto es movido a una vista mas detallada que es tratada como una animatic
    /// En esta se puede regresa a el estado anterior sin que de problemas
    /// A la hora de inspecionarlo se cuentan de 1 a 5 areas de interes
    /// al hacer click estas ejecutan un bark o un dialogo de Juno que es un pesamiento.
    /// Estas pueden Desatar que se ejcute un animatic o desencadene un Flashback, que es como un minijugo interno.
    /// 
    /// Plan actual
    /// Lo que me interesa ahora planificar como ejecutar ese sistema, y que sea de la siguiente manera,
    /// que esto funcione para cualquier objeto pero se fliltre segun el Data objeto
    /// No todos los objetos ejecutan un flashback.
    /// Los objetos a inspeccionar pueden o no ser importantes.
    /// Me intersa hacer una planificacion e impelmentacion basica ahora.
    /// </summary>
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Oninteract()
    {
        throw new System.NotImplementedException();
    }

    
}
