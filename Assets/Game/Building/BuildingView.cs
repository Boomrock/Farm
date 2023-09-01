using System;
using UnityEngine;

namespace Game.Building
{ 
    public class BuildingView : MonoBehaviour
    {
        public Renderer MainRenderer => _mainRenderer;
        [SerializeField] private Renderer _mainRenderer;
    }
}