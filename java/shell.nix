# This file is based on:
# https://github.com/NixOS/nixpkgs/blob/3ab807f275232d227e846b5947775dc99e24e63c/doc/languages-frameworks/java.section.md

# To ensure this nix-shell is reproducible, we pin the packages index to a commit SHA taken from a channel on https://status.nixos.org/
# This commit is from NixOS 23.11
with (import (fetchTarball https://github.com/NixOS/nixpkgs/archive/a5e4bbcb4780c63c79c87d29ea409abf097de3f7.tar.gz) {});

mkShell {
  name = "dotnet-env";

  packages = [
    # Java Development Kit
    jdk21

    # Build automation tool for Java projects
    gradle

    # CLI to easily create Spring-based applications
    spring-boot-cli

    # Locales
    glibcLocales
  ];

  shellHook = ''
    # Set LANG for locales, otherwise it is unset when running "nix-shell --pure"
    export LANG="C.UTF-8"

    # Remove duplicate commands from Bash shell command history
    export HISTCONTROL=ignoreboth:erasedups
  '';

  # Without this, there are warnings about LANG, LC_ALL and locales.
  # Many tests fail due those warnings showing up in test outputs too...
  # This solution is from: https://gist.github.com/aabs/fba5cd1a8038fb84a46909250d34a5c1
  LOCALE_ARCHIVE = "${glibcLocales}/lib/locale/locale-archive";
}
