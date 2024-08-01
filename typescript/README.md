# <a href="https://github.com/dmarcoux/exercism-exercises">dmarcoux/exercism-exercises</a>

Solutions for the exercises from the Exercism TypeScript track.

## Development Environment

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
exercism download --track=typescript --exercise=NAME
```

## How to Test A Solution

Before submitting a solution, ensure it's working by making all its tests pass.
All but the first test are skipped, so turn `xit` into `it` and make them
all pass.

Run the tests with:

```bash
yarn test
```

## Submit Solutions

Once all tests are passing, submit a solution with:

```bash
exercism submit EXERCISE_DIRECTORY/FILE_123.ts
```
