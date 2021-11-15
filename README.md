# Better Mute
## Overview
Better mute allows admins to be able to mute a player for a specific amount of time(in rounds)

## Usage
``bmute <id> <rounds>``

## Config
``is_enabled`` - Indicates whether the plugin is enabled or not.

``data_dir`` - Path of the Mute file, it's located in the Plugins folder by default.

## Notes
It checks all muted players when round ends. If player left before round end, the remaining rounds do not change.
