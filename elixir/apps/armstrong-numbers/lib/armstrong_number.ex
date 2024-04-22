defmodule ArmstrongNumber do
  @moduledoc """
  Provides a way to validate whether or not a number is an Armstrong number
  """

  @spec valid?(integer) :: boolean
  def valid?(number) do
    digits = Integer.digits(number)
    number_of_digits = length(digits)

    Enum.reduce(digits, _total = 0, fn number, total ->
      total + Integer.pow(number, number_of_digits)
    end)
    |> Kernel.==(number)
  end
end
