defmodule KitchenCalculator do
  def get_volume({_volume, amount}), do: amount

  def to_milliliter(volume_pair = {:milliliter, _amount}), do: volume_pair
  def to_milliliter({:cup, amount}), do: to_milliliter({:milliliter, amount * 240})
  def to_milliliter({:fluid_ounce, amount}), do: to_milliliter({:milliliter, amount * 30})
  def to_milliliter({:teaspoon, amount}), do: to_milliliter({:milliliter, amount * 5})
  def to_milliliter({:tablespoon, amount}), do: to_milliliter({:milliliter, amount * 15})

  def from_milliliter(volume_pair = {:milliliter, _amount}, _unit = :milliliter), do: volume_pair
  def from_milliliter({:milliliter, amount}, unit = :cup), do: {unit, amount / 240}
  def from_milliliter({:milliliter, amount}, unit = :fluid_ounce), do: {unit, amount / 30}
  def from_milliliter({:milliliter, amount}, unit = :teaspoon), do: {unit, amount / 5}
  def from_milliliter({:milliliter, amount}, unit = :tablespoon), do: {unit, amount / 15}

  def convert(volume_pair, unit), do: to_milliliter(volume_pair) |> from_milliliter(unit)
end
