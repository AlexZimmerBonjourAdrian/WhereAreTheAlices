using System;
using UnityEngine;

namespace PointClickerEngine
{
    [CreateAssetMenu(fileName = "NewAnimaticData", menuName = "PointToClickEngine/Animatic")]
    public class CAnimaticData : ScriptableObject
    {
        public int Id;
        public Sprite AnimationSprite;
        public CAnimaticData NextAnimation;
        
        [SerializeField] private bool _hasPlayed = false;
        [SerializeField] private bool _isReplay = false;

        public bool HasPlayed 
        { 
            get => _hasPlayed; 
            set => _hasPlayed = value; 
        }
        
        public bool IsReplay 
        { 
            get => _isReplay; 
            set => _isReplay = value; 
        }
    
        // Método para reproducir la animación (puedes moverlo a otra clase)
        public void PlayAnimation()
        {
            if(HasPlayed && !IsReplay) return;
        
            // Aquí iría tu código para reproducir la animación
            
            HasPlayed = true;
        }

        
    }
}