using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private CustomCursor customCursor;

    private void Awake()
    {
        Instance = this;
    }

    public void SetCustomCursor(Sprite sprite)
    {
        customCursor.GetComponent<SpriteRenderer>().sprite = sprite;
        customCursor.gameObject.SetActive(true);
        Cursor.visible = false;
    }

    public void ClearCustomCursor()
    {
        customCursor.gameObject.SetActive(false);
        Cursor.visible = true;

    }

    public void Quit()
    {
        Application.Quit();
    }
}
