defmodule AllYourBase do
  @doc """
  Given a number in input base, represented as a sequence of digits, converts it to output base,
  or returns an error tuple if either of the bases are less than 2
  """

  @spec convert(list, integer, integer) :: {:ok, list} | {:error, String.t()}
  def convert(_digits, _input_base, output_base) when output_base < 2 do
    {:error, "output base must be >= 2"}
  end

  def convert(_digits, input_base, _output_base) when input_base < 2 do
    {:error, "input base must be >= 2"}
  end

  def convert(digits, input_base, output_base) do
    cond do
      Enum.any?(digits, &(&1 < 0 || &1 >= input_base)) ->
        {:error, "all digits must be >= 0 and < input base"}

      Enum.all?(digits, &(&1 == 0)) ->
        {:ok, [0]}

      true ->
        number_base_10 =
          digits
          |> Enum.reverse()
          |> Enum.with_index()
          |> Enum.reduce(0, fn {digit, index}, acc ->
            acc + digit * Integer.pow(input_base, index)
          end)

        {
          :ok,
          convert_to(number_base_10, output_base)
        }
    end
  end

  defp convert_to(_number = 0, _other_base), do: []

  defp convert_to(number, other_base) do
    convert_to(div(number, other_base), other_base) ++ [rem(number, other_base)]
  end
end
