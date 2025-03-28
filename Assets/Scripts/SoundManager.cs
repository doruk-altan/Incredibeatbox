using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public static event EventHandler<OnInstrumentPlacedArgs> OnPickedInstrument;

    private InstrumentSO selectedInstrument;

    //private float volume = .5f;

    public const float MEASURE_IN_REAL_TIME = 1.875f;

    public float totalTime;

    public class OnInstrumentPlacedArgs : EventArgs
    {
        public InstrumentSO instrumentSO;
        public Beatboxer beatboxer;
    }


    private void Awake()
    {
        Instance = this;
        totalTime = 0;
    }


    private void Update()
    {

        if(totalTime != 0)
        {
            totalTime -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && selectedInstrument != null)
        {

            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var touchPos = new Vector2(position.x, position.y);
            Collider2D hit = Physics2D.OverlapPoint(touchPos);

            //If an instrument is selected and clicked on a beatboxer
            //Set instrument on beatboxer
            if (hit != null && hit.gameObject.TryGetComponent<Beatboxer>(out Beatboxer beatboxer))
            {
                if (totalTime == 0f)
                {
                    totalTime -= Time.deltaTime;
                }

                OnPickedInstrument?.Invoke(this, new OnInstrumentPlacedArgs
                {
                    instrumentSO = selectedInstrument,
                    beatboxer = beatboxer
                }) ;
            }

            //set selected instrument to null
            else
            {
                ClearSelectedInstrument();
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var touchPos = new Vector2(position.x, position.y);
            Collider2D hit = Physics2D.OverlapPoint(touchPos);

            //Reset selected instrument if clicked on empty area
            if (selectedInstrument != null)
            {
                ClearSelectedInstrument();
            }

            //If right cliked on beatboxer, destroy instrument
            if (hit != null && hit.gameObject.TryGetComponent<Beatboxer>(out Beatboxer beatboxer))
            {
                beatboxer.GetInstrument().DestroySelf();
            }

        }
        
    }

    public void SetSelectedInstrument(InstrumentSO instrumentSO)
    {
        if(instrumentSO != null)
        {
            selectedInstrument = instrumentSO;
            GameManager.Instance.SetCustomCursor(instrumentSO.prefab.GetComponent<SpriteRenderer>().sprite);
        }
        
    }

    public void ClearSelectedInstrument()
    {
        GameManager.Instance.ClearCustomCursor();
        selectedInstrument = null;
    }

}
