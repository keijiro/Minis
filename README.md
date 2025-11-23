# Minis: MIDI Input Extension for Unity Input System

![gif](https://github.com/user-attachments/assets/fdbfaeed-5f92-46c8-8a0c-58de1083e494)
![gif](https://github.com/user-attachments/assets/48f86c34-4afe-47a6-ba0d-18e53c9552d6)

**Minis** is an extension for the Unity [Input System] that adds support for
MIDI input devices.

[Input System]:
  https://docs.unity3d.com/Packages/com.unity.inputsystem@latest/

## System Requirements

- Unity 2022.3 LTS or later

Currently, RtMidi for Unity supports the following platform and architecture
combinations:

- Windows: x86_64
- macOS: Intel and Apple Silicon
- iOS: arm64
- Linux: x86_64
- Android: arm64
- Web (requires [Web MIDI] support)

[Web MIDI]: https://caniuse.com/midi

In addition, there are some platform-specific considerations to keep in mind:

#### Android

Minis currently does not support the GameActivity entry point. You must select
"Activity" as the Application Entry Point in the Player Settings.

There is a known issue with multi-port MIDI devices. keijiro/jp.keijiro.rtmidi#16

#### Linux

The RtMidi backend requires ALSA (`libasound2`) on Linux platforms. If Minis
does not work, please check that ALSA is installed.

## Installation

You can install the Minis package (`jp.keijiro.minis`) via the "Keijiro" scoped
registry using the Unity Package Manager. To add the registry to your project,
follow [these instructions].

[these instructions]:
  https://gist.github.com/keijiro/f8c7e8ff29bfe63d86b888901b82644c

## Usage

### Input Controls

After installing Minis, MIDI control elements appear under "Other" >
"MIDI Device" in the Input System. You can also use the "Listen" button to
detect a specific control input.

![gif](https://i.imgur.com/nFzQM2M.gif)

**NOTE** – The listener only reacts to notes with a velocity higher than 63.
You may need to press the key firmly to trigger detection.

MIDI notes appear as button controls with names like "Note C4." They support
velocity and polyphonic aftertouch, with output values normalized between 0.0
and 1.0.

MIDI CC messages appear as axis controls with names like "Control 10" and
output values normalized between 0.0 and 1.0.

Pitch Bend and Channel Pressure (Channel Aftertouch) also appear as axis
controls. Note that Channel Pressure does not affect individual note values.

There are two special controls — the **Any Note Number** axis and the **Any
Note Velocity** button. These controls reflect the most recently pressed key,
making them useful for creating behaviors based on monophonic keyboard input.

### MIDI Channels

Minis treats each MIDI channel as a separate input device. Devices are
dynamically registered when a MIDI message is received on a new channel.

**NOTE** – The Input System cannot detect a device until it receives a message.
Prompt the user to move a control to activate detection.

When multiple MIDI interfaces are connected, channels across all interfaces are
handled independently. For example, with two interfaces, you can use up to 32
input devices (16 channels per interface).

Note that Minis numbers MIDI channels starting from zero, unlike the standard
MIDI specification, which starts from one. For example, a device using MIDI
channel 1 will appear as "Channel 0" in Minis.

### MIDI Device Assigner

![inspector](https://i.imgur.com/xHkTuOgm.jpg)

The MIDI Device Assigner is a utility for binding MIDI devices to PlayerInput.
You can specify a MIDI channel and product name as matching criteria. It
assigns the matched device to a PlayerInput component on the same GameObject.

## MIDI Event Callbacks

For convenience, Minis provides custom callback events via the `MidiDevice`
class. The following events are currently available:

- `onWillNoteOn`
- `onWillNoteOff`
- `onWillAftertouch`
- `onWillControlChange`
- `onWillChannelPressure`
- `onWillPitchBend`

These events are triggered **before** the control state updates, so you should
use the event arguments rather than querying the control state. See the
[`CallbackTest.cs`](/Assets/Scripts/CallbackTest.cs) sample code for usage
examples.

## Frequently Asked Questions

#### Does it support MIDI out?

No, but the underlying backend (RtMidi) does support MIDI output. You can
access this functionality directly. See the [RtMidi for Unity] repository for
sample scripts.

[RtMidi for Unity]: https://github.com/keijiro/jp.keijiro.rtmidi
