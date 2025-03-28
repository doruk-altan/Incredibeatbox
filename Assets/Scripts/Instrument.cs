using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
{
    private InstrumentSO instrumentSO;
    private IInstrumentParent instrumentParent;

    public InstrumentSO GetInstrumentSO()
    {
        return instrumentSO;
    }

    public void SetInstrumentSO(InstrumentSO instrumentSO)
    {
        this.instrumentSO = instrumentSO;
    }

    public IInstrumentParent GetInstrumentParent()
    {
        return instrumentParent;
    }

    public void SetInstrumentParent(IInstrumentParent parent)
    {
        instrumentParent = parent;
    }

    public static Instrument SpawnInstrument(InstrumentSO instrumentSO,IInstrumentParent parent)
    {
        Transform instrumentTransform = Instantiate(instrumentSO.prefab, (parent as Beatboxer).transform.position, Quaternion.identity);

        Instrument instrument = instrumentTransform.GetComponent<Instrument>();
        instrument.SetInstrumentSO(instrumentSO);
        instrument.SetInstrumentParent(parent);


        return instrument;
    }

    public void DestroySelf()
    {
        instrumentParent.ClearInstrument();
        Destroy(gameObject);
    }
}
