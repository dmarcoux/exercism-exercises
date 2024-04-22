# <a href="https://github.com/dmarcoux/exercism-exercises">dmarcoux/exercism-exercises</a>

Solutions for the exercises from the Exercism C# track.

## Development Environment

Install the [JetBrains Rider](https://www.jetbrains.com/rider/) IDE, it's the
`pkgs.jetbrains.rider` on NixOS. Launch Rider with the Nix shell:

```bash
nix-shell --run 'nohup rider &'
```

Afterwards, for a development environment with only the packages from the Nix
shell, go with:

```bash
nix-shell --pure
```

## Configure Exercism CLI

Be sure to configure the Exercism CLI before proceeding.

```bash
# My API token can be found at https://exercism.org/settings/api_cli
exercism configure --workspace "~/projets/exercism-exercises" --token=MY_API_TOKEN
```

## Download Exercises

Each directory contains an exercise which was downloaded with:

```bash
exercism download --track=csharp --exercise=NAME
```

## How to Test A Solution

Before submitting a solution, ensure it's working by making all its tests pass.
All but the first test are skipped, so remove the `Skip` property and make them
all pass.

Run the tests with:

```bash
dotnet test
```

## Submit Solutions

Once all tests are passing, submit a solution with:

```bash
exercism submit EXERCISE_DIRECTORY/FILE_123.cs
```
