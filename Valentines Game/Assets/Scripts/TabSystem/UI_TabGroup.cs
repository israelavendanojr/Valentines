using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TabGroup : MonoBehaviour
{
    List<UI_TabButton> _tabButtons;
    [SerializeField] List<GameObject> _tabPages;

    [SerializeField] Sprite _idleSprite, _hoverSprite, _selectedSprite;
    UI_TabButton _selectedTab;

    public void Subscribe(UI_TabButton button)
    {
        if (_tabButtons == null)
            _tabButtons = new List<UI_TabButton>();

        _tabButtons.Add(button);
    }
    public void OnTabEnter(UI_TabButton button)
    {
        ResetTabs();
        if (_selectedTab == null || button != _selectedTab)
            button.background.sprite = _hoverSprite;
    }
    public void OnTabExit(UI_TabButton button)
    {
        ResetTabs();
    }
    public void OnTabSelected(UI_TabButton button)
    {
        if (_selectedTab != null)
            _selectedTab.Deselect();
        _selectedTab = button;
        _selectedTab.Select();

        ResetTabs();
        button.background.sprite = _selectedSprite;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < _tabPages.Count; i++)
        {
            if (i == index)
                _tabPages[i].SetActive(true);
            else
                _tabPages[i].SetActive(false);
        }
    }

    void ResetTabs()
    {
        for (int i = 0; i < _tabButtons.Count; i++)
        {
            if (_selectedTab == null || _tabButtons[i] != _selectedTab)
                _tabButtons[i].background.sprite = _idleSprite;
        }
    }
}
