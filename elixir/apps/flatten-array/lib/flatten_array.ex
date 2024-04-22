defmodule FlattenArray do
  @doc """
    Accept a list and return the list flattened without nil values.

    ## Examples

      iex> FlattenArray.flatten([1, [2], 3, nil])
      [1,2,3]

      iex> FlattenArray.flatten([nil, nil])
      []

  """

  @spec flatten(list) :: list
  def flatten([]), do: []
  def flatten([_head = nil | tail]), do: flatten(tail)
  def flatten([head | tail]) when not is_list(head), do: [head | flatten(tail)]
  def flatten([head | tail]), do: flatten(head) ++ flatten(tail)
end
