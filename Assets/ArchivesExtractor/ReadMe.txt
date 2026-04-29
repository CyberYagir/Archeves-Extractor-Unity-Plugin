# Archive Extractor

Extract supported archive files directly inside the Editor from the Project window.

Archive Extractor is a lightweight editor extension that adds a context menu action for supported archive files in the Project window and extracts them into a folder next to the selected file.

It is designed for teams and solo developers who regularly import external content packs, source files, or bundled content into projects and want a simple in-editor workflow.

## Features

- Extract supported archive files directly from the Project window
- Creates an output folder next to the selected file using the file name
- Simple editor workflow with no external executable requirements
- Supports multiple archive types through managed .NET libraries
- Works inside the Editor without command-line tools

## Supported File Types

This asset supports several common archive file types, including ZIP, TAR-based archives, and other supported containers handled by the included managed libraries.

## How It Works

1. Select a supported archive file in the Project window
2. Right-click the file
3. Choose the extract action from the context menu
4. The contents are extracted into a folder with the same name as the selected file, next to the original file
5. The project database refreshes automatically

### Example

If you have:

`Assets/Imported/my_pack.archive`

The extracted files will be placed in:

`Assets/Imported/my_pack/`

## Use Cases

- Importing downloaded content packs into projects
- Unpacking source bundles from artists or collaborators
- Reviewing archived content without leaving the Editor
- Speeding up pipeline and content setup workflows

## Requirements

- 2021.3 or newer recommended
- Editor-only tool
- No runtime component
- No external command-line archive tools required

## Installation

1. Import the package into your project
2. Make sure the included third-party DLLs are present in the package
3. Use the context menu on supported archive files in the Project window

## Notes

- This asset is intended for Editor use only
- Extraction behavior depends on file integrity and archive support provided by the included libraries
- Password-protected or damaged archives may not extract successfully
- Very large archives may take time depending on disk speed and archive structure

## Third-Party Dependencies

This asset includes third-party open-source components:

### SharpCompress
- Project repository: GitHub / adamhathcock / sharpcompress
- License: MIT
- Used for managed archive reading and extraction support

### ZstdSharp
- Project repository: GitHub / oleg-st / ZstdSharp
- License: MIT
- Used as a dependency required by SharpCompress

## Legal Notice

This asset includes third-party open-source components under their respective licenses.
Those components remain subject to their original license terms.

## Documentation

Basic workflow:

- Select a supported archive file in the Project window
- Right-click
- Run the extract action
- Wait for the project database refresh

## Support

If you encounter an issue, please include:
- Editor version
- Operating system
- Archive type
- Error message or console log
- Whether the archive opens correctly in another archive tool

## Changelog

### 1.0.0
- Initial release
- Added support for multiple archive file types
- Added Project window context menu workflow
- Added automatic project database refresh after extraction

## License

Third-party components retain their own licenses as listed in the package documentation.
