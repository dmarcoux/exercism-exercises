defmodule Anagram do
  @doc """
  Returns all candidates that are anagrams of, but not equal to, 'base'.
  """
  @spec match(String.t(), [String.t()]) :: [String.t()]
  def match(base, candidates) do
    base_downscased = String.downcase(base)
    base_graphemes = String.graphemes(base_downscased) |> Enum.sort()

    candidates
    |> Enum.filter(fn candidate ->
      candidate_downcased = String.downcase(candidate)
      candidate_graphemes = String.graphemes(candidate_downcased) |> Enum.sort()

      candidate_downcased != base_downscased && base_graphemes == candidate_graphemes
    end)
  end
end
