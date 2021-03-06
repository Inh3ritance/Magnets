﻿using UnityEngine;
using System.Collections.Generic;
using MovementEffects;

public class FluidController : MonoBehaviour {

    public Particle[] particles;
    bool spawning;
    bool spawned;

    //Spawn In Particles
    public void Spawn()
    {
        spawning = true;
        Timing.RunCoroutine(_spawn(false));
    }

    public void SpawnFive()
    {
        spawning = true;
        Timing.RunCoroutine(_spawn(true));
    }

    public bool HasSpawned()
    {
        return !spawning && spawned;
    }

    public void ResetSpawnInfo()
    {
        spawning = false;
        spawned = false;
    }

    //In Case we Change Particle Amount Later
    public int ParticleAmount()
    {
        return particles.Length;
    }

    public int NumberActive()
    {
        int x = 0;
        for(int i = 0; i < particles.Length; i++)
        {
            if (particles[i].Visible())
            {
                x++;
            }
        }
        return x;
    }

    //Use These Coroutines (Spawns five particles if ad was watched)
    IEnumerator<float> _spawn(bool five)
    {
        int x = five ? 6 : particles.Length;
        for(int i = 1; i < particles.Length; i++)
        {
            particles[i].SetPitch(particles[i - 1].GetPitch() + 0.1f);
            particles[i].Spawning = true;
            particles[i].spawnSound.enabled = true;
        }
        for(int i = 0; i < x; i++)
        {
            particles[i].gameObject.SetActive(true);
            particles[i].Spawning = true;
            particles[i].SpawnSound();
            particles[i].transform.position = new Vector2(Random.Range(.15f, .38f), Random.Range(.15f, .38f));
            yield return Timing.WaitForSeconds(0.05f);
        }
        for(int i = 0; i < particles.Length; i++)
        {   
            particles[i].SetPitch(1.0f);
            particles[i].Spawning = false;
        }
        spawning = false;
        spawned = true;
    }
}
