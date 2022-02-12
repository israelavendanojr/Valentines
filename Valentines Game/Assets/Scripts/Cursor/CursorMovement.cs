using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorMovement : MonoBehaviour
{

    public float speed;
    float x, y;
    PlayerControls playerControls;
    [SerializeField] GameObject buttonParent;
    [SerializeField] List<Transform> buttonPos;
    Transform targetPos;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Gameplay.Direction.started += context => OnMove(context);
    }
    private void Start()
    {
        FindButtons();
        //targetPos = buttonPos[0];
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    void Update()
    {

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();

        if (direction.x == -1)
            Move(-1);
        else if (direction.x == 1)
            Move(1);
        else if (direction.y == -1)
            Move(3);
        else if (direction.y == 1)
            Move(-3);

    }
    private void MoveCursor()
    {
        transform.position += new Vector3(x, y, 0) * Time.deltaTime * speed;

        Vector3 worldSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -worldSize.x, worldSize.x),
            Mathf.Clamp(transform.position.y, -worldSize.y, worldSize.y), transform.position.z);
    }
    public IEnumerator CO_FindButtons()
    {
        yield return new WaitForSeconds(.1f);
        buttonPos.Clear();

        foreach (Transform t in buttonParent.transform)
            buttonPos.Add(t);
    }
    public void FindButtons()
    {
        StartCoroutine(CO_FindButtons());
    }
    void Move(int direction)
    {
        int index = 0;

        for (int i = 0; i < buttonPos.Count; i++)
        {
            if (buttonPos[i] == targetPos)
                index = i;
        }

        int newIndex = index + direction;
        if (newIndex < 0 || buttonPos.Count <= newIndex)
            return;

        targetPos = buttonPos[newIndex];
        transform.position = targetPos.position;
    }
}