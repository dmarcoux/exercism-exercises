defmodule CollatzConjecture do
  import Integer, only: [is_even: 1, is_odd: 1]

  @doc """
  calc/1 takes an integer and returns the number of steps required to get the
  number to 1 when following the rules:
    - if number is odd, multiply with 3 and add 1
    - if number is even, divide by 2
  """
  @spec calc(number :: pos_integer()) :: non_neg_integer()
  def calc(_number = 1), do: 0
  def calc(number) when number > 0 and is_even(number), do: 1 + calc(div(number, 2))
  def calc(number) when number > 0 and is_odd(number), do: 1 + calc(3 * number + 1)
end
