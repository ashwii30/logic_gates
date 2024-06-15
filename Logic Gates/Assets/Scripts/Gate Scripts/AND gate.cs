using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ANDGate : MonoBehaviour
{
    public XRBaseInteractable buttonA;
    public XRBaseInteractable buttonB;
    public Light lightSource;
    public GameObject wireA1;
    public GameObject wireA2;
    public GameObject wireB1;
    public GameObject wireB2;
    public GameObject wireOutput;
    public GameObject indicatorSphereA;
    public GameObject indicatorSphereB;
    public Material onMaterial; // Material for when the switch is on
    public Material offMaterial; // Material for when the switch is off

    private Material wireA1Material;
    private Material wireA2Material;
    private Material wireB1Material;
    private Material wireB2Material;
    private Material wireOutputMaterial;

    private Material sphereAMaterial;
    private Material sphereBMaterial;

    private void Start()
    {
        // Initialize to off state
        wireA1Material = offMaterial;
        wireA2Material = offMaterial;
        wireB1Material = offMaterial;
        wireB2Material = offMaterial;
        wireOutputMaterial = offMaterial;
        sphereAMaterial = offMaterial;
        sphereBMaterial = offMaterial;
        lightSource.enabled = false;

        // Subscribe to the button events
        buttonA.onSelectEntered.AddListener(OnButtonStateChanged);
        buttonA.onSelectExited.AddListener(OnButtonStateChanged);

        buttonB.onSelectEntered.AddListener(OnButtonStateChanged);
        buttonB.onSelectExited.AddListener(OnButtonStateChanged);
    }

    private void OnButtonStateChanged(XRBaseInteractor interactor)
    {
        // Check the state of both buttons
        bool buttonAIsOn = buttonA.isSelected;
        bool buttonBIsOn = buttonB.isSelected;

        // Update the light source based on the AND gate logic
        bool isLightOn = buttonAIsOn && buttonBIsOn;
        lightSource.enabled = isLightOn;

        // Change the materials of the wires and indicator spheres based on the AND gate logic
        wireA1Material = buttonAIsOn ? onMaterial : offMaterial;
        wireA2Material = buttonAIsOn ? onMaterial : offMaterial;
        wireB1Material = buttonBIsOn ? onMaterial : offMaterial;
        wireB2Material = buttonBIsOn ? onMaterial : offMaterial;
        wireOutputMaterial = isLightOn ? onMaterial : offMaterial;
        sphereAMaterial = buttonAIsOn ? onMaterial : offMaterial;
        sphereBMaterial = buttonBIsOn ? onMaterial : offMaterial;
    }
}
