# Maniac Editor - Sonic Mania Scene Editor

Find my latest version [here](https://github.com/OtherworldBob/ManiacEditor/releases/latest), yes, it's still a Beta!

Find the original by **koolkdev** over [there](https://github.com/koolkdev/ManiacEditor/releases/latest), from which this version derives. None of this would be possible without the work done in the original!

[![Build status](https://ci.appveyor.com/api/projects/status/pubh9p6k0ti8muk4/branch/master?svg=true)](https://ci.appveyor.com/project/OtherworldBob/maniaceditor/branch/master)

## Tiles editing

### Keyboard shortcuts 
**Ctrl + D** - Duplicate selected  
**Ctrl + X / C / V** - Cut / Copy / Paste  
**Ctrl + Z / Y** - Redo / Undo  
**Delete** - Delete selected  
**M** - Mirror tile image (X-axis)  
**F** - Flip tile image (Y-axis)  
**Arrow keys** - Move selected tiles

### Editing modes
![Pointer tool](https://github.com/koolkdev/m_e_images/blob/master/pointerButton.Image.png) - Default mode  
Clicked tile is immediatily selected. To select multiple tiles, you can click and drag from empty spot to create a selection box.  
You can move selected tiles by click on one of them and dragging them with your mouse.  
You can use **Shift** and **Ctrl** + click (and drag) to add/remove items from your selection.  
You can duplicate tiles by holding **Ctrl** and dragging the selected tiles.  
You can add new tiles by dragging them from the selection window or double click on them.  
You can change the properties of the selected tiles by click on the checkboxes at the bottom of the tiles sidebar.

![Selection tool](https://github.com/koolkdev/m_e_images/blob/master/selectTool.Image.png) - Selection tool  
Clicking and dragging will create a selection box, even if you clicked on a tile. (in the default mode it will drag the tile instead)  
You can move selected tiles by click on one of them and dragging them with your mouse.  
You can use **Shift** and **Ctrl** + click (and drag) to add/remove items from your selection.  
You can duplicate tiles by holding **Ctrl** and dragging the selected tiles.  
You can add new tiles by dragging them from the selection window or double click on them.  
You can change the properties of the selected tiles by click on the checkboxes at the bottom of the tiles sidebar.

![Place tiles tool](https://github.com/koolkdev/m_e_images/blob/master/placeTilesButton.Image.png) - Place tiles tool  
With this mode you can paint the current selected tile (in the tiles sidebar) by clicking and dragging.  
You can remove tile by doing the same with the right mouse button.  
You can hold **Ctrl** and/or **Shift** to mirror/flip the placed tile.  
You can choose which properties the placed tiles will have by clicking on the checkboxes below the tiles selection window.

## Plus Compatibility
With help from [SuperSonic16](https://github.com/thesupersonic16) and [Axanery](https://www.youtube.com/channel/UCIsXoOHibP8wpjcha3bSbMQ), we've got some support for Plus.
Lots still do here!

## New Features

* In-editor visual entities! You can see spikes, rings and many more things! (Contributed by [supersonic16](https://github.com/thesupersonic16))
* Flip a collection of selected tiles as one cohesive block.
* Paste new tiles and entities next to the mouse cursor, not the top left.
* Edit background layers.
* Spawn brand new entities without needing to find one to copy. (They appear in the top left!)
* Import level objects from one level to another. It works quite well for invisible things, like the WarpDoor and BreakableWall; less well (not really at all) for badniks and the like.
  * Pro tip: Be sensible with this one!
* Import sounds from one level to another.
  * This goes hand-in-hand with importing objects. You'll want to import any applicable sounds too.
* Layer reordering, creation, destruction and resizing (too big and the game will crash!); you can also edit some of the magic values assoicated with the layers too.
  * You'll need to fix-up any BGSwitch entities to account for anything you change though.
* New export function to write each layer of a scene to its own file.
* Data Directory switching. You can now switch parent Data directories without closing the application.
* Extra crashes! Save often, backup well.
* Non-descript Undo/Redo helpers that don't tell you much most of the time.
