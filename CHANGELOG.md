# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.3.2] - 2025-11-23

### Changed

- Updated the RtMidi dependency to 2.2.0 and raised the minimum Unity version
  to 2022.3.
- Noted Intel Mac support in the documentation.
- Tweaked test project build settings including Android app category and
  IL2CPP options.

### Fixed

- Prevented zero aftertouch values from triggering note-off events.

## [1.3.1] - 2025-05-19

### Added

- Added a Press Point option to Any Note Velocity.

### Fixed

- Any Note Velocity no longer triggers on note off when multiple keys are
  pressed.

## [1.3.0] - 2025-05-19

### Added

- Polyphonic aftertouch support with per-note pressure values.
- Pitch bend and channel pressure (aftertouch) exposed as axis controls.
- Any Note Number and Any Note Velocity controls that track the most recent
  key.
- Subframe timestamp support for higher timing precision than frame-locked
  updates.
- Support for devices that only send note-on messages, such as some electronic
  drums.
- InputActionTest and TimingTest samples plus Any Note controls for quick
  verification.

### Changed

- Switched RtMidi to callback handling, refreshed Android build settings, and
  reorganized test scenes.
- Updated UI polish, documentation, and package layout.

### Fixed

- Miscellaneous bug fixes including thread safety issues and Android packet
  handling with RtMidi.
