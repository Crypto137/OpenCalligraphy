# OpenCalligraphy

OpenCalligraphy is a data browser for the Calligraphy framework developed by Gazillion for Marvel Heroes.

<p align="center">
<img alt="OpenCalligraphy Screenshot" src="https://raw.githubusercontent.com/Crypto137/OpenCalligraphy/master/docs/screenshot.png"/>
</p>

## Features

- Browsing and searching game data.

- Applying locales to loaded data.

- Compatibility with all versions of the game.
  
  - The earliest version tested is 1.9.
  - Versions prior to 1.29 utilize a legacy archive format. To use OpenCalligraphy with them, first you need to convert the `mu_cdata.sip` archive to the format used by later versions of the game with [MHSqlitePakRepacker](https://github.com/Crypto137/MHSqlitePakRepacker).

**Currently, OpenCalligraphy does not include any editing functionality. This is by design.** Because the server has limited options for validating client-side data, .sip file modification can cause various issues, particularly on publicly accessible servers. This includes drastically increasing the number of logged errors, which can make actual bugs harder to detect, as well as potentially making cheating more prevalent. Resolving this would most likely require introducing a mandatory external launcher, which is going to make the setup process more difficult even for people who are not playing modded versions of the game, as well as distract server developers from more meaningful tasks, such as implementing support for other versions of the game.

Because of this, I kindly ask not to create and/or distribute forks of OpenCalligraphy or other similar tools with editing functionality, at least for the time being.

## How to Use

1. Make sure you have the [.NET Desktop Runtime 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed.

2. Download the [latest release](https://github.com/Crypto137/OpenCalligraphy/releases), unpack the archive and run `OpenCalligraphy.exe`.

3. Navigate to `File` -> `Open PakFile...` and locate the `Calligraphy.sip` archive. It should be in `Marvel Heroes\Data\Game\`.

4. (Optional) Navigate to `Locale` -> `Load Locale` and locate any of the `.locale` files. They should be in `Marvel Heroes\Data\Game\Loco\`.
