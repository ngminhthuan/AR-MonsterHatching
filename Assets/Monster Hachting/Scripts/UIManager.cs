using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject GameView;
    [SerializeField] GameObject PausePopup;
    void Start()
    {
        GameView.SetActive(true);
        PausePopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
