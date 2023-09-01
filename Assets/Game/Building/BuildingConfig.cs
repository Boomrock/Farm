using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Building
{
    [CreateAssetMenu(fileName = "BuildingConfig", menuName = "Configs/BuildingConfig")]
    public class BuildingConfig : ScriptableObject
    {
        [SerializeField] private BuildingModel[] _models;
        public Dictionary<BuildingType, BuildingModel> Dictionary = new Dictionary<BuildingType, BuildingModel>();
        private bool _isInit = false;

        public void Init()
        {
            if(_isInit)
                return;
            if(_models == null)
                Debug.LogError("_models is null");
            foreach (var model in _models)
            {
                Dictionary.Add(model.Type, model);
            }

            _isInit = true;
        }
    }

    [Serializable]
    public class BuildingModel
    {
        public BuildingView View;
        public BuildingType Type;
        public int Price; 
    }
}