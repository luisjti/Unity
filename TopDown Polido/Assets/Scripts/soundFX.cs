using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum sound{
    ATTACK_PLAYER, ATTACK_GREEN, FOLLOW, HEAL, DEATH_PLAYER, DEATH_ENEMY
}

public class soundFX : MonoBehaviour
{
    public AudioClip attack_player, attack_green, follow, heal, death_player, death_enemy;
    private AudioSource audio;
    public static soundFX instance;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        if (audio == null)
            Debug.Log("audio e nulo");
        instance = this;
    }

    public static void playSound(sound currentSound)
    {
        if(instance == null)
        {
            Debug.Log("audiosource e nulo");
            return;
        }
        switch (currentSound)
        {
            case sound.ATTACK_PLAYER:
                // toca o som sem anular o que está tocando antes
                instance.audio.PlayOneShot(instance.attack_player);
                instance.audio.volume = 0.3f;
            break;

            case sound.ATTACK_GREEN:
                instance.audio.PlayOneShot(instance.attack_green);
                instance.audio.volume = 0.3f;
            break;

            case sound.FOLLOW:
                instance.audio.PlayOneShot(instance.follow);
                instance.audio.volume = 0.005f;
            break;

            case sound.HEAL:
                instance.audio.PlayOneShot(instance.heal);
                instance.audio.volume = 0.12f;
            break;

            case sound.DEATH_PLAYER:
                instance.audio.PlayOneShot(instance.death_player);
                instance.audio.volume = 0.3f;
            break;

            case sound.DEATH_ENEMY:
                instance.audio.PlayOneShot(instance.death_enemy);
                instance.audio.volume = 0.3f;
            break;
        }

    }
}
