using UnityEngine;
using UnityEngine.InputSystem;

// Moves the player between the stations of a topic scene and runs inspect mode.
// Number keys jump to a station, Tab to the next one, Shift+Tab to the previous one.
// E starts or stops inspecting the demo of the station the player is in: the player
// freezes, the cursor is freed, and the demo receives the keys.
public class StationNavigator : MonoBehaviour
{
    [SerializeField] private FirstPersonController player;
    [SerializeField] private Station[] stations;   // in order of their numbers

    private CharacterController playerBody;
    private Station current;
    private bool inspecting;

    void Awake()
    {
        playerBody = player.GetComponent<CharacterController>();
    }

    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (!inspecting)
        {
            current = FindStationAt(player.transform.position);
            ReadJumpKeys(keyboard);
        }

        if (keyboard.eKey.wasPressedThisFrame && current != null && current.HasDemo)
            SetInspecting(!inspecting);

        foreach (Station station in stations)
            station.UpdatePanel(player.transform.position);
    }

    void ReadJumpKeys(Keyboard keyboard)
    {
        foreach (Station station in stations)
            if (station.Number <= 9 && keyboard[DigitKey(station.Number)].wasPressedThisFrame)
                JumpTo(station);

        if (keyboard.tabKey.wasPressedThisFrame)
        {
            int step = keyboard.shiftKey.isPressed ? -1 : 1;
            int index = System.Array.IndexOf(stations, current);
            JumpTo(stations[(index + step + stations.Length) % stations.Length]);
        }
    }

    void JumpTo(Station station)
    {
        // A CharacterController overrides a direct position change, so switch it off for the move
        playerBody.enabled = false;
        float yaw = station.ArrivalPoint.eulerAngles.y;
        player.transform.SetPositionAndRotation(station.ArrivalPoint.position, Quaternion.Euler(0f, yaw, 0f));
        playerBody.enabled = true;
        current = station;
    }

    void SetInspecting(bool on)
    {
        inspecting = on;
        if (on)
        {
            player.enabled = false;
            // The player's OnDisable switches off the shared Move and Look actions;
            // demos that read them through InputSystem.actions need them back on.
            InputSystem.actions.Enable();
            current.SetInspecting(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            current.SetInspecting(false);
            player.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    Station FindStationAt(Vector3 position)
    {
        foreach (Station station in stations)
            if (station.Contains(position))
                return station;
        return null;
    }

    static Key DigitKey(int number)
    {
        return number == 0 ? Key.Digit0 : Key.Digit1 + (number - 1);
    }
}
