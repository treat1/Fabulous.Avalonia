# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]
_No unreleased changes_

## [2.4.0-pre1] - 2024-02-09
### Added
- Add support for Components by @TimLariviere at https://github.com/fabulous-dev/Fabulous.Avalonia/pull/206

### Changed
- Fix templates after Component API support by @TimLariviere at https://github.com/fabulous-dev/Fabulous.Avalonia/pull/207
- Fix AutoCompleteBox by @edgarfgp at https://github.com/fabulous-dev/Fabulous.Avalonia/pull/210/files
- Use Fabulous pre8
- Fix for carrousel page transition modifiers by @edgarfgp at https://github.com/fabulous-dev/Fabulous.Avalonia/pull/218
- Update to use version 11.0.9

## [2.3.0] - 2024-01-17
### Added
- ImageSource constructors and modifiers consolidations

### Changed
- Update to use Avalonia 11.0.7

## [2.2.0] - 2024-01-09
### Added
- Add new widget constructors and modifiers to support Uri Bitmap and Stream

### Changed
- Avoid allocating a new Source instance on each update by using specialized attributes for each value type

## [2.1.0] - 2024-01-07
### Added
- Add support for Color and string as part of the modifiers

## [2.0.0] - 2024-01-01
### Changed
- Update widgets constructors modifiers to match AvaloniaUI  API

## [2.0.0-pre18] - 2023-12-07
### Added
- Add support for Avalonia 11.0.6

## [2.0.0-pre18] - 2023-12-07
### Added
- Add support for Avalonia 11.0.6

## [2.0.0-pre17] - 2023-11-12
### Added
- More samples

## [2.0.0-pre16] - 2023-10-31

### Changed
- Sample apps better styling

## [2.0.0-pre15] - 2023-10-19

### Changed
- Add support for AvaloniaUI 11.0.5

### Fixed
- Fix app on iOS and droid by setting theme earlier in the lifecycle

## [2.0.0-pre14] - 2023-10-02

### Added
- Add render demo
- Add support for ControlThemes by @kevkov

### Changed
- Make Fabulous.Avalonia theme-less by default

## [2.0.0-pre13] - 2023-09-14

### Added
- Add support for AvaloniaUI 11.0.4

## [2.0.0-pre12] - 2023-07-24

### Added
- Add FabApplication helpers to make it easier to access to platform specific services

### Changed
- Update template to include targets

## [2.0.0-pre11] - 2023-07-18

### Added
- More samples to Gallery
- Add support for Drag and Drop
- Add support for AvaloniaUI preview RC2.2
- Add XML documentation for all widget constructors and modifiers
- Add support for Effects

## [2.0.0-pre10] - 2023-06-07

### Added
- More samples to Gallery
- Add some short-hand methods for Animation and Gestures
- Add support for AvaloniaUI preview RC1.1

### Changed
- Update to use Fabulous 2.3.2

## [2.0.0-pre9] - 2023-05-15

### Added
- More samples to Gallery
- Add NotificationCard wrapper
- Add new animation modifiers 
- Add support for AvaloniaUI preview 8

## [2.0.0-pre8] - 2023-05-07

### Added
- More samples to Gallery
- Add VisualBrush wrapper
- Add support for AvaloniaUI preview 7

### Changed
- Disable `WidgetDataTemplate` recycling  to avoid issues with `DataTemplate` not being applied correctly
- Rework GalleryApp structure to make it easier to add new samples

## [2.0.0-pre7] - 2023-04-24

### Added
- More samples to Gallery
- Add Label wrapper
- Exclude 'net7.0-ios' from build on Linux to make it buildable there @ChristophSchmidpeter

### Fixed
- Revert to use Minimum and Maximum as part of the constructor

### Changed
- Use Minimum and Maximum as part of the constructor NumericUpDown

## [2.0.0-pre6] - 2023-04-19

### Added
- More samples to Gallery

### Fixed
- Fix AdornerLayer
- Improve template by adding some guidance on how to use it on linux

### Changed
- Minimum and Maximum are now modifiers instead of part of the constructor

## [2.0.0-pre5] - 2023-04-13

### Added
- More samples to Gallery

### Fixed
- Flyouts not available the corresponding controls

### Changed
- Update to use Fantomas 6.0.0

## [2.0.0-pre4] - 2023-04-08

### Added
- Add support for ViewRef

### Removed
- Xaml specific controls

## [2.0.0-pre3] - 2023-04-07

### Added
- Add support for AvaloniaUI preview 6

## [2.0.0-pre2] - 2023-04-02

### Added
 - Add support for AvaloniaUI preview 5

## [2.0.0-pre1] - 2023-02-17

### Added
- Initial release

[unreleased]: https://github.com/fabulous-dev/Fabulous.Avalonia/compare/2.3.0...HEAD
[2.3.0]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.3.0
[2.2.0]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.2.0
[2.1.0]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.1.0
[2.0.0]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0
[2.0.0-pre18]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre18
[2.0.0-pre17]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre17
[2.0.0-pre16]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre16
[2.0.0-pre15]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre15
[2.0.0-pre14]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre14
[2.0.0-pre13]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre13
[2.0.0-pre12]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre12
[2.0.0-pre11]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre11
[2.0.0-pre10]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre10
[2.0.0-pre9]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre9
[2.0.0-pre8]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre8
[2.0.0-pre7]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre7
[2.0.0-pre6]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre6
[2.0.0-pre5]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre5
[2.0.0-pre4]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre4
[2.0.0-pre3]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre3
[2.0.0-pre2]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre2
[2.0.0-pre1]: https://github.com/fabulous-dev/Fabulous.Avalonia/releases/tag/2.0.0-pre1
