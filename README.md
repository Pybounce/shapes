## General Architecture

- Canvas:
  - Responsible for holding data on what widgets it contains
  - Nice API for adding/displaying widgets
  - Could also be responsible for indexing widgets on position and only drawing visible ones but would likely be an ICanvasRenderer: out of the scope for this project sadly
- IWidgetRenderer:
  - Responsible for rendering widgets and compound widgets
  - Separates rendering and data so a canvas can use any renderer and the individual widgets do not contain logic for rendering themselves
    - This way if you had a graphics lib, you can make the renderer connect to it and display widgets there with no change to your widgets or canvas
- Widgets:
  - Mainly data to describe the widget
  - Uses the visitor pattern with IWidgetRenderer to ensure, at compile time, when a new widget is added, it can be rendered by any renderer.
- Compound Widgets:
  - Can be used to create nice templates be altering the positions of widgets in the compound widget.
    - For example, if a common widget ends up being a InputField with a display name to the left
    - Add a Text widget at 0,0, InputField at 1,0 (or wherever)
    - Can reuse this compound widget like a component

## Small Notes

- ScreamingWidgetRenderer just there as an example of another renderer

## What I would do with more time

- Potentially create a separate rendering interface for each widget type ie ISquareRenderer etc
  - You'd still have an IWidgetRenderer, but it would itself, contain the renderers for each widget type
  - Allowing users to mix and match different renderers on a per-widget basis
- Slap a method to update the renderer of the canvas at any time, not just in the constructor
