using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput_Joseph : MonoBehaviour
{
    public GameObject SelectedObject;
    private EventSystem system;
    private bool ButtonSelected;
    // Start is called before the first frame update
    void Start()
    {
        system = EventSystem.current;
        system.SetSelectedGameObject(SelectedObject);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxisRaw("Vertical") != 0) && ButtonSelected == false)
        {
            system.SetSelectedGameObject(SelectedObject);
            ButtonSelected = true;
        }
        if(system.currentSelectedGameObject == null)
        {
            system.SetSelectedGameObject(SelectedObject);
        }
    }

    private void OnDisable()
    {
        ButtonSelected = false;
    }

}
