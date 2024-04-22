defmodule BeerSong do
  @doc """
  Get a single verse of the beer song
  """
  @spec verse(non_neg_integer()) :: String.t()
  def verse(number) do
    "#{verse_first_sentence(number)}\n#{verse_second_sentence(number)}\n"
  end

  @doc """
  Get the entire beer song for a given range of numbers of bottles.
  """
  @spec lyrics(Range.t()) :: String.t()
  def lyrics(range \\ 99..0), do: Enum.map_join(range, "\n", &verse/1)

  @spec verse_first_sentence(non_neg_integer()) :: String.t()
  defp verse_first_sentence(number) do
    cond do
      number > 1 ->
        "#{number} bottles of beer on the wall, #{number} bottles of beer."

      number == 1 ->
        "1 bottle of beer on the wall, 1 bottle of beer."

      true ->
        "No more bottles of beer on the wall, no more bottles of beer."
    end
  end

  @spec verse_second_sentence(non_neg_integer()) :: String.t()
  defp verse_second_sentence(number) do
    cond do
      number > 2 ->
        "Take one down and pass it around, #{number - 1} bottles of beer on the wall."

      number == 2 ->
        "Take one down and pass it around, 1 bottle of beer on the wall."

      number == 1 ->
        "Take it down and pass it around, no more bottles of beer on the wall."

      true ->
        "Go to the store and buy some more, 99 bottles of beer on the wall."
    end
  end
end
