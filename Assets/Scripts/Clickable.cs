using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{


    private IClickHandler callback;
    public GameObject hoverIndicator;
    // Start is called before the first frame update
    void Start()
    {
        if(!TryGetComponent<IClickHandler>(out callback)) {
            callback = new DummyClick();
        }
        hoverIndicator.SetActive(false);
        Debug.Log("we got here");
    }

    // Update is called once per frame
    private void OnMouseEnter() {
        hoverIndicator.SetActive(true);
        Debug.Log("why though");
        callback.DoHoverEnter();
    }
    private void OnMouseExit() {
        hoverIndicator.SetActive(false);
        callback.DoHoverLeave();
    }
    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0)) {
            callback.DoClick();
        }
    }
}

public interface IClickHandler {
    public void DoClick();
    public void DoHoverEnter();
    public void DoHoverLeave();
}

public class DummyClick : IClickHandler {
    public void DoClick() {
    }

    public void DoHoverEnter() {
    }

    public void DoHoverLeave() {
    }
}