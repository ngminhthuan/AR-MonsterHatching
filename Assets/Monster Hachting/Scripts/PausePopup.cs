using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePopup : MonoBehaviour
{
    [SerializeField] Button _resumeBtn;
    [SerializeField] Button _quitBtn;
    // Start is called before the first frame update
    void Start()
    {
        _resumeBtn.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
        });
        _quitBtn.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
                            Application.Quit();
#endif
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
