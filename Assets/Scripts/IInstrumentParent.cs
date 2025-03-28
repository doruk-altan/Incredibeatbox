using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInstrumentParent
{
    public Instrument GetInstrument();

    public void SetInstrument(Instrument instrument);

    public void ClearInstrument();

    public bool HasInstrument();
}
