defmodule Pangram do
  @doc """
  Determines if a word or sentence is a pangram.
  A pangram is a sentence using every letter of the alphabet at least once.

  Returns a boolean.

    ## Examples

      iex> Pangram.pangram?("the quick brown fox jumps over the lazy dog")
      true

  """

  @alphabet Enum.map(?a..?z, fn letter -> <<letter::utf8>> end)

  @spec pangram?(String.t()) :: boolean
  def pangram?(sentence) when byte_size(<<sentence>>) < length(@alphabet), do: false

  def pangram?(sentence) do
    sentence
    |> String.downcase()
    |> String.graphemes()
    |> Enum.uniq()
    |> Enum.count(fn character -> character in @alphabet end)
    |> Kernel.==(length(@alphabet))
  end
end
