# Magnetic surface simulation 2D


https://github.com/user-attachments/assets/f20f7adb-5e27-4d27-9eaf-41572d43418f


"MSS" is a Unity prototype showcasing a magnetic movement mechanic.
This project features a magnetic movement system where the character is attracted to nearby surfaces.
Players can freely move and jump while sticking to walls, with smooth and responsive transitions around corners.
Physics is done using Unity's built-in tools.

## Architecture

- `Gravity2D` — MonoBehaviour which performs attraction and rotation of some side to the point.The point takes from 'SurfaceDetector' .
- `Movment` — MonoBehaviour that performs basic movement, with rb.linearVelocity control to eliminate annoying sliding.
- `InputService` — reads input via Unity Input System, exposes `MoveInput` and `JumpInput`.
- `CharacterAnimator` — MonoBehaviour that switches animations and sprite flip based on input.

## Dependencies

- VContainer — DI container
- Unity Input System

  

https://github.com/user-attachments/assets/86a08925-b8fb-420b-b8f5-905eaa6b1c26



## Important

I was inspired by Alex Kapkaev's project and the project was created based on his code.
https://github.com/AlexKapkaev10/gravity-platform-2d
---

Unity 6000.3.2f1
