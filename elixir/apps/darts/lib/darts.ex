defmodule Darts do
  @type position :: {number, number}

  @doc """
  Calculate the score of a single dart hitting a target
  """
  @spec score(position) :: integer
  def score({x, y}) do
    distance_from_center = :math.sqrt(x * x + y * y)

    cond do
      # Inner circle
      distance_from_center <= 1 ->
        10

      # Middle circle
      distance_from_center <= 5 ->
        5

      # Outer circle
      distance_from_center <= 10 ->
        1

      # Outside the target
      true ->
        0
    end
  end
end
