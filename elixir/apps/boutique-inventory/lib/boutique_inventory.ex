defmodule BoutiqueInventory do
  def sort_by_price(inventory), do: Enum.sort_by(inventory, & &1.price)

  def with_missing_price(inventory), do: Enum.filter(inventory, &(&1.price == nil))

  def update_names(inventory, old_word, new_word) do
    Enum.map(inventory, fn item ->
      %{item | name: String.replace(item.name, old_word, new_word)}
    end)
  end

  def increase_quantity(item, count) do
    updated_quantity =
      Enum.into(item.quantity_by_size, %{}, fn {size, quantity} ->
        {size, quantity + count}
      end)

    %{item | quantity_by_size: updated_quantity}
  end

  # The automated feedback doesn't like this solution... I should be using Enum.reduce
  # def total_quantity(item), do: Map.values(item.quantity_by_size) |> Enum.sum()
  def total_quantity(item) do
    Enum.reduce(item.quantity_by_size, 0, fn {_size, quantity}, accumulator ->
      accumulator + quantity
    end)
  end
end
