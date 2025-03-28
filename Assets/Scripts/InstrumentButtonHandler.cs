using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentButtonHandler : MonoBehaviour
{
    [SerializeField] private InstrumentSO item;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        SoundManager.Instance.SetSelectedInstrument(item);
    }
}
