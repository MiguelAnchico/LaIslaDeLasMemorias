using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


// Define una clase para el ScriptableObject
[CreateAssetMenu(fileName = "ScriptableActivitiesInfo", menuName = "ScriptableObject/ActivitiesInfo", order = 51)]
public class ScriptableActivitiesInfo : ScriptableObject
{
    [Serializable]
    public struct Ambiente{
        [Serializable]
        public struct Actividad{
            public string _name;
            public string _desc;
            public SceneAsset _scene;
            public enum NivelDificultad{Facil,Normal,Dificil}
            public NivelDificultad _dificultad;
            public float _tiempoEstimado;
            public Sprite _personaje;
            public string _nombrePersonaje;
		}
        public string _name;
        public List<Actividad> _activitiesNames;
    }
    public List<Ambiente> Ambientes;
}
