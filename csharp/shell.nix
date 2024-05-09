# This file is based on:
# https://github.com/NixOS/nixpkgs/blob/3ab807f275232d227e846b5947775dc99e24e63c/doc/languages-frameworks/dotnet.section.md
# https://nixos.wiki/wiki/DotNET

# To ensure this nix-shell is reproducible, we pin the packages index to a commit SHA taken from a channel on https://status.nixos.org/
# This commit is from NixOS 23.11
with (import (fetchTarball https://github.com/NixOS/nixpkgs/archive/a5e4bbcb4780c63c79c87d29ea409abf097de3f7.tar.gz) {});

mkShell {
  name = "dotnet-env";

  packages = [
    # Install the .NET SDK versions we need
    (with dotnetCorePackages; combinePackages [
      # sdk_7_0
      sdk_8_0
    ])
    # Locales
    glibcLocales
  ];

  shellHook = ''
    # Set LANG for locales, otherwise it is unset when running "nix-shell --pure"
    export LANG="C.UTF-8"

    # Remove duplicate commands from Bash shell command history
    export HISTCONTROL=ignoreboth:erasedups

    # Do not pollute $HOME with config files (both paths are ignored in .gitignore)
    export DOTNET_CLI_HOME="$PWD/.net_cli_home";
    export NUGET_PACKAGES="$PWD/.nuget_packages";
  '';

  # Without this, there are warnings about LANG, LC_ALL and locales.
  # Many tests fail due those warnings showing up in test outputs too...
  # This solution is from: https://gist.github.com/aabs/fba5cd1a8038fb84a46909250d34a5c1
  LOCALE_ARCHIVE = "${glibcLocales}/lib/locale/locale-archive";
}
