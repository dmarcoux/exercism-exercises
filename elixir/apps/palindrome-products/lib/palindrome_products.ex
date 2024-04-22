defmodule PalindromeProducts do
  @doc """
  Generates all palindrome products from an optionally given min factor (or 1) to a given max factor.
  """
  @spec generate(non_neg_integer, non_neg_integer) :: map
  def generate(max_factor, min_factor \\ 1)
  def generate(max_factor, min_factor) when max_factor < min_factor, do: raise(ArgumentError)

  def generate(max_factor, min_factor) do
    range = Enum.to_list(min_factor..max_factor)

    for i <- range, j <- range, palindrome?(i * j), reduce: %{} do
      palindrome_products ->
        palindrome = i * j

        # Avoid duplicate factors in palindrome_products
        if Enum.any?(
             Map.get(palindrome_products, palindrome, []),
             &(&1 == [i, j] || &1 == [j, i])
           ) do
          palindrome_products
        else
          Map.update(palindrome_products, palindrome, [[i, j]], fn factors ->
            [[i, j] | factors]
          end)
        end
    end
  end

  defp palindrome?(number) do
    number_string = Integer.to_string(number)
    reversed_number_string = number_string |> String.graphemes() |> Enum.reverse() |> Enum.join()

    number_string == reversed_number_string
  end
end
