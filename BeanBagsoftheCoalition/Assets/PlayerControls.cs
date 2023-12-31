//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""d3c57521-86f2-4d9a-91f6-adbc4281803e"",
            ""actions"": [
                {
                    ""name"": ""rightStick"",
                    ""type"": ""Value"",
                    ""id"": ""0653d700-cde7-4140-9cfe-628535b2940b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""leftStick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4605fe27-3549-43c9-8160-d38587aac188"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""6a2861ad-d2a7-474d-943c-c4a28490b8d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""96ede27b-e51d-43d4-aa27-97a15cd44179"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b07c2cfe-1d0b-428c-9eea-bbac96905116"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""81097d2c-fd5b-4bf2-829b-b75435780e7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ADS"",
                    ""type"": ""Button"",
                    ""id"": ""dca12724-d5fb-486a-8b27-e4ed78f6f9b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""2b38994d-15ac-4ef3-952e-3db40dd34646"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Options"",
                    ""type"": ""Button"",
                    ""id"": ""8f3084cc-5949-45b1-b83c-3100085b4aa6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UIMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""386274d7-5271-4a71-b6bf-88fe53406ee2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b5fc8348-da34-4490-a4e1-493f1dbbea51"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""rightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c12d11a-c332-4872-a9db-a54cbb1033ce"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""leftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04e8794e-3ecd-474c-95ec-331f6f5bb795"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a19a3237-8176-4e5a-85da-6b86f94de84b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10a2d378-3ec6-4da4-92cc-4a124e5e0a3a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""137f103a-bee9-4cb0-b212-be1cfc7f6906"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98d7458b-0b14-4b7e-ba3e-b2049d2d8835"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1a9b030-3e6d-4018-9f29-2b0f36ca577d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ADS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15086ac5-a2f1-41db-a313-c29ca02bc121"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3652a91-0a84-46c2-b6cc-1c9d4c9943e7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""976c0b69-99d9-4491-ac72-256a9a4cdb3d"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Options"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e81c96e8-7de1-4593-898e-39a93b08fa4c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82331572-3916-4bae-9fb5-9ff08be225b4"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""67492931-1b70-469a-93ca-865cff57492d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f04aa4c1-23c7-4f6a-aebb-1a2eb93bfa3b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""82eaf08d-7ae8-4d9e-8fb9-22a12c56714d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3eb8b879-b330-4a20-9572-8ad94fed3c4f"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_rightStick = m_Gameplay.FindAction("rightStick", throwIfNotFound: true);
        m_Gameplay_leftStick = m_Gameplay.FindAction("leftStick", throwIfNotFound: true);
        m_Gameplay_Fire = m_Gameplay.FindAction("Fire", throwIfNotFound: true);
        m_Gameplay_Reload = m_Gameplay.FindAction("Reload", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Sprint = m_Gameplay.FindAction("Sprint", throwIfNotFound: true);
        m_Gameplay_ADS = m_Gameplay.FindAction("ADS", throwIfNotFound: true);
        m_Gameplay_Crouch = m_Gameplay.FindAction("Crouch", throwIfNotFound: true);
        m_Gameplay_Options = m_Gameplay.FindAction("Options", throwIfNotFound: true);
        m_Gameplay_UIMovement = m_Gameplay.FindAction("UIMovement", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Movement = m_UI.FindAction("Movement", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_rightStick;
    private readonly InputAction m_Gameplay_leftStick;
    private readonly InputAction m_Gameplay_Fire;
    private readonly InputAction m_Gameplay_Reload;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Sprint;
    private readonly InputAction m_Gameplay_ADS;
    private readonly InputAction m_Gameplay_Crouch;
    private readonly InputAction m_Gameplay_Options;
    private readonly InputAction m_Gameplay_UIMovement;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @rightStick => m_Wrapper.m_Gameplay_rightStick;
        public InputAction @leftStick => m_Wrapper.m_Gameplay_leftStick;
        public InputAction @Fire => m_Wrapper.m_Gameplay_Fire;
        public InputAction @Reload => m_Wrapper.m_Gameplay_Reload;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Sprint => m_Wrapper.m_Gameplay_Sprint;
        public InputAction @ADS => m_Wrapper.m_Gameplay_ADS;
        public InputAction @Crouch => m_Wrapper.m_Gameplay_Crouch;
        public InputAction @Options => m_Wrapper.m_Gameplay_Options;
        public InputAction @UIMovement => m_Wrapper.m_Gameplay_UIMovement;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @rightStick.started += instance.OnRightStick;
            @rightStick.performed += instance.OnRightStick;
            @rightStick.canceled += instance.OnRightStick;
            @leftStick.started += instance.OnLeftStick;
            @leftStick.performed += instance.OnLeftStick;
            @leftStick.canceled += instance.OnLeftStick;
            @Fire.started += instance.OnFire;
            @Fire.performed += instance.OnFire;
            @Fire.canceled += instance.OnFire;
            @Reload.started += instance.OnReload;
            @Reload.performed += instance.OnReload;
            @Reload.canceled += instance.OnReload;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
            @ADS.started += instance.OnADS;
            @ADS.performed += instance.OnADS;
            @ADS.canceled += instance.OnADS;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
            @Options.started += instance.OnOptions;
            @Options.performed += instance.OnOptions;
            @Options.canceled += instance.OnOptions;
            @UIMovement.started += instance.OnUIMovement;
            @UIMovement.performed += instance.OnUIMovement;
            @UIMovement.canceled += instance.OnUIMovement;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @rightStick.started -= instance.OnRightStick;
            @rightStick.performed -= instance.OnRightStick;
            @rightStick.canceled -= instance.OnRightStick;
            @leftStick.started -= instance.OnLeftStick;
            @leftStick.performed -= instance.OnLeftStick;
            @leftStick.canceled -= instance.OnLeftStick;
            @Fire.started -= instance.OnFire;
            @Fire.performed -= instance.OnFire;
            @Fire.canceled -= instance.OnFire;
            @Reload.started -= instance.OnReload;
            @Reload.performed -= instance.OnReload;
            @Reload.canceled -= instance.OnReload;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
            @ADS.started -= instance.OnADS;
            @ADS.performed -= instance.OnADS;
            @ADS.canceled -= instance.OnADS;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
            @Options.started -= instance.OnOptions;
            @Options.performed -= instance.OnOptions;
            @Options.canceled -= instance.OnOptions;
            @UIMovement.started -= instance.OnUIMovement;
            @UIMovement.performed -= instance.OnUIMovement;
            @UIMovement.canceled -= instance.OnUIMovement;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Movement;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_UI_Movement;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IGameplayActions
    {
        void OnRightStick(InputAction.CallbackContext context);
        void OnLeftStick(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnADS(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnOptions(InputAction.CallbackContext context);
        void OnUIMovement(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
}
