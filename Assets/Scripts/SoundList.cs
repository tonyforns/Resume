using System;
using UnityEngine;

    [CreateAssetMenu(fileName = "SoundList", menuName = "ScriptableObjects/List/SoundList")]
    public class SoundList : ItemList<SoundDefinition>
    {

    }
    [Serializable]
    public class SoundDefinition
    {
        public GameSounds soundType;
        public AudioClip clip;
    }
