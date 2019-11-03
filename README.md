Minis: MIDI Input for New Input System
======================================

**Minis** (MIDI Input for New Input System) is a Unity plugin that adds MIDI
input device support to [Unity new Input System].

[Unity new Input System]:
  https://blogs.unity3d.com/2019/10/14/introducing-the-new-input-system/

System Requirements
-------------------

- Unity 2019.3 or later
- 64-bit desktop platforms (Windows, macOS, Linux)

On Linux, ALSA (libasound2) must be installed on the system.

How To Install
--------------

This package uses the [scoped registry] feature to import dependent packages.
Please add the following sections to the package manifest file
(`Packages/manifest.json`).

To the `scopedRegistries` section:

```
{
  "name": "Keijiro",
  "url": "https://registry.npmjs.com",
  "scopes": [ "jp.keijiro" ]
}
```

To the `dependencies` section:

```
"jp.keijiro.minis": "1.0.0"
```

After changes, the manifest file should look like below:

```
{
  "scopedRegistries": [
    {
      "name": "Keijiro",
      "url": "https://registry.npmjs.com",
      "scopes": [ "jp.keijiro" ]
    }
  ],
  "dependencies": {
    "jp.keijiro.minis": "1.0.0",
    ...
```

[scoped registry]: https://docs.unity3d.com/Manual/upm-scoped.html

How To Use
----------

### Input Controls

When Minis is installed to a project, MIDI control elements appear under
"Other" > "MIDI Device". You can also use the "Listen" button to specify a
control.

![gif](https://i.imgur.com/nFzQM2M.gif)

**TIPS** - For some reason, the listener only react to notes with high velocity
(higher than 63). You may have to press a key strongly.

The MIDI Notes are shown as button controls with names like "Note C4". These
controls work as pressure sensitive buttons. The button value (pressure) is
set based on the velocity of the note.

MIDI Controls (CC) are shown as axis controls with names like "Control 10".
These axis values are normalized as values between 0.0 to 1.0.

For further usage of the new Input System, please see the [Input System manual].

[Input System manual]:
  https://docs.unity3d.com/Packages/com.unity.inputsystem@latest/

### MIDI Channels

Minis treats each MIDI channel as an individual device. MIDI devices are
dynamically added to the Input System when it detects a MIDI message from a
new channel.

When multiple MIDI interfaces are connected to the system, channels under these
interfaces are also treated as individual devices. For instance, if you have
connected two MIDI interfaces to the system, you can use up to 32 input devices
at the same time (as each interface can handle up to 16 channels).

### Scripting Examples

This repository contains some examples showing how to use Minis from a script.

[**DeviceDetectTest.cs**](Assets/Test/DeviceDetectTest.cs) - Get callback when
a new MIDI device is detected.

[**DeviceQueryTest.cs**](Assets/Test/DeviceQueryTest.cs) - Search MIDI devices
with a product name and a channel number.
