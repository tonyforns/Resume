using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public partial class SoundManager : Singleton<SoundManager>
{

    [SerializeField] private SoundList _soundList;
    [SerializeField] private Dictionary<GameSounds, AudioClip> _soundDictionary = new();
    [SerializeField] private Queue<AudioSource> _audioSourceQueue = new();
    [SerializeField] private AudioSource _enviromentSource;
    [SerializeField] private IObjectPool<AudioSource> pool;
    public override void Awake()
    {
        base.Awake();
        _audioSourceQueue.Enqueue(AddAudioSource());
        LoadDictionary();
        PlayEnviromentSound();

        SetPlayerWalking();
        SetPlayerWeaponAttack();

    }

    public AudioSource AddAudioSource()
    {
        return gameObject.AddComponent<AudioSource>();
    }
   public void PlaySound(GameSounds sound)
    {
        AudioSource audioSource;
        _audioSourceQueue.TryPeek(out audioSource);
        if(audioSource.isPlaying)
        {
            audioSource = AddAudioSource();
            _audioSourceQueue.Enqueue(audioSource);
        } else
        {
            _audioSourceQueue.Enqueue(_audioSourceQueue.Dequeue());
        }
        AudioClip audioClip;
        if(_soundDictionary.TryGetValue(sound, out audioClip))
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        } else
        {
            Debug.LogError($"Audio clip: {sound.ToString()} didn't find");
        }
    }

    public void PlayCommonButton()
    {
        PlaySound(GameSounds.ButtonPushed);
    }

    private void LoadDictionary()
    {
        foreach (SoundDefinition soundDef in _soundList.List())
        {
            _soundDictionary.Add(soundDef.soundType, soundDef.clip);
        }
    }
    private void PlayEnviromentSound()
    {
        _enviromentSource = AddAudioSource();
        AudioClip envorimentSound;
        _soundDictionary.TryGetValue(GameSounds.Enviroment, out envorimentSound);
        _enviromentSource.clip = envorimentSound;
        _enviromentSource.Play();
        _enviromentSource.loop = true;
    }
}

public partial class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource _playerWalking;
    [SerializeField] private AudioSource _playerWeaponAttack;

    public void PlayPlayerWalking(bool play)
    {

        if (play && !_playerWalking.isPlaying)
            _playerWalking.Play();
        if(!play && _playerWalking.isPlaying)
            _playerWalking.Stop();
    }

    public void PlayPlayerWeaponAttack()
    {
        if (!_playerWeaponAttack.isPlaying)
            _playerWeaponAttack.Play();
    }

    private void SetPlayerWeaponAttack()
    {
        AudioClip WeaponAttack;
        _playerWeaponAttack = AddAudioSource();
        _playerWeaponAttack.loop = false;
        _soundDictionary.TryGetValue(GameSounds.WeaponAttack, out WeaponAttack);
        _playerWeaponAttack.clip = WeaponAttack;
    }

    private void SetPlayerWalking()
    {
        AudioClip walking;
        _playerWalking = AddAudioSource();
        _playerWalking.loop = true;
        _playerWalking.pitch = 1.45f;
        _soundDictionary.TryGetValue(GameSounds.Walking, out walking);
        _playerWalking.clip = walking;
    }

}

[Serializable]
public enum GameSounds
{
    Enviroment,
    Walking,
    ButtonPushed,
    CharacterDialogue,
    WeaponAttack
}