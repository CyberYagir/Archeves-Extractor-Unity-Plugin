# Archive Extractor for Unity

Extract archives directly inside the Unity Editor from the Project window.

Archive Extractor is a lightweight editor extension that adds a context menu action for archive files in the Unity Project window and extracts them into a folder next to the selected archive.

It is designed for teams and solo developers who regularly import external content packs, source files, or archived assets into Unity projects and want a simple in-editor workflow.

## Features

- Extract archives directly from the Unity Project window
- Creates an output folder next to the archive using the archive file name
- Simple editor workflow with no external executable requirements
- Supports common archive formats through managed .NET libraries
- Works inside the Unity Editor without command-line tools

## Supported Formats

- `.zip`
- `.rar`
- `.7z`
- `.tar`
- `.tar.gz`

## How It Works

1. Select an archive file in the Unity Project window
2. Right-click the file
3. Choose the extract action from the context menu
4. The archive is extracted into a folder with the same name as the archive, next to the original file
5. Unity refreshes the AssetDatabase automatically

### Example

If you have:

`Assets/Imported/my_pack.rar`

The extracted files will be placed in:

`Assets/Imported/my_pack/`

## Use Cases

- Importing downloaded asset packs into Unity projects
- Unpacking source archives from artists or collaborators
- Reviewing archived content without leaving the Unity Editor
- Speeding up pipeline and content setup workflows

## Requirements

- Unity 2021.3 or newer recommended
- Editor-only tool
- No runtime component
- No external command-line archive tools required

## Installation

1. Import the package into your Unity project
2. Make sure the included third-party DLLs are present in the package
3. Use the context menu on supported archive files in the Project window

## Notes

- This asset is intended for Editor use only
- Extraction behavior depends on file integrity and archive format support
- Password-protected or damaged archives may not extract successfully
- Very large archives may take time depending on disk speed and archive structure

## Third-Party Dependencies

This asset includes third-party open-source components:

### SharpCompress
- Project: https://github.com/adamhathcock/sharpcompress
- License: MIT
- Used for managed archive reading and extraction support

### ZstdSharp
- Project: https://github.com/oleg-st/ZstdSharp
- License: MIT
- Used as a dependency required by SharpCompress

## Asset Store Legal Notice

This asset uses SharpCompress under the MIT License and ZstdSharp under the MIT License;
Source: https://github.com/CyberYagir/Archeves-Extractor-Unity-Plugin

## Documentation

Basic workflow:

- Select archive in Project window
- Right-click
- Extract archive
- Wait for AssetDatabase refresh

## Support

If you encounter an issue, please include:
- Unity version
- Operating system
- Archive type
- Error message or console log
- Whether the archive opens correctly in external tools

## Changelog

### 1.0.0
- Initial release
- Added extraction support for ZIP, RAR, 7Z, and TAR
- Added Project window context menu workflow
- Added automatic AssetDatabase refresh after extraction

## License
Third-party components retain their own licenses as listed in the package documentation. MIT

Source: https://github.com/CyberYagir/Archeves-Extractor-Unity-Plugin