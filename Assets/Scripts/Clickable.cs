using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{


    private IClickHandler callback;
    public GameObject hoverIndicator = null;
    // Start is called before the first frame update
    void Start()
    {
        if(!TryGetComponent(out callback)) {
            callback = new DummyClick();
        }
        if(hoverIndicator == null) {
            hoverIndicator = new GameObject();
        }
        hoverIndicator.SetActive(false);
    }

    // Update is called once per frame
    private void OnMouseEnter() {
        hoverIndicator.SetActive(true);
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