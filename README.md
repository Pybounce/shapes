# shapes

revolutionary shape-tech

- Would have loved to use a params collection but it's not supported in this .net version and I'm not changing version for that.

- Squares can just be a wrapper around a rect, though optimisations can be made around it being a square and not a rect. Given the fact it's a rendering system (or could be later), makes sense to keep it separate...maybe...who knows I'll likely change my mind later.

  - I have in fact, changed my mind.
  - They will be wrappers and textbox will be made up of a rect and some text

- Abstract shape can handle other things such as rotation down the line
