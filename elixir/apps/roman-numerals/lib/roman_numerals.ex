defmodule RomanNumerals do
  @conversion_table [
    {1000, "M"},
    {900, "CM"},
    {500, "D"},
    {400, "CD"},
    {100, "C"},
    {90, "XC"},
    {50, "L"},
    {40, "XL"},
    {10, "X"},
    {9, "IX"},
    {5, "V"},
    {4, "IV"},
    {1, "I"}
  ]

  @doc """
  Convert the number to a roman number.
  """
  @spec numeral(pos_integer) :: String.t()
  def numeral(number), do: convert(number, @conversion_table)

  @spec convert(pos_integer, list({pos_integer, String.t()})) :: String.t()
  defp convert(_number, []), do: ""

  defp convert(number, [{arabic_number, roman_numeral} | tail]) do
    division = div(number, arabic_number)
    remainder = rem(number, arabic_number)

    String.duplicate(roman_numeral, division) <> convert(remainder, tail)
  end
end
