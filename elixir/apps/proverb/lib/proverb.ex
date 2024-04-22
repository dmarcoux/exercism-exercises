defmodule Proverb do
  @doc """
  Generate a proverb from a list of words.
  """
  @spec recite(words :: [String.t()]) :: String.t()
  def recite([]), do: ""
  def recite([word]), do: "And all for the want of a #{word}.\n"

  def recite(words = [word | remaining_words]) do
    words
    |> Enum.zip(remaining_words)
    |> Enum.reduce("", fn {first_word, second_word}, proverb ->
      proverb <> "For want of a #{first_word} the #{second_word} was lost.\n"
    end)
    |> Kernel.<>(recite([word]))
  end
end
