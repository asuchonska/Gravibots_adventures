using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Text _livestext;

    public void UpdateLives(int health)
    {
        _livestext.text = "Lives: " + health;
    }
}
