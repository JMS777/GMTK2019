using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource ad;

    public List<AudioClip> steps;

    public AudioClip Jump;
    public AudioClip Falling;
    public AudioClip Charge;
    public AudioClip ShootUp;
    public AudioClip Death;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundSteps()
    {
        int rand = Random.Range(1, 3);

        ad.clip = steps[rand];
        ad.Play(0);
    }

    public void SoundJump()
    {
        ad.clip = Jump;
        ad.Play(0);
    }

    public void SoundFalling()
    {
        ad.clip = Falling;
        ad.Play(0);
    }

    public void SoundCharge()
    {
        ad.clip = Charge;
        //ad.Play(0);
    }

    public void SoundDeath()
    {
        ad.clip = Death;
        ad.Play(0);
    }
}
