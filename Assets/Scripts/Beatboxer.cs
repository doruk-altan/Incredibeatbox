using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beatboxer : MonoBehaviour , IInstrumentParent
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private Instrument instrument;

    private float volume = .5f;

    private bool isActive = false;
    private bool isOnRythm = false;
    private bool onQueue = false;

    private float measureInterval;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
    }

    private void Update()
    {

        if (onQueue)
        {

            if (Mathf.Round(SoundManager.Instance.totalTime * 100.0f) * 0.01f == 0f)
            {
                isOnRythm = true;
            }
            else if (Mathf.Round(((-SoundManager.Instance.totalTime / SoundManager.MEASURE_IN_REAL_TIME) % instrument.GetInstrumentSO().measureCount) * 100.0f) * 0.01f == 0f)
            {
                isOnRythm = true;
            }

            if (isOnRythm && !isActive)
            {
                this.audioSource.Play();
                this.isActive = true;
            }
        }
        
    }

    private void Start()
    {
        SoundManager.OnPickedInstrument += SoundManager_OnPickedInstrument;
    }

    private void SoundManager_OnPickedInstrument(object sender, SoundManager.OnInstrumentPlacedArgs e)
    {

        e.beatboxer.SetInstrument(Instrument.SpawnInstrument(e.instrumentSO,e.beatboxer));
        e.beatboxer.audioSource.clip = e.instrumentSO.clip;
        e.beatboxer.onQueue = true;



        SoundManager.Instance.SetSelectedInstrument(null);

    }

    public bool IsActive()
    {
        return isActive;
    }

    public Instrument GetInstrument()
    {
        return instrument;
    }

    public void SetInstrument(Instrument instrument)
    {
        if(this.instrument != null)
        {
            this.instrument.DestroySelf();

        }

        this.instrument = instrument;
    }

    public void ClearInstrument()
    {
        audioSource.clip = null;
        instrument = null;
        isActive = false;
        isOnRythm = false;
        onQueue = false;
    }

    public bool HasInstrument()
    {
        return (instrument != null);
    }

}
