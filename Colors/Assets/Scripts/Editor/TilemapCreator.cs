using System.Collections;
using System.Collections.Generic;
using Game.Color_System;
using Game.Traps;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCreator 
{
    [MenuItem("MyTools/Create Tilemaps.../Yellow Tilemap")]
    static void CreateYellowTilemap()
    {
        TilemapCreator creator = new TilemapCreator();
        
        creator.CreateTilemapColor(ColorManager.objColor.Yellow);
    }
    [MenuItem("MyTools/Create Tilemaps.../Blue Tilemap")]
    static void CreateBlueTilemap()
    {
        TilemapCreator creator = new TilemapCreator();
        
        creator.CreateTilemapColor(ColorManager.objColor.Blue);
    }
    [MenuItem("MyTools/Create Tilemaps.../Red Tilemap")]
    static void CreateRedTilemap()
    {
        TilemapCreator creator = new TilemapCreator();
        
        creator.CreateTilemapColor(ColorManager.objColor.Red);
    }

    [MenuItem("MyTools/Create Tilemaps.../Normal Tilemap")]
    static void CreateNormalTilemap()
    {
        TilemapCreator creator = new TilemapCreator();

        creator.TilemapGenerator("Environment");
    }
    [MenuItem("MyTools/Create Tilemaps.../Water")]
    static void CreateWaterTilemap()
    {
        TilemapCreator creator = new TilemapCreator();

        Tilemap tile = creator.TilemapGenerator("Water");
        tile.gameObject.AddComponent<Water>();
        tile.GetComponent<TilemapRenderer>().sortingLayerName = "Water";
        tile.GetComponent<CompositeCollider2D>().isTrigger = true;
    }
    
    void CreateTilemapColor(ColorManager.objColor tilemapColor)
    {
        Tilemap tileInstance = TilemapGenerator(tilemapColor.ToString() + " Tilemap");
        
        ColorManager color = tileInstance.gameObject.AddComponent<ColorManager>();
        
        tileInstance.gameObject.layer = LayerMask.NameToLayer(tilemapColor.ToString());
        color.objectColor = tilemapColor;
    }

    private Tilemap TilemapGenerator(string TilemapName)
    {
        GameObject mainGrid = GameObject.Find("Grid");
        if (mainGrid == null)
            CreateGrid();
        
        GameObject tilemapOBJ = new GameObject(TilemapName);

        Tilemap tilemap = tilemapOBJ.AddComponent<Tilemap>();
        TilemapRenderer renderer = tilemapOBJ.AddComponent<TilemapRenderer>();
        
        TilemapCollider2D tilemapCollider = tilemapOBJ.AddComponent<TilemapCollider2D>();
        CompositeCollider2D tilemapComposite = tilemapOBJ.AddComponent<CompositeCollider2D>();
        Rigidbody2D tilemapRGB = tilemapOBJ.GetComponent<Rigidbody2D>();
        
        renderer.sortingLayerName = "Environment";
        tilemapRGB.isKinematic = true;

        tilemapCollider.usedByComposite = true;
        
        tilemapOBJ.gameObject.transform.SetParent(mainGrid.transform);

        return tilemap;
    }

    private void CreateGrid()
    {
        GameObject grid = new GameObject("Grid");
        grid.AddComponent<Grid>();
    }
}
