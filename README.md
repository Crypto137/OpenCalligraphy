# OpenCalligraphy

OpenCalligraphy is a data browser for the Calligraphy framework developed by Gazillion for Marvel Heroes.

## Features

- Browsing and searching game data.

- Applying locales to loaded data.

- Compatibility with all versions of the game.
  
  - The earliest version tested is 1.9.
  - Versions prior to 1.29 utilize a legacy archive format. To use OpenCalligraphy with them, first you need to convert the `mu_cdata.sip` archive to the format used by later versions of the game with [MHSqlitePakRepacker](https://github.com/Crypto137/MHSqlitePakRepacker).

## How to Use

1. Make sure you have the [.NET Desktop Runtime 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed.

2. Download the [latest release](https://github.com/Crypto137/OpenCalligraphy/releases), unpack the archive and run `OpenCalligraphy.exe`.

3. Navigate to `File` -> `Open PakFile...` and locate the `Calligraphy.sip` archive. It should be in `Marvel Heroes\Data\Game\`.

4. (Optional) Navigate to `Locale` -> `Load Locale` and locate any of the `.locale` files. They should be in `Marvel Heroes\Data\Game\Loco\`.
