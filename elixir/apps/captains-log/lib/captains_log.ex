defmodule CaptainsLog do
  @planetary_classes ["D", "H", "J", "K", "L", "M", "N", "R", "T", "Y"]

  def random_planet_class() do
    Enum.random(@planetary_classes)
  end

  def random_ship_registry_number() do
    "NCC-#{random_between(1000, 9999) |> round()}"
  end

  def random_stardate() do
    random_between(41_000, 42_000)
  end

  def format_stardate(stardate) do
    :io_lib.format("~.1f", [stardate])
    |> List.to_string()
  end

  defp random_between(a, b) do
    :rand.uniform() * (b - a) + a
  end
end
