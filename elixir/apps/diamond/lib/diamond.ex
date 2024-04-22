defmodule Diamond do
  @doc """
  Given a letter, it prints a diamond starting with 'A',
  with the supplied letter at the widest point.
  """
  @spec build_shape(char) :: String.t()
  def build_shape(_last_letter = ?A), do: "A\n"

  def build_shape(last_letter) do
    letters_in_shape = Enum.to_list(?A..last_letter) ++ Enum.to_list((last_letter - 1)..?A)

    Enum.map_join(letters_in_shape, "\n", fn current_letter ->
      build_shape_row(current_letter, last_letter)
    end) <> "\n"
  end

  @spec build_shape_row(char, char) :: String.t()
  defp build_shape_row(current_letter = ?A, last_letter) do
    outer_padding = outer_padding(current_letter, last_letter)

    "#{outer_padding}#{<<current_letter::utf8>>}#{outer_padding}"
  end

  defp build_shape_row(current_letter, last_letter) do
    outer_padding = outer_padding(current_letter, last_letter)

    "#{outer_padding}#{<<current_letter::utf8>>}#{inner_padding(current_letter)}#{<<current_letter::utf8>>}#{outer_padding}"
  end

  # Except for the letter A, the inner padding of a letter in a diamond shape can be represented by an arithmetic sequence of odd numbers (1, 3, 5, 7, etc...)
  # The formula to generate numbers for that sequence is 2n - 1
  @spec inner_padding(char) :: String.t()
  defp inner_padding(_letter = ?A), do: ""

  defp inner_padding(letter) do
    n = letter - ?A

    String.duplicate(" ", 2 * n - 1)
  end

  @spec outer_padding(char, char) :: String.t()
  defp outer_padding(_current_letter, _last_letter = ?A), do: ""

  defp outer_padding(current_letter, last_letter) do
    difference = last_letter - current_letter

    String.duplicate(" ", difference)
  end
end
