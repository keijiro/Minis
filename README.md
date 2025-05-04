# Minis: MIDI Input Extension for Unity Input System

![gif](https://i.imgur.com/xo9BgV4.gif)
![gif](https://i.imgur.com/UFqQcEz.gif)

**Minis** is an extension for the Unity [Input System] that adds support for
MIDI input devices.

[Input System]:
  https://docs.unity3d.com/Packages/com.unity.inputsystem@latest/

## System Requirements

- Unity 2022.3 LTS or later

Currently, RtMidi for Unity supports the following platform and architecture
combinations:

- Windows: x86_64
- macOS: arm64 (Apple Silicon)
- iOS: arm64
- Linux: x86_64
- Android: arm64

## Installation

You can install the Minis package (`jp.keijiro.minis`) via the "Keijiro" scoped
registry using the Unity Package Manager. To add the registry to your project,
follow [these instructions].

[these instructions]:
  https://gist.github.com/keijiro/f8c7e8ff29bfe63d86b888901b82644c

## Usage

### Input Controls

After installing Minis, MIDI control elements appear under
"Other" > "MIDI Device" in the Input System. You can also use the "Listen"
button to detect a specific control input.

![gif](https://i.imgur.com/nFzQM2M.gif)

**NOTE** – The listener only reacts to notes with a velocity higher than 63.
You may need to press the key firmly to trigger detection.

MIDI notes appear as button controls with names like "Note C4". These are
pressure-sensitive and output values normalized between 0.0 and 1.0.

MIDI CC messages appear as axis controls with names like "Control 10", and also
output normalized values between 0.0 and 1.0.

For more details on using the new Input System, refer to the [Input System]
manual.

### MIDI Channels

Minis treats each MIDI channel as a separate input device. Devices are
dynamically registered when a MIDI message is received on a new channel.

**TIP** – The Input System cannot detect a device until it receives a message.
Prompt the user to move a control to activate detection.

When multiple MIDI interfaces are connected, channels across all interfaces are
handled independently. For example, with two interfaces, you can use up to 32
input devices (16 channels per interface).

### MIDI Device Assigner

![inspector](https://i.imgur.com/xHkTuOgm.jpg)

The MIDI Device Assigner is a utility for binding MIDI devices to PlayerInput.
You can specify a MIDI channel and product name as matching criteria. It
assigns the matched device to a PlayerInput component on the same GameObject.

## Scripting Samples

This repository includes C# scripting examples demonstrating how to use Minis.

[**DeviceCallback.cs**](Assets/Script/DeviceCallback.cs) – Defines a callback
for MIDI device additions and removals.

[**DeviceQuery.cs**](Assets/Script/DeviceQuery.cs) – Demonstrates searching for
MIDI devices using product name and channel filters.

[**NoteCallback.cs**](Assets/Script/NoteCallback.cs) – Defines a callback for
receiving MIDI note-on and note-off events.

## Frequently Asked Questions

#### Does it support MIDI out?

No, but the underlying backend (RtMidi) does support MIDI output. You can
access this functionality directly. See the [RtMidi for Unity] repository for
sample scripts.

[RtMidi for Unity]: https://github.com/keijiro/jp.keijiro.rtmidi
