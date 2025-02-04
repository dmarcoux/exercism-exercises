# <a href="https://github.com/dmarcoux/exercism-exercises">dmarcoux/exercism-exercises</a>

Solutions for the exercises from the Exercism Kotlin track.

## Development Environment

Within the [JetBrains IntelliJ IDEA](https://www.jetbrains.com/idea/) IDE, spin
up the devcontainer contained in this project.

## Configure Exercism CLI

Be sure to configure the Exercism CLI before proceeding.

```bash
exercism configure --workspace "~/projets/exercism-exercises" --token="$(op read 'op://Private/exercism.org/API Token')"
```

## Download Exercises

Each directory contains an exercise which was downloaded with:

```bash
exercism download --track=kotlin --exercise=NAME
```

It was then included in the Gradle composite build with:

```bash
echo 'includeBuild("EXERCISE_DIRECTORY")' >> settings.gradle.kts
```

## How to Test A Solution

Before submitting a solution, ensure it's working by making all its tests pass.

Run the tests with:

```bash
cd EXERCISE_DIRECTORY
chmod +x gradlew
./gradlew :test
```

## Submit Solutions

Once all tests are passing, submit a solution with:

```bash
exercism submit EXERCISE_DIRECTORY/src/main/kotlin/FILE_123.kt
```
