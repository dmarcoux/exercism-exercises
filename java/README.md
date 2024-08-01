# <a href="https://github.com/dmarcoux/exercism-exercises">dmarcoux/exercism-exercises</a>

Solutions for the exercises from the Exercism Java track.

## Development Environment

Install the [JetBrains IntelliJ IDEA](https://www.jetbrains.com/idea/) IDE, it's the
`pkgs.jetbrains.idea-ultimate` on NixOS. Launch IDEA with the Nix shell:

```bash
nix-shell --run 'nohup idea-ultimate &'
```

Afterwards, for a development environment with only the packages from the Nix
shell, go with:

```bash
nix-shell --pure
```

## Configure Exercism CLI

Be sure to configure the Exercism CLI before proceeding.

```bash
exercism configure --workspace "~/projets/exercism-exercises" --token="$(op read 'op://Private/exercism.org/API Token')"
```

## Download Exercises

Each directory contains an exercise which was downloaded with:

```bash
exercism download --track=java --exercise=NAME
```

It was then included in the Gradle composite build with:

```bash
echo 'includeBuild("EXERCISE_DIRECTORY")' >> settings.gradle.kts
```

## How to Test A Solution

Before submitting a solution, ensure it's working by making all its tests pass.

Run the tests with:

```bash
./gradlew :EXERCISE_DIRECTORY:test
```

## Submit Solutions

Once all tests are passing, submit a solution with:

```bash
exercism submit EXERCISE_DIRECTORY/src/main/java/FILE_123.java
```
