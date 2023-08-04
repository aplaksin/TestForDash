//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Scripts/PlayerControls.inputactions
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
            ""name"": ""Touch"",
            ""id"": ""9e8d3389-7ea5-4c47-8dee-707559b4613e"",
            ""actions"": [
                {
                    ""name"": ""TouchPrimary"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6449ab06-e335-4590-9754-b748470b61cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""Value"",
                    ""id"": ""6dfc1b8f-335c-4944-a418-f725a9371e8e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a666111c-5285-4623-b33d-f1adbd2fb161"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85aced25-bdd0-4195-8968-d9afb8c184e7"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keys"",
            ""id"": ""5122cdb5-442c-4b7f-8a76-cf1164d6c2c8"",
            ""actions"": [
                {
                    ""name"": ""W"",
                    ""type"": ""Button"",
                    ""id"": ""56c779b7-634d-47f1-a1ef-c362a0b62345"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c1712215-aa60-4599-822d-a620cb1788d6"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""W"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_TouchPrimary = m_Touch.FindAction("TouchPrimary", throwIfNotFound: true);
        m_Touch_TouchPosition = m_Touch.FindAction("TouchPosition", throwIfNotFound: true);
        // Keys
        m_Keys = asset.FindActionMap("Keys", throwIfNotFound: true);
        m_Keys_W = m_Keys.FindAction("W", throwIfNotFound: true);
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

    // Touch
    private readonly InputActionMap m_Touch;
    private List<ITouchActions> m_TouchActionsCallbackInterfaces = new List<ITouchActions>();
    private readonly InputAction m_Touch_TouchPrimary;
    private readonly InputAction m_Touch_TouchPosition;
    public struct TouchActions
    {
        private @PlayerControls m_Wrapper;
        public TouchActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPrimary => m_Wrapper.m_Touch_TouchPrimary;
        public InputAction @TouchPosition => m_Wrapper.m_Touch_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void AddCallbacks(ITouchActions instance)
        {
            if (instance == null || m_Wrapper.m_TouchActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TouchActionsCallbackInterfaces.Add(instance);
            @TouchPrimary.started += instance.OnTouchPrimary;
            @TouchPrimary.performed += instance.OnTouchPrimary;
            @TouchPrimary.canceled += instance.OnTouchPrimary;
            @TouchPosition.started += instance.OnTouchPosition;
            @TouchPosition.performed += instance.OnTouchPosition;
            @TouchPosition.canceled += instance.OnTouchPosition;
        }

        private void UnregisterCallbacks(ITouchActions instance)
        {
            @TouchPrimary.started -= instance.OnTouchPrimary;
            @TouchPrimary.performed -= instance.OnTouchPrimary;
            @TouchPrimary.canceled -= instance.OnTouchPrimary;
            @TouchPosition.started -= instance.OnTouchPosition;
            @TouchPosition.performed -= instance.OnTouchPosition;
            @TouchPosition.canceled -= instance.OnTouchPosition;
        }

        public void RemoveCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITouchActions instance)
        {
            foreach (var item in m_Wrapper.m_TouchActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TouchActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TouchActions @Touch => new TouchActions(this);

    // Keys
    private readonly InputActionMap m_Keys;
    private List<IKeysActions> m_KeysActionsCallbackInterfaces = new List<IKeysActions>();
    private readonly InputAction m_Keys_W;
    public struct KeysActions
    {
        private @PlayerControls m_Wrapper;
        public KeysActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @W => m_Wrapper.m_Keys_W;
        public InputActionMap Get() { return m_Wrapper.m_Keys; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeysActions set) { return set.Get(); }
        public void AddCallbacks(IKeysActions instance)
        {
            if (instance == null || m_Wrapper.m_KeysActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_KeysActionsCallbackInterfaces.Add(instance);
            @W.started += instance.OnW;
            @W.performed += instance.OnW;
            @W.canceled += instance.OnW;
        }

        private void UnregisterCallbacks(IKeysActions instance)
        {
            @W.started -= instance.OnW;
            @W.performed -= instance.OnW;
            @W.canceled -= instance.OnW;
        }

        public void RemoveCallbacks(IKeysActions instance)
        {
            if (m_Wrapper.m_KeysActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IKeysActions instance)
        {
            foreach (var item in m_Wrapper.m_KeysActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_KeysActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public KeysActions @Keys => new KeysActions(this);
    public interface ITouchActions
    {
        void OnTouchPrimary(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
    public interface IKeysActions
    {
        void OnW(InputAction.CallbackContext context);
    }
}