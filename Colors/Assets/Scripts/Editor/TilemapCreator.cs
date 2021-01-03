using System.Collections;
using System.Collections.Generic;
using Game.Color_System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCreator 
{
    [MenuItem("MyTools/Create Tilemaps.../Yellow Tilemap")]
    static void CreateYellowTilemap()
    {
        TilemapCreator creator = new TilemapCreator();
        
        creator.CreateTilemap(ColorManager.objColor.Yellow);
    }
    [MenuItem("MyTools/Create Tilemaps.../Blue Tilemap")]
    static void CreateBlueTilemap()
    {
        TilemapCreator creator = new TilemapCreator();
        
        creator.CreateTilemap(ColorManager.objColor.Blue);
    }
    [MenuItem("MyTools/Create Tilemaps.../Red Tilemap")]
    static void CreateRedTilemap()
    {
        TilemapCreator creator = new TilemapCreator();
        
        creator.CreateTilemap(ColorManager.objColor.Red);
    }

    void CreateTilemap(ColorManager.objColor tilemapColor)
    {
        GameObject mainGrid = GameObject.Find("Grid");
        if (mainGrid == null)
            CreateGrid();
        
        
        GameObject tilemap = new GameObject(tilemapColor.ToString() + " Tilemap");

        tilemap.AddComponent<Tilemap>();
        TilemapRenderer renderer = tilemap.AddComponent<TilemapRenderer>();
        
        TilemapCollider2D tilemapCollider = tilemap.AddComponent<TilemapCollider2D>();
        CompositeCollider2D tilemapComposite = tilemap.AddComponent<CompositeCollider2D>();
        Rigidbody2D tilemapRGB = tilemap.GetComponent<Rigidbody2D>();

        ColorManager color = tilemap.AddComponent<ColorManager>();
        
        
        tilemap.layer = LayerMask.NameToLayer(tilemapColor.ToString());
        color.objectColor = tilemapColor;
        renderer.sortingLayerName = "Environment";
        tilemapRGB.isKinematic = true;

        tilemapCollider.usedByComposite = true;
        tilemap.transform.SetParent(mainGrid.transform);
    }

    private void CreateGrid()
    {
        GameObject grid = new GameObject("Grid");
        grid.AddComponent<Grid>();
    }
}
