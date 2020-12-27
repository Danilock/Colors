using System;
using System.Collections;
using System.Collections.Generic;
using Game.Coins;
using Game.Color_System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class CoinCreatorWindow : EditorWindow
{
    private Sprite m_CoinImage;
    private ColorManager.objColor m_CoinColor;
    private RuntimeAnimatorController m_RuntineController;
    private int m_AmountToInstantiate = 1;

    #region Initialize Window
    [MenuItem("MyTools/Coin Creator")]
    static void Init()
    {
        CoinCreatorWindow coinCreatorWindow =
            (CoinCreatorWindow) EditorWindow.GetWindow(typeof(CoinCreatorWindow));
        coinCreatorWindow.position = new Rect(100f, 100f, 500f, 200f);
        coinCreatorWindow.Show();
    }
    #endregion

    private void OnGUI()
    {
        m_CoinImage = (Sprite) EditorGUILayout.ObjectField("Coin Sprite", m_CoinImage, typeof(Sprite), false);
        m_CoinColor = (ColorManager.objColor) EditorGUILayout.EnumPopup("Coin Color:", m_CoinColor);
        m_RuntineController = (RuntimeAnimatorController) EditorGUILayout.ObjectField("Animator Controller", m_RuntineController, typeof(RuntimeAnimatorController), false);
        m_AmountToInstantiate = EditorGUILayout.IntField("Amount", m_AmountToInstantiate);

        if (GUILayout.Button("Generate Coin/s"))
        {
            InstantiateCoin();
        }
    }

    void InstantiateCoin()
    {
        GameObject coinParent = GameObject.Find("Coins");

        if (coinParent == null)
        {
            coinParent = new GameObject("Coins");
            coinParent.AddComponent<CoinManager>();
        }

        for (int i = 0; i < m_AmountToInstantiate; i++)
        {
            //Initializing Components
            GameObject coin = new GameObject(m_CoinColor.ToString() + " Coin");
            SpriteRenderer coinRenderer = coin.AddComponent<SpriteRenderer>();
            ColorManager coinColorManager = coin.AddComponent<ColorManager>();
            Animator coinAnimator = coin.AddComponent<Animator>();
            coin.AddComponent<CoinObject>();

            coinAnimator.runtimeAnimatorController = m_RuntineController;
            coinRenderer.sprite = m_CoinImage;
            coinColorManager.objectColor = m_CoinColor;
            
            //We set the collider at the end to avoid ColliderShape problems before the sprite is assigned
            BoxCollider2D coinCollider = coin.AddComponent<BoxCollider2D>();
            coinCollider.isTrigger = true;

            coin.transform.SetParent(coinParent.transform);
            coin.layer = LayerMask.GetMask("Coin");
        }
    }
}