//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/SummoningGameInput.inputactions
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

public partial class @SummoningGameInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @SummoningGameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SummoningGameInput"",
    ""maps"": [
        {
            ""name"": ""Summoning"",
            ""id"": ""158b37e0-357d-4e65-8fcc-f46dc55ecddb"",
            ""actions"": [
                {
                    ""name"": ""Ingredient1"",
                    ""type"": ""Button"",
                    ""id"": ""62e7df3a-0da1-4748-87f5-37d077ed47b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ingredient2"",
                    ""type"": ""Button"",
                    ""id"": ""2c509e1d-eb99-4850-9e8b-9a379ffa94d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ingredient3"",
                    ""type"": ""Button"",
                    ""id"": ""c2771e26-38e6-41e2-a596-78ab6556252e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ingredient4"",
                    ""type"": ""Button"",
                    ""id"": ""0a994140-550a-4cdb-b07c-20d7a82dec61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DiscardIngredients"",
                    ""type"": ""Button"",
                    ""id"": ""f760100e-214f-43e6-836a-9ff810ec15e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CheckOrder"",
                    ""type"": ""Button"",
                    ""id"": ""d822a6eb-b5f6-4ade-a8b8-692cdf79ccda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuitGame"",
                    ""type"": ""Button"",
                    ""id"": ""460c4115-ada7-48c5-9db5-8652bafb2c9b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextDescription"",
                    ""type"": ""Button"",
                    ""id"": ""4fd53dee-1a3a-4337-8a82-ef86617b005f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2f4cc7d1-47e6-46f0-8fb4-7e94f42d25f4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ingredient1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0680d87-5f85-47b0-99ac-294788ccbb37"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ingredient2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ecfee94-9d99-430f-a084-50860acc1c60"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ingredient3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3bc58f6-6689-4ead-9dbf-242e4b7526f3"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ingredient4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""990d8fab-c956-48e8-9454-ff2a5d07da91"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DiscardIngredients"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa03f6a0-c498-4431-93bc-5569ac05bde5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CheckOrder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cb338f8-55cf-48cb-8d85-5b9d093199f2"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuitGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65a873ad-2a79-42ca-9f7e-970d7a6ea737"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextDescription"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Summoning
        m_Summoning = asset.FindActionMap("Summoning", throwIfNotFound: true);
        m_Summoning_Ingredient1 = m_Summoning.FindAction("Ingredient1", throwIfNotFound: true);
        m_Summoning_Ingredient2 = m_Summoning.FindAction("Ingredient2", throwIfNotFound: true);
        m_Summoning_Ingredient3 = m_Summoning.FindAction("Ingredient3", throwIfNotFound: true);
        m_Summoning_Ingredient4 = m_Summoning.FindAction("Ingredient4", throwIfNotFound: true);
        m_Summoning_DiscardIngredients = m_Summoning.FindAction("DiscardIngredients", throwIfNotFound: true);
        m_Summoning_CheckOrder = m_Summoning.FindAction("CheckOrder", throwIfNotFound: true);
        m_Summoning_QuitGame = m_Summoning.FindAction("QuitGame", throwIfNotFound: true);
        m_Summoning_NextDescription = m_Summoning.FindAction("NextDescription", throwIfNotFound: true);
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

    // Summoning
    private readonly InputActionMap m_Summoning;
    private List<ISummoningActions> m_SummoningActionsCallbackInterfaces = new List<ISummoningActions>();
    private readonly InputAction m_Summoning_Ingredient1;
    private readonly InputAction m_Summoning_Ingredient2;
    private readonly InputAction m_Summoning_Ingredient3;
    private readonly InputAction m_Summoning_Ingredient4;
    private readonly InputAction m_Summoning_DiscardIngredients;
    private readonly InputAction m_Summoning_CheckOrder;
    private readonly InputAction m_Summoning_QuitGame;
    private readonly InputAction m_Summoning_NextDescription;
    public struct SummoningActions
    {
        private @SummoningGameInput m_Wrapper;
        public SummoningActions(@SummoningGameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Ingredient1 => m_Wrapper.m_Summoning_Ingredient1;
        public InputAction @Ingredient2 => m_Wrapper.m_Summoning_Ingredient2;
        public InputAction @Ingredient3 => m_Wrapper.m_Summoning_Ingredient3;
        public InputAction @Ingredient4 => m_Wrapper.m_Summoning_Ingredient4;
        public InputAction @DiscardIngredients => m_Wrapper.m_Summoning_DiscardIngredients;
        public InputAction @CheckOrder => m_Wrapper.m_Summoning_CheckOrder;
        public InputAction @QuitGame => m_Wrapper.m_Summoning_QuitGame;
        public InputAction @NextDescription => m_Wrapper.m_Summoning_NextDescription;
        public InputActionMap Get() { return m_Wrapper.m_Summoning; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SummoningActions set) { return set.Get(); }
        public void AddCallbacks(ISummoningActions instance)
        {
            if (instance == null || m_Wrapper.m_SummoningActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SummoningActionsCallbackInterfaces.Add(instance);
            @Ingredient1.started += instance.OnIngredient1;
            @Ingredient1.performed += instance.OnIngredient1;
            @Ingredient1.canceled += instance.OnIngredient1;
            @Ingredient2.started += instance.OnIngredient2;
            @Ingredient2.performed += instance.OnIngredient2;
            @Ingredient2.canceled += instance.OnIngredient2;
            @Ingredient3.started += instance.OnIngredient3;
            @Ingredient3.performed += instance.OnIngredient3;
            @Ingredient3.canceled += instance.OnIngredient3;
            @Ingredient4.started += instance.OnIngredient4;
            @Ingredient4.performed += instance.OnIngredient4;
            @Ingredient4.canceled += instance.OnIngredient4;
            @DiscardIngredients.started += instance.OnDiscardIngredients;
            @DiscardIngredients.performed += instance.OnDiscardIngredients;
            @DiscardIngredients.canceled += instance.OnDiscardIngredients;
            @CheckOrder.started += instance.OnCheckOrder;
            @CheckOrder.performed += instance.OnCheckOrder;
            @CheckOrder.canceled += instance.OnCheckOrder;
            @QuitGame.started += instance.OnQuitGame;
            @QuitGame.performed += instance.OnQuitGame;
            @QuitGame.canceled += instance.OnQuitGame;
            @NextDescription.started += instance.OnNextDescription;
            @NextDescription.performed += instance.OnNextDescription;
            @NextDescription.canceled += instance.OnNextDescription;
        }

        private void UnregisterCallbacks(ISummoningActions instance)
        {
            @Ingredient1.started -= instance.OnIngredient1;
            @Ingredient1.performed -= instance.OnIngredient1;
            @Ingredient1.canceled -= instance.OnIngredient1;
            @Ingredient2.started -= instance.OnIngredient2;
            @Ingredient2.performed -= instance.OnIngredient2;
            @Ingredient2.canceled -= instance.OnIngredient2;
            @Ingredient3.started -= instance.OnIngredient3;
            @Ingredient3.performed -= instance.OnIngredient3;
            @Ingredient3.canceled -= instance.OnIngredient3;
            @Ingredient4.started -= instance.OnIngredient4;
            @Ingredient4.performed -= instance.OnIngredient4;
            @Ingredient4.canceled -= instance.OnIngredient4;
            @DiscardIngredients.started -= instance.OnDiscardIngredients;
            @DiscardIngredients.performed -= instance.OnDiscardIngredients;
            @DiscardIngredients.canceled -= instance.OnDiscardIngredients;
            @CheckOrder.started -= instance.OnCheckOrder;
            @CheckOrder.performed -= instance.OnCheckOrder;
            @CheckOrder.canceled -= instance.OnCheckOrder;
            @QuitGame.started -= instance.OnQuitGame;
            @QuitGame.performed -= instance.OnQuitGame;
            @QuitGame.canceled -= instance.OnQuitGame;
            @NextDescription.started -= instance.OnNextDescription;
            @NextDescription.performed -= instance.OnNextDescription;
            @NextDescription.canceled -= instance.OnNextDescription;
        }

        public void RemoveCallbacks(ISummoningActions instance)
        {
            if (m_Wrapper.m_SummoningActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISummoningActions instance)
        {
            foreach (var item in m_Wrapper.m_SummoningActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SummoningActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SummoningActions @Summoning => new SummoningActions(this);
    public interface ISummoningActions
    {
        void OnIngredient1(InputAction.CallbackContext context);
        void OnIngredient2(InputAction.CallbackContext context);
        void OnIngredient3(InputAction.CallbackContext context);
        void OnIngredient4(InputAction.CallbackContext context);
        void OnDiscardIngredients(InputAction.CallbackContext context);
        void OnCheckOrder(InputAction.CallbackContext context);
        void OnQuitGame(InputAction.CallbackContext context);
        void OnNextDescription(InputAction.CallbackContext context);
    }
}
