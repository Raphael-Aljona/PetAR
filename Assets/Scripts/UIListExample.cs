using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class UIListExample : MonoBehaviour
{
    [System.Serializable]
    public class ItemData
    {
        public string Nome;
        public float Preco;
        public Sprite imagemExibicao;
        public GameObject Objeto;
        public string link;
    }

    public List<ItemData> data = new();
    public VisualTreeAsset itemRowTemplate;
    public ObjectSpawner spawner;
    public UIManager ui;
    public ListView list;

    void Awake()
    {
        var doc = GetComponent<UIDocument>();
        var root = doc.rootVisualElement;
        list = root.Q<ListView>("lista");

        list.selectionType = SelectionType.None;

        var sv = list.Q<ScrollView>();
        sv.mode = ScrollViewMode.Vertical;
        sv.touchScrollBehavior = ScrollView.TouchScrollBehavior.Clamped;
        sv.elasticity = 0f;

        list.itemsSource = data;

        list.fixedItemHeight = 180;
        list.makeItem = () => itemRowTemplate.CloneTree();

        list.bindItem = (ve, i) =>
        {
            var d = data[i];
            var img = ve.Q<Image>("thumb");

            ve.pickingMode = PickingMode.Ignore;
            ve.RegisterCallback<PointerDownEvent>(e => e.StopImmediatePropagation());
            ve.RegisterCallback<PointerUpEvent>(e => e.StopImmediatePropagation());
            ve.RegisterCallback<ClickEvent>(e => e.StopImmediatePropagation());

            if (img != null && d.imagemExibicao != null)
            {
                img.image = d.imagemExibicao.texture;
                img.scaleMode = ScaleMode.StretchToFill;
            }
            else
            {
                img.image = null;
            }

            ve.Q<Label>("title").text = d.Nome;
            ve.Q<Label>("price").text = $"R$: " + d.Preco.ToString("F2");

            var btn = ve.Q<Button>("action");
            
            if (btn.userData is System.Action old)
                btn.clicked -= old;

            System.Action action = () => ClickItem(d);
            btn.userData = action;
            btn.clicked += action;
        };

    }

    public void ClickItem(ItemData item)
    {
        Debug.Log($"Item clicked: {item.Nome}");
        spawner.objectToSpawn = item.Objeto;
        ui.CloseItems();
        ui.EnableButton();
        ui.url = item.link;
    }
}