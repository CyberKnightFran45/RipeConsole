# RipeConsole

RipeConsole is a console application designed to run multiple file-processing tools, specifically tailored for PopCap games. The system supports various execution modes, catering to both interactive users and script-based automation.

---

## Overview

The program functions as an **action launcher** where each feature is encapsulated in an independent structure (`ToolAction`). These actions can be executed via interactive menus or directly from the command line.

The design prioritizes:

* Reuse of logic through an external library (`RipeLib`)
* Separation between the user interface and action execution
* Flexibility to add new features without modifying the program’s core

---

## Execution Modes

### 1. Interactive Mode

This is the default mode when no valid CLI arguments are specified.

* Function categories are displayed
* The user selects a category
* Then selects an action within that category
* The chosen action is executed

---

### 2. Drag & Drop Mode

Activated by passing a file or folder as an argument.

* Detects whether the argument is a file or directory
* Automatically filters available actions based on type
* Displays a simplified menu without categories
* Allows actions to be executed directly on the resource

---

### 3. CLI Mode (Command Line Interface)

Allows you to execute actions directly without user interaction.

#### Syntax:

```bash
program.exe <input> [output] @<id>
```

#### Example:

```bash
program.exe “C:\file.txt” “C:\output.txt” @3
```

#### Rules:

* `<input>`: Input path (file or folder)
* `[output]`: Output path (optional, depends on the action)
* `@<id>`: Identifier of the action to be executed (required for CLI)

#### Notes:

* The `@` prefix eliminates ambiguity with numeric paths
* Additional arguments may be required depending on the action

---

## Architecture

### ToolAction

Represents an executable system action.

Contains:

* Action name
* Execution method
* Filters for files or folders
* Compatibility settings

---

### MenuCategory

Groups actions under a category.

* Contains a list of action IDs
* Used only in interactive mode

---

### BaseMenu

Manages navigation and selection logic.

* Supports menus with or without categories
* Always returns an action (`ToolAction`)
* Avoids rigid structures such as `switch`

---

### Program

Application entry point.

Responsibilities:

* Detect execution mode
* Configure console
* Display the initial interface
* Execute selected actions
* Handle errors and logs

---

### RipeLib

External library containing:

* Action definitions
* Menu system
* Shared utilities

Allows logic to be reused in other projects.

---
## Execution Flow

1. Arguments (`args`) are received
2. Determine if CLI mode is active (`IsCliMode`)
3. Configure the console (`SetupConsole`)
4. Display the welcome screen (if applicable)
5. Retrieve the action to be executed (`Menu.Display`)
6. Execute the action
7. Save logs and exit the program

---

## Error Handling

* All executions are encapsulated in `try-catch` blocks
* Errors are displayed to the user via `ConsoleWriter`
* Information is logged via `TraceLogger`

---

## Key Features

* Hybrid support: interactive + automated
* Extensible architecture
* Reusability via DLL
* Smart action filtering
* Integrated logging system

---

## Considerations

* The system assumes the user knows the IDs of actions in CLI mode
* Some actions may require additional arguments
* Behavior may vary depending on the input type (file or folder)

---

## Complete Usage Example

### Interactive:

```bash
program.exe
```

### Drag & Drop:

```bash
program.exe “C:\file.dat”
```

### CLI:

```bash
program.exe “C:\file.dat” “C:\output.dat” @2
```

---

## Extensibility

To add new features:

1. Create a new instance of `ToolAction`
2. Define its execution logic
3. Register the action in the menu system
4. (Optional) Assign it to a category

It is not necessary to modify the program’s core logic.

---

## Author

Developed by FranZ (CyberKnightFran)