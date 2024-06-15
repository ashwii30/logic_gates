using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NOTGate : MonoBehaviour
{
    public XRBaseInteractable button;
    public Light lightSource;
    public GameObject wire;
    public GameObject indicatorSphere;
    public Material onMaterial; // Material for when the switch is on
    public Material offMaterial; // Material for when the switch is off

    private Material wireMaterial;
    private Material sphereMaterial;

    private bool isLightOn;

    private void Start()
    {
        // Initialize to off state
        wireMaterial = wire.GetComponent<Renderer>().material;
        sphereMaterial = indicatorSphere.GetComponent<Renderer>().material;
        SetMaterialsToOffState();
    }

    private void SetMaterialsToOffState()
    {
        wireMaterial = offMaterial;
        sphereMaterial = offMaterial;
        lightSource.enabled = false;
        isLightOn = false;
    }

    private void OnButtonStateChanged(XRBaseInteractor interactor)
    {
        // Check the state of the button
        bool buttonIsOn = button.isSelected;

        // Update the light source and materials based on the NOT gate logic
        isLightOn = !buttonIsOn;
        lightSource.enabled = isLightOn;
        wireMaterial = isLightOn ? onMaterial : offMaterial;
        sphereMaterial = buttonIsOn ? onMaterial : offMaterial;
    }
}
