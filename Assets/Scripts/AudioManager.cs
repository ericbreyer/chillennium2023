using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource MusicSource;

    // Singleton instance.
    public static AudioManager Instance = null;

    public AudioClip[] musics;

    // Initialize the singleton instance.
    private void Awake() {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null) {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this) {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    // Play a single clip through the sound effects source.
    public void PlayEffect(AudioClip clip) {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }

    // Play a single clip through the music source.
    public void PlayMusic(int clip) {
        MusicSource.clip = musics[clip];
        if (!MusicSource.isPlaying) { MusicSource.Play(); }
    }
}