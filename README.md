# OldPhonePadApp 

This is a simple C# console application that decodes numeric input based on an old mobile phone keypad layout. It supports multi-press characters, pauses, backspaces, and input termination — simulating how texting worked on pre-smartphone devices.

---

## Features

- Converts key sequences to uppercase characters (e.g. `2` = A, `22` = B).
- Handles:
  - Spaces (` `) as **pauses** between key presses.
  - Asterisk (`*`) as **backspace**.
  - Hash (`#`) as **send / end**.
- Continuous input loop until user types `exit`.
- Input validation (must end with `#`).

---

## Sample Inputs & Expected Outputs

| Input                        | Output   |
|-----------------------------|----------|
| `33#`                        | E        |
| `227*#`                      | B        |
| `4433555 555666#`            | HELLO    |
| `8 88777444666*664#`         | TURING   |
| `exit`                       | (ends)   |

---

## How to Run

1. Open `OldPhonePadApp.sln` in Visual Studio 2022.
2. Set the project as **Startup Project**.
3. Run the program (Ctrl + F5).
4. Enter sequences ending in `#`, or type `exit` to quit.

---

## Code Structure

- **`Main()`**: Handles input, validation, and control flow.
- **`DecodeOldPhonePad(string input)`**: Parses the input string and generates the output.
- **`AppendGroup(...)`**: Maps a repeated digit sequence to the correct character from the keypad.

---

## Unit Testing

This application includes unit tests for the `DecodeOldPhonePad` method. To run tests:

1. Open the solution in Visual Studio.
2. Right-click on the solution and choose **Build**.
3. Go to **Test > Run All Tests**.

---

## Testing Scenarios

Unit tests for the method `DecodeOldPhonePad` cover various input scenarios, including typical, edge cases, and backspace operations.

Example of tests:

| Input                         | Expected Output |
|-------------------------------|-----------------|
| `4433555 555666#`              | `HELLO`         |
| `8 88777444666*664#`           | `TURING`        |
| `222#`                         | `C`             |
| `7777#`                        | `S`             |

---
