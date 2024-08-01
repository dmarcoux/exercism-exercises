# <a href="https://github.com/dmarcoux/exercism-exercises">dmarcoux/exercism-exercises</a>

Solutions for the exercises from the Exercism Elixir track.

## Development Environment

Start with `nix-shell --pure`.

## Configure Exercism CLI

Be sure to configure the Exercism CLI before proceeding.

```bash
exercism configure --workspace "~/projets/exercism-exercises" --token="$(op read 'op://Private/exercism.org/API Token')"
```

## Download Exercises

Each directory contains an exercise which was downloaded with:

```bash
exercism download --track=elixir --exercise=NAME
```

## How to Test A Solution

Before submitting a solution, ensure it's working by making all its tests pass.
All but the first test are pending, so remove `@tag :pending` and make them all
pass.

Run the tests with:

```bash
mix test
```

## Submit Solutions

Once all tests are passing, submit a solution with:

```bash
exercism submit EXERCISE_DIRECTORY/FILE_123.cs
```

## Continuous Integration

TODO: This isn't working anymore.

The exercises are organized under an umbrella project to easily run `mix format`
and other tools across all exercises at once. It's an excuse to use what I've
learned about continuous integration for Elixir projects.

For umbrella projects, directory and application names have to match. Exercism
exercises don't follow this, since directory names use hyphen to as a word
separator while application names use underscores. This must be changed for the
continuous integration to run. Replace underscores by hyphens in application
names and surround those application names with double quotes in `mix.exs`.
