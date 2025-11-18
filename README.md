# **More Sudden Death Options**

Adds additional and customizable Sudden Death triggers for **Map Embiggener**, allowing more control over when the map begins to close in.

## **How It Work**

This mod completely overrides **Map Embiggener** built-in Sudden Death logic.

- The original Sudden Death checks are **disabled**.
- All Sudden Death behavior is instead controlled by **custom Sudden Death Options**.
- Each Sudden Death Option has its own conditions and settings.
- During gameplay, if **any** enabled Sudden Death Option returns `true`, the map border will begin closing.
  This system allows you to control the **Sudden Death** conditions.

## **Available Options**

### **1. Trigger Based on Player Count**

This option triggers Sudden Death depending on the number of **alive players**.

#### **Settings:**

- **Enable When Above N Players**
  The option becomes active only when the total player count is **above** this number.
  (Useful for disabling Sudden Death during very small matches.)

- **Trigger When Below or Equal N Players**
  Once active, Sudden Death will trigger when the number of **alive players** is
  **less than or equal to** this value.

### **2. Trigger Based on Time**

This option triggers Sudden Death after a set amount of time has passed in the round.

#### **Settings:**

- **Trigger When N Seconds Have Passed**
  Once the round has been running for this many seconds, Sudden Death will be triggered.


## Notes

- All options are fully configurable through the `MORE SUDDEN DEATH OPTION` menu in `MODS` menu.
