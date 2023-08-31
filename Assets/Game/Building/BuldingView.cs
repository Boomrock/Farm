using System;
using UnityEngine;

namespace Game.Building
{ 
    [RequireComponent(typeof(Renderer))]
    public class BuldingView : MonoBehaviour
    {
        public Renderer MainRenderer => _mainRenderer;
        [SerializeField] private Renderer _mainRenderer;
    }
}