using TMPro;
using UnityEngine;

// One numbered room of a topic scene. The StationNavigator tells it when inspect mode
// starts or stops; the station never changes the demo code, it only switches the demo's
// components on and off. Keep those components disabled in the saved scene.
public class Station : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private string title;
    [SerializeField, TextArea(3, 8)] private string info;
    [SerializeField] private Transform arrivalPoint;
    [SerializeField] private Vector3 roomSize = new Vector3(12f, 4f, 12f);

    [Header("Demo")]
    [SerializeField] private Behaviour[] demoBehaviours;   // run only while inspecting

    [Header("Labels")]
    [SerializeField] private TMP_Text numberLabel;
    [SerializeField] private TMP_Text titleLabel;
    [SerializeField] private TMP_Text panelTitleLabel;
    [SerializeField] private TMP_Text infoLabel;
    [SerializeField] private TMP_Text hintLabel;
    [SerializeField] private CanvasGroup infoPanel;
    [SerializeField] private float panelDistance = 6f;

    public int Number => number;
    public Transform ArrivalPoint => arrivalPoint;
    public bool HasDemo => demoBehaviours.Length > 0;

    void Awake()
    {
        infoPanel.alpha = 0f;
        SetInspecting(false);
    }

    public bool Contains(Vector3 point)
    {
        Bounds room = new Bounds(transform.position + Vector3.up * roomSize.y * 0.5f, roomSize);
        return room.Contains(point);
    }

    public void SetInspecting(bool inspecting)
    {
        foreach (Behaviour demo in demoBehaviours)
            demo.enabled = inspecting;

        if (!HasDemo) hintLabel.text = "";
        else hintLabel.text = inspecting ? "INSPECTING  ·  E to leave" : "E to inspect";
    }

    // Fades the info panel in while the player is close to it
    public void UpdatePanel(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(playerPosition, infoPanel.transform.position);
        float targetAlpha = distance < panelDistance ? 1f : 0f;
        infoPanel.alpha = Mathf.MoveTowards(infoPanel.alpha, targetAlpha, 3f * Time.deltaTime);
    }

    // Keeps the wall and panel text in sync with the fields while editing
    void OnValidate()
    {
        if (numberLabel) numberLabel.text = number.ToString("00");
        if (titleLabel) titleLabel.text = title;
        if (panelTitleLabel) panelTitleLabel.text = number.ToString("00") + "  " + title;
        if (infoLabel) infoLabel.text = info;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.up * roomSize.y * 0.5f, roomSize);
    }
}
