defmodule Lasagna do
  def expected_minutes_in_oven(), do: 40

  def remaining_minutes_in_oven(minutes_so_far) when is_integer(minutes_so_far) do
    expected_minutes_in_oven() - minutes_so_far
  end

  def preparation_time_in_minutes(number_of_layers) when is_integer(number_of_layers) do
    number_of_layers * 2
  end

  def total_time_in_minutes(number_of_layers, minutes_in_oven_so_far)
      when is_integer(number_of_layers) and
             is_integer(minutes_in_oven_so_far) do
    preparation_time_in_minutes(number_of_layers) + minutes_in_oven_so_far
  end

  def alarm(), do: "Ding!"
end
